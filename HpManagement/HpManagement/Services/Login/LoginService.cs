using HpManagement.DBModel;
using HpManagement.DBModel.DBDTO;
using HpManagement.DTO;
using HpManagement.Helpers;
using HpManagement.Repository.Login;
using HpManagement.Services.Logger;
using HpManagement.Services.Redis;
using HpManagement.Services.Token;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HpManagement.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration Configuration;
        private readonly ILoggerService LoggerService;
        private readonly IRedisCacheService RedisCacheService;
        private readonly ILoginRepository LoginRepository;

        public LoginService(IConfiguration _configuration,
            ILoggerService _loggerervice,
            IRedisCacheService _rediscacheservice,
            ILoginRepository _loginrepository)
        {
            this.Configuration = _configuration;
            this.LoggerService = _loggerervice;
            this.RedisCacheService = _rediscacheservice;
            this.LoginRepository = _loginrepository;

        }

        /// <summary>
        /// [웹] 액세스 토큰 발급 서비스
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseModel<TokenDTO>?> WebLoginService(LoginDTO dto)
        {
            try
            {
                if(String.IsNullOrWhiteSpace(dto.LoginID))
                {
                    /* 아이디가 비어있음. */
                    return new ResponseModel<TokenDTO>() { data = null, code = 204 };
                }
                if(String.IsNullOrWhiteSpace(dto.LoginPW))
                {
                    /* 비밀번호가 비어있음. */
                    return new ResponseModel<TokenDTO>() { data = null, code = 204 };
                }

                LoginDbDto? AdminModel = await LoginRepository.GetLoginAsync(dto.LoginID);
                if (AdminModel is not null)
                    return new ResponseModel<TokenDTO>() { data = null, code = 204 };

                // 비밀번호 Validator 검사
                if(!Validator.passwordValidator(dto.LoginPW))
                {
                    /* 비밀번호 유효성 검사에서 탈락 */
                    return new ResponseModel<TokenDTO>() { data = null, code = 422 };
                }

                string shapwd = CipherUtil.EncryptSHA256(dto.LoginPW);

                if(shapwd != AdminModel.PASSWD)
                {
                    /* 비밀번호가 다름 */
                    return new ResponseModel<TokenDTO>() { data = null, code = 404 };
                }

                if(AdminModel.PERMISSION == "X")
                {
                    /* 현재 계정은 로그인 할 수 없습니다. 슈퍼 관리자에게 문의 하십시오! */
                    return new ResponseModel<TokenDTO>() { data = null, code = 404 };
                }
                else if(AdminModel.PERMISSION == "U" || AdminModel.PERMISSION == "W")
                {
                    // 여기일땐 무엇인가
                    // 여기일땐 userJobList.do 컨트롤러를 쏘는데?
                    return new ResponseModel<TokenDTO>() { data = null, code = 404 };
                }
                else  // M 이라고 되어있는데 M이든 뭐든 상관없음.
                {
                    List<Claim> authClaims = new List<Claim>();
                    authClaims.Add(new Claim("userId", AdminModel.USERID)); // 사용자 ID
                    authClaims.Add(new Claim("name", AdminModel.USERNM)); // 사용자 명
                    authClaims.Add(new Claim("deptCd", AdminModel.DEPTCD)); // 부서코드
                    authClaims.Add(new Claim("role", "관리자")); // 권한

                    // JWT 인증 페이로드 사인 비밀키
                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:authSigningKey"]!));

                    JwtSecurityToken token = new JwtSecurityToken(
                        issuer: Configuration["JWT:Issuer"],
                        audience: Configuration["JWT:Audience"],
                        expires: DateTime.Now.AddMinutes(15), // 15분 후 만료
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

                    // accessToken
                    string accessToken = new JwtSecurityTokenHandler().WriteToken(token);

                    // RefreshToken
                    string refreshToken = TokenComm.GenerateRefreshToken();

                    // Redis 캐쉬 저장
                    await RedisCacheService.SetAsync(dto.LoginID, refreshToken);

                    var tokenResult = new TokenDTO
                    {
                        accessToken = accessToken,
                        refreshToken = refreshToken
                    };
                    return new ResponseModel<TokenDTO>() { data = tokenResult, code = 200 };
                }
            }
            catch(Exception ex)
            {
                LoggerService.LogMessage(ex.ToString());
                return new ResponseModel<TokenDTO>() { data = null, code = 500 };
            }
        }

        /// <summary>
        /// [웹] 재발급 토큰 발급 서비스
        /// </summary>
        /// <param name="refreshTokenDTO"></param>
        /// <returns></returns>
        public async Task<ResponseModel<TokenDTO>?> WebLoginRefreshTokenService(RefreshTokenDTO refreshTokenDTO)
        {
            try
            {
                if(String.IsNullOrWhiteSpace(refreshTokenDTO.UserId) || String.IsNullOrWhiteSpace(refreshTokenDTO.RefreshToken))
                {
                    return new ResponseModel<TokenDTO>() { data = null, code = 204 };
                }

                // Refresh Token 유효성 검사 (GetAsync 호출만으로 슬라이딩 만료 연장)
                bool isValid = await RedisCacheService.GetAsync(refreshTokenDTO.UserId, refreshTokenDTO.RefreshToken);

                if(!isValid)
                {
#if DEBUG
                    Console.WriteLine("RefreshToken이 없습니다.");
#endif
                    return new ResponseModel<TokenDTO>() { data = null, code = 401 };
                }

                /*
                  UserId로 DB 조회 후 접근제한됐는지 & 진짜있는지 검사를 다시 하면 좋음
                */
                var AdminModel = await LoginRepository.GetLoginAsync(refreshTokenDTO.UserId);
                if (AdminModel is null)
                    return new ResponseModel<TokenDTO>() { data = null, code = 204 };

                List<Claim> authClaims = new List<Claim>();
                authClaims.Add(new Claim("userId", AdminModel.USERID)); // UserID
                authClaims.Add(new Claim("Name", AdminModel.USERNM));
                authClaims.Add(new Claim("role", "Admin"));

                // JWT 인증 페이로드 사인 비밀키
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:authSigningKey"]!));
                JwtSecurityToken newToken = new JwtSecurityToken(
                    issuer: Configuration["JWT:Issuer"],
                    audience: Configuration["JWT:Audience"],
                    expires: DateTime.Now.AddMinutes(15),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

                string newAccessToken = new JwtSecurityTokenHandler().WriteToken(newToken);

                // 기존 Refresh Token 무효화 후 새 Refresh Token 발급

                string? newRefreshToken = await RedisCacheService.RotateRefreshTokenAsync(
                      refreshTokenDTO.UserId,
                      refreshTokenDTO.RefreshToken
                );

                if (newRefreshToken == null)
                {
                    // 회전에 실패하면 인증 오류로 간주
                    return new ResponseModel<TokenDTO> { data = null, code = 401 };
                }

                var tokenResult = new TokenDTO
                {
                    accessToken = newAccessToken,
                    refreshToken = newRefreshToken
                };

                return new ResponseModel<TokenDTO>() { data = tokenResult, code = 200 };
            }
            catch(Exception ex)
            {
                LoggerService.LogMessage(ex.ToString());
                return new ResponseModel<TokenDTO>() { data = null, code = 500 };
            }
        }

        /// <summary>
        /// [모바일] 액세스 토큰 발급 서비스
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ResponseModel<TokenDTO>?> MobileLoginService(LoginDTO dto)
        {
            try
            {
                if(String.IsNullOrWhiteSpace(dto.LoginID))
                {
                    return new ResponseModel<TokenDTO>() { data = null, code = 204 };
                }

                var AdminModel = await LoginRepository.GetLoginAsync(dto.LoginID);
                if (AdminModel is null)
                    return new ResponseModel<TokenDTO>() { data = null, code = 204 };

                List<Claim> authClaims = new List<Claim>();
                authClaims.Add(new Claim("userId", AdminModel.USERID));
                authClaims.Add(new Claim("name", AdminModel.USERNM));
                authClaims.Add(new Claim("role", "Admin"));

                // JWT 인증 페이로드 사인 비밀키
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:authSigningKey"]));

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: Configuration["JWT:Issuer"],
                    audience: Configuration["JWT:Audience"],
                    expires: DateTime.Now.AddMinutes(15), // 15분 후 만료
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

                // accessToken
                string accessToken = new JwtSecurityTokenHandler().WriteToken(token);

                // RefreshToken
                string refreshToken = TokenComm.GenerateRefreshToken();

                // Redis 캐쉬 저장 - 모바일은 Long Time
                await RedisCacheService.SetAsync(dto.LoginID, refreshToken);

                var tokenResult = new TokenDTO
                {
                    accessToken = accessToken,
                    refreshToken = refreshToken
                };

                return new ResponseModel<TokenDTO>() { data = tokenResult, code = 200 };
            }
            catch(Exception ex)
            {
                LoggerService.LogMessage(ex.ToString());
                return new ResponseModel<TokenDTO>() { data = null, code = 500 };
            }
        }

        /// <summary>
        /// [모바일] 재발급 토큰 발급 서비스
        /// </summary>
        /// <param name="refreshTokenDTO"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ResponseModel<TokenDTO>?> MobileRefreshTokenService(RefreshTokenDTO refreshTokenDTO)
        {
            try
            {
                if(String.IsNullOrWhiteSpace(refreshTokenDTO.UserId) || String.IsNullOrWhiteSpace(refreshTokenDTO.RefreshToken))
                {
                    return new ResponseModel<TokenDTO>() { data = null, code = 204 };
                }

                // Redis Token 유효성 검사 (GetAsync 호출만으로 슬라이딩 만료 연장)
                bool isValid = await RedisCacheService.GetAsync(refreshTokenDTO.UserId, refreshTokenDTO.RefreshToken);

                if(!isValid)
                {
#if DEBUG
                    Console.WriteLine("RefreshToken이 없습니다.");
#endif
                    return new ResponseModel<TokenDTO>() { data = null, code = 401 };
                }

                /*
                 UserId로 DB 조회 후 접근제한됐는지 & 진짜있는지 검사를 다시 하면 좋음
                 */
                var AdminModel = await LoginRepository.GetLoginAsync(refreshTokenDTO.UserId);
                if (AdminModel is null)
                    return new ResponseModel<TokenDTO>() { data = null, code = 204 };

                List<Claim> authClaims = new List<Claim>();
                authClaims.Add(new Claim("userId", AdminModel.USERID)); // USER ID
                authClaims.Add(new Claim("name", AdminModel.USERNM));
                authClaims.Add(new Claim("role", "Admin"));

                // JWT 인증 페이로드 사인 비밀키
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:authSigningKey"]!));
                JwtSecurityToken newToke = new JwtSecurityToken(
                    issuer: Configuration["JWT:Issuer"],
                    audience: Configuration["JWT:Audience"],
                    expires: DateTime.Now.AddMinutes(15),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

                string newAccessToken = new JwtSecurityTokenHandler().WriteToken(newToke);

                // 기존 Refresh Token 무효화 후 새 Refresh Token 발급

                string? newRefreshToken = await RedisCacheService.RotateRefreshTokenAsync(
                      refreshTokenDTO.UserId,
                      refreshTokenDTO.RefreshToken
                );

                if (newRefreshToken == null)
                {
                    // 회전에 실패하면 인증 오류로 간주
                    return new ResponseModel<TokenDTO> { data = null, code = 401 };
                }

                var tokenResult = new TokenDTO
                {
                    accessToken = newAccessToken,
                    refreshToken = newRefreshToken
                };

                return new ResponseModel<TokenDTO>() { data = tokenResult, code = 200 };
            }
            catch(Exception ex)
            {
                LoggerService.LogMessage(ex.ToString());
                return new ResponseModel<TokenDTO>() { data = null, code = 500 };
            }
        }
    }
}
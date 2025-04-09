using HpManagement.DBModel;
using HpManagement.DTO;
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
                    return new ResponseModel<TokenDTO>() { data = null, code = 204 };
                }

                AdminModel? AdminModel = await LoginRepository.GetAdminInfoAsync(dto.LoginID);
                if (AdminModel is null)
                    return new ResponseModel<TokenDTO>() { data = null, code = 204 };

                List<Claim> authClaims = new List<Claim>();
                authClaims.Add(new Claim("userId", AdminModel.USERID));
                authClaims.Add(new Claim("Name", AdminModel.USERNM));
                authClaims.Add(new Claim("Role", "Admin"));

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
                await RedisCacheService.SetAsync(dto.LoginID, refreshToken, TimeSpan.FromDays(3), TimeSpan.FromHours(1));
                

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
        /// [웹] 재발급 토큰 발급 서비스
        /// </summary>
        /// <param name="refreshTokenDTO"></param>
        /// <returns></returns>
        public async Task<ResponseModel<TokenDTO>?> WebLoginRefreshTokenService(RefreshTokenDTO refreshTokenDTO)
        {
            try
            {
                if(String.IsNullOrWhiteSpace(refreshTokenDTO.UserId))
                {
                    return new ResponseModel<TokenDTO>() { data = null, code = 204 };
                }

                // Redis 캐시에서 저장된 Refresh 토큰을 조회
                var storedRefreshToken = await RedisCacheService.GetAsync(refreshTokenDTO.UserId);

                // 2) 토큰이 없으면 401 리턴
                if (string.IsNullOrEmpty(storedRefreshToken))
                {
#if DEBUG
                    Console.WriteLine("RefreshToken이 없습니다.");
#endif
                    return new ResponseModel<TokenDTO>() { data = null, code = 401 };
                }

                // 클라이언트가 보낸 Refresh 토큰과 저장된 토큰 비교
                if (storedRefreshToken != refreshTokenDTO.RefreshToken)
                {
                    return new ResponseModel<TokenDTO>() { data = null, code = 401 };
                }

                /*
                  UserId로 DB 조회 후 접근제한됐는지 & 진짜있는지 검사를 다시 하면 좋음
                */
                AdminModel? AdminModel = await LoginRepository.GetAdminInfoAsync(refreshTokenDTO.UserId);
                if (AdminModel is null)
                    return new ResponseModel<TokenDTO>() { data = null, code = 204 };

                List<Claim> authClaims = new List<Claim>();
                authClaims.Add(new Claim("userId", AdminModel.USERID)); // UserID
                authClaims.Add(new Claim("Name", AdminModel.USERNM));
                authClaims.Add(new Claim("Role", "Admin"));

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
                string newRefreshToken = TokenComm.GenerateRefreshToken();

                await RedisCacheService.RemoveAsync(refreshTokenDTO.UserId);
                
                await RedisCacheService.SetAsync(refreshTokenDTO.UserId, newRefreshToken, TimeSpan.FromDays(3), TimeSpan.FromHours(1));
                
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
        public Task<ResponseModel<TokenDTO>?> MobileLoginService(LoginDTO dto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// [모바일] 재발급 토큰 발급 서비스
        /// </summary>
        /// <param name="refreshTokenDTO"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<ResponseModel<TokenDTO>?> MobileRefreshTokenService(RefreshTokenDTO refreshTokenDTO)
        {
            throw new NotImplementedException();
        }
    }
}

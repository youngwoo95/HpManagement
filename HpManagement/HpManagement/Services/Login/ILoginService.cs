using HpManagement.DTO;

namespace HpManagement.Services.Login
{
    public interface ILoginService
    {
        /// <summary>
        /// [웹] - 액세스 토큰 발급 서비스
        /// </summary>
        /// <returns></returns>
        public Task<ResponseModel<TokenDTO>?> WebLoginService(LoginDTO dto);

        /// <summary>
        /// [웹] - 재발급 토큰 발급 서비스
        /// </summary>
        /// <param name="refreshTokenDTO"></param>
        /// <returns></returns>
        public Task<ResponseModel<TokenDTO>?> WebLoginRefreshTokenService(RefreshTokenDTO refreshTokenDTO);

        /// <summary>
        /// [모바일] - 액세스 토큰 발급 서비스
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task<ResponseModel<TokenDTO>?> MobileLoginService(LoginDTO dto);

        /// <summary>
        /// [모바일] - 재발급 토큰 발급 서비스
        /// </summary>
        /// <param name="refreshTokenDTO"></param>
        /// <returns></returns>
        public Task<ResponseModel<TokenDTO>?> MobileRefreshTokenService(RefreshTokenDTO refreshTokenDTO);

    }
}

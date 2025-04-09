namespace HpManagement.DTO
{
    public class TokenDTO
    {
        /// <summary>
        /// 액세스 토큰
        /// </summary>
        public string? accessToken { get; set; }

        /// <summary>
        /// 재발급 토큰
        /// </summary>
        public string? refreshToken { get; set; }
    }
}

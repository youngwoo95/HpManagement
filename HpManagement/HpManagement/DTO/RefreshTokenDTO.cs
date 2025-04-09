namespace HpManagement.DTO
{
    public class RefreshTokenDTO
    {
        /// <summary>
        /// 사용자 ID
        /// </summary>
        public string? UserId { get; set; } = string.Empty;

        /// <summary>
        /// 재발급 토큰
        /// </summary>
        public string? RefreshToken { get; set; } = string.Empty;
    }
}

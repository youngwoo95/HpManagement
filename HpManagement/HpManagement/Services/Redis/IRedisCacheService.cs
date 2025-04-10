namespace HpManagement.Services.Redis
{
    public interface IRedisCacheService
    {
        /// <summary>
        /// Redis INSERT
        /// </summary>
        /// <returns></returns>
        public Task SetAsync(string key, string refreshToken);

        /// <summary>
        /// Redis GET
        /// </summary>
        /// <returns></returns>
        public Task<bool> GetAsync(string key, string refreshToken);

        /// <summary>
        /// Redis DELETE
        /// </summary>
        /// <returns></returns>
        public Task<string?> RotateRefreshTokenAsync(string key, string refreshToken);
    }
}

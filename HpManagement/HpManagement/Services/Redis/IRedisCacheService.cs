namespace HpManagement.Services.Redis
{
    public interface IRedisCacheService
    {
        /// <summary>
        /// Redis INSERT
        /// </summary>
        /// <returns></returns>
        public Task SetAsync(string key, string value, TimeSpan absoluteExpire, TimeSpan slidingExpire);

        /// <summary>
        /// Redis GET
        /// </summary>
        /// <returns></returns>
        public Task<string?> GetAsync(string key);

        /// <summary>
        /// Redis DELETE
        /// </summary>
        /// <returns></returns>
        public Task RemoveAsync(string key);
    }
}

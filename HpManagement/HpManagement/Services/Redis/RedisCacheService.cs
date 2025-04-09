
using HpManagement.Services.Logger;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging.Abstractions;

namespace HpManagement.Services.Redis
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDistributedCache Cache;
        private readonly ILoggerService LoggerService;

        public RedisCacheService(IDistributedCache _cache,
            ILoggerService _loggerservice)
        {
            this.Cache = _cache;
            this.LoggerService = _loggerservice;
        }

        /// <summary>
        /// Redis 저장
        /// </summary>
        /// <returns></returns>
        public async Task SetAsync(string key, string value, TimeSpan absoluteExpire, TimeSpan slidingExpire)
        {
            try
            {
                var opts = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = absoluteExpire, // 절대만료 - 캐시 항목을 생성한 시점부터 무조껀 지정된 시간 후에 만료시킴.
                    SlidingExpiration = slidingExpire // 슬라이딩 만료 - 마지막 접근 시점으로부터 지정된 시간 (SlidingExpiration)이 지나면 만료시킴.
                };
                await Cache.SetStringAsync(key, value, opts);
            }
            catch(Exception ex)
            {
                LoggerService.LogMessage(ex.ToString());
            }
        }

        /// <summary>
        /// Redis 조회
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<string?> GetAsync(string key)
        {
            try
            {
                return await Cache.GetStringAsync(key);
            }
            catch(Exception ex)
            {
                LoggerService.LogMessage(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Redis 삭제
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task RemoveAsync(string key)
        {
            try
            {
                await Cache.RemoveAsync(key);
            }
            catch(Exception ex)
            {
                LoggerService.LogMessage(ex.ToString());
            }
        }

      
    }
}

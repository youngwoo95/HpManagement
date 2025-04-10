using HpManagement.Services.Logger;
using HpManagement.Services.Token;
using Microsoft.Extensions.Caching.Distributed;

namespace HpManagement.Services.Redis
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDistributedCache Cache;
        private readonly DistributedCacheEntryOptions Options;
        
        private readonly ILoggerService LoggerService;

        public RedisCacheService(IDistributedCache _cache,
            ILoggerService _loggerservice)
        {
            this.Cache = _cache;
            this.LoggerService = _loggerservice;
            Options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(7), // 절대만료 - 캐시 항목을 생성한 시점부터 무조껀 지정된 시간 후에 만료시킴.
                SlidingExpiration = TimeSpan.FromDays(1) // 슬라이딩 만료 - 마지막 접근 시점으로부터 지정된 시간 (SlidingExpiration)이 지나면 만료시킴.
            };
        }

        /// <summary>
        /// Redis 저장
        /// </summary>
        /// <returns></returns>
        public async Task SetAsync(string key, string refreshToken)
        {
            try
            {
                await Cache.SetStringAsync(key, refreshToken, Options);
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
        public async Task<bool> GetAsync(string key, string refreshToken)
        {
            try
            {
                var stored = await Cache.GetStringAsync(key);
                if (stored == null)
                {
                    return false;
                }

                // 2) 슬라이딩 만료 갱신
                await Cache.RefreshAsync(key);

                return stored == refreshToken;
            }
            catch(Exception ex)
            {
                LoggerService.LogMessage(ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// Redis 삭제
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<string?> RotateRefreshTokenAsync(string key, string refreshToken)
        {
            try
            {
                // 검증
                if(!await GetAsync(key, refreshToken))
                {
                    return null;
                }

                // 이전 토큰 즉시 폐기
                await Cache.RemoveAsync(key);

                // 새 토큰 생성
                string newToken = TokenComm.GenerateRefreshToken();

                // 새 토큰 저장
                await Cache.SetStringAsync(key, newToken, Options);

                return newToken;
            }
            catch(Exception ex)
            {
                LoggerService.LogMessage(ex.ToString());
                return null;
            }
        }

      
    }
}

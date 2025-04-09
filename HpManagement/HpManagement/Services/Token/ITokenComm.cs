
using Newtonsoft.Json.Linq;

namespace HpManagement.Services.Token
{
    public interface ITokenComm
    {
        /// <summary>
        /// 토큰 분해
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public JObject? TokenConvert(HttpRequest? token);
    }
}

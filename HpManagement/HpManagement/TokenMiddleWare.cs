using HpManagement.Services.Logger;
using HpManagement.Services.Token;

namespace HpManagement
{
    public class TokenMiddleWare
    {
        private readonly RequestDelegate Next;
        private readonly ITokenComm TokenComm;
        private readonly string? AuthSigningKey;
        private readonly string? Issuer;
        private readonly string? Audience;
        private readonly ILoggerService LoggerService;


    }
}

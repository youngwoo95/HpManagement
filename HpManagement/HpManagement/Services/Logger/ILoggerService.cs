namespace HpManagement.Services.Logger
{
    public interface ILoggerService
    {
        /// <summary>
        /// 로그메시지 저장
        /// </summary>
        /// <param name="message"></param>
        public void LogMessage(string message);

    }
}

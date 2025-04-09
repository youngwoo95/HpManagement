namespace HpManagement.Services.Logger
{
    public class LoggerService : ILoggerService
    {
        private static readonly object LogLock = new object();

        /// <summary>
        /// 에러 로그 메시지 저장
        /// </summary>
        /// <param name="message"></param>
        public void LogMessage(string message)
        {
            try
            {
                DateTime Today = DateTime.Now;
                string dir_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SystemLog");

                DirectoryInfo di = new DirectoryInfo(dir_path);

                if(!di.Exists)
                {
                    di.Create();
                }

                // 년도 파일 없으면 생성
                dir_path = Path.Combine(dir_path, Today.Year.ToString());
                di = new DirectoryInfo(dir_path);
                if(!di.Exists)
                {
                    di.Create();
                }

                // 월 파일 없으면 생성
                dir_path = Path.Combine(dir_path, Today.Month.ToString());
                di = new DirectoryInfo(dir_path);

                if(!di.Exists)
                {
                    di.Create();
                }

                dir_path = Path.Combine(dir_path, $"{Today.Year}_{Today.Month}_{Today.Day}.txt");

                lock(LogLock)
                {
                    using (var fs = new FileStream(dir_path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}]\t{message}");
#if DEBUG
                        Console.WriteLine($"[INFO] {message}");
#endif
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

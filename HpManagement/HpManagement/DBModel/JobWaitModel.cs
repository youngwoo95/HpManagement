namespace HpManagement.DBModel
{
    /// <summary>
    /// 이송대기정보 테이블
    /// </summary>
    public class JobWaitModel
    {
        /// <summary>
        /// STSS_JOB_ROWID
        /// </summary>
        public string? JOBKEY { get; set; }

        /// <summary>
        /// 대기코드
        /// </summary>
        public string? WAIT_CD { get; set; }

        /// <summary>
        /// 대기시작시간
        /// </summary>
        public DateTime? START_TIME { get; set; }

        /// <summary>
        /// 대기종료시간
        /// </summary>
        public DateTime? END_TIME { get; set; }
    }
}

namespace HpManagement.DBModel
{
    /// <summary>
    /// 조별 근무 정보 테이블
    /// </summary>
    public class ScheduleShiftModel
    {
        /// <summary>
        /// 근무일
        /// </summary>
        public DateTime SCHD_DATE { get; set; }

        /// <summary>
        /// 근무조
        /// </summary>
        public string SHIFT { get; set; } = null!;

        /// <summary>
        /// 근무시간구분
        /// </summary>
        public string? TIME_TP { get; set; }

        /// <summary>
        /// 시작시간
        /// </summary>
        public string? START_TIME { get; set; }

        /// <summary>
        /// 종료시간
        /// </summary>
        public string? END_TIME { get; set; }
    }
}

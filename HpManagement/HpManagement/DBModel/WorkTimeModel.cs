namespace HpManagement.DBModel
{
    /// <summary>
    /// 근무시간정보 테이블
    /// </summary>
    public class WorkTimeModel
    {
        /// <summary>
        /// 근무시간 구분코드
        /// </summary>
        public string TIMETP { get; set; } = null!;

        /// <summary>
        /// 시작시간
        /// </summary>
        public string START_TIME { get; set; } = null!;

        /// <summary>
        /// 종료시간
        /// </summary>
        public string END_TIME { get; set; } = null!;

        /// <summary>
        /// 등록자
        /// </summary>
        public string USERID { get; set; } = null!;

        /// <summary>
        /// 등록일
        /// </summary>
        public DateTime RDATE { get; set; }
    }
}

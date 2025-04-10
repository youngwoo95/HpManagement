namespace HpManagement.DBModel
{
    /// <summary>
    /// 이송요원 근무정보 테이블
    /// </summary>
    public class ScheduleAgentModel
    {
        /// <summary>
        /// 근무일
        /// </summary>
        public DateTime SCHD_DATE { get; set; }

        /// <summary>
        /// 사원ID
        /// </summary>
        public string AGENTID { get; set; } = null!;

        /// <summary>
        /// 시작시간 (0: 음력, 1: 양력)
        /// </summary>
        public string START_TIME { get; set; } = null!;

        /// <summary>
        /// 종료시간
        /// </summary>
        public string END_TIME { get; set; } = null!;

        /// <summary>
        /// 근무조
        /// </summary>
        public string? SHIFT { get; set; }

        /// <summary>
        /// 등록자
        /// </summary>
        public string? REGID { get; set; }

        /// <summary>
        /// 등록시간
        /// </summary>
        public DateTime? REGTIME { get; set; }

        /// <summary>
        /// 수정자
        /// </summary>
        public string? EDITID { get; set; } = null!;

        /// <summary>
        /// 수정시간
        /// </summary>
        public DateTime? EDITTIME { get; set; }
        public string? CONT_START_YN { get; set; }
        public string? CONT_END_YN { get; set; }
    }
}

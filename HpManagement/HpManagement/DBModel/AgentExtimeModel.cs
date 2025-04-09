namespace HpManagement.DBModel
{
    /// <summary>
    /// 이송요원 연장근무정보
    /// </summary>
    public class AgentExtimeModel
    {
        /// <summary>
        /// 근무일자
        /// </summary>
        public DateTime RDATE { get; set; }

        /// <summary>
        /// 사원ID
        /// </summary>
        public string AGENTID { get; set; } = null!;

        /// <summary>
        /// 연장근무 시작시간
        /// </summary>
        public string? ESTART_TIME { get; set; }

        /// <summary>
        /// 연장근무 종료시간
        /// </summary>
        public string? EEND_TIME { get; set; }
    }
}

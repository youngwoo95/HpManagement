namespace HpManagement.DBModel
{
    /// <summary>
    /// 이송요원 휴식정보 테이블
    /// </summary>
    public class AgentRestModel
    {
        /// <summary>
        /// 근무일자
        /// </summary>
        public DateOnly? RDATE { get; set; }

        /// <summary>
        /// 사원 ID
        /// </summary>
        public string? AGENTID { get; set; }

        /// <summary>
        /// 휴식 시작시간
        /// </summary>
        public string? STARTTIME { get; set; }

        /// <summary>
        /// 휴식 종료시간
        /// </summary>
        public string? ENDTIME { get; set; }

        /// <summary>
        /// 휴식 코드
        /// </summary>
        public string? RESTCD { get; set; }
    }
}

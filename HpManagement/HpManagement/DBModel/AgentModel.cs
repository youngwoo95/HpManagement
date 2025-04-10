namespace HpManagement.DBModel
{
    /// <summary>
    /// 이송요원 정보 테이블
    /// </summary>
    public class AgentModel
    {
        /// <summary>
        /// 사원번호
        /// </summary>
        public string AGENTID { get; set; } = null!;

        /// <summary>
        /// 패스워드
        /// </summary>
        public string? PASSWD { get; set; }

        /// <summary>
        /// 사원명
        /// </summary>
        public string? AGENTNM { get; set; }

        /// <summary>
        /// 전화번호
        /// </summary>
        public string? PHNNO { get; set; }

        /// <summary>
        /// 권한
        /// </summary>
        public string? PERMISSION { get; set; }

        /// <summary>
        /// 근무조
        /// </summary>
        public string? SHIFT { get; set; }

        /// <summary>
        /// 등록시간
        /// </summary>
        public string? START_TIME { get; set; }

        /// <summary>
        /// 종료시간
        /// </summary>
        public string? END_TIME { get; set; }
        
        /// <summary>
        /// 등록일
        /// </summary>
        public DateTime? RDATE { get; set; }

        /// <summary>
        /// 종료일
        /// </summary>
        public DateTime? CDATE { get; set; }

        /// <summary>
        /// 현재상태
        /// </summary>
        public string? ISWORK { get; set; }

        /// <summary>
        /// 사용여부
        /// </summary>
        public string? STATUS { get; set; }

        /// <summary>
        /// APPKEY
        /// </summary>
        public string? APPKEY { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        public string? REGU_YN { get; set; }

        /// <summary>
        /// 마지막JOB
        /// </summary>
        public string? LAST_WORK { get; set; }

        /// <summary>
        /// 마지막JOB TIME
        /// </summary>
        public DateTime? LAST_TIME { get; set; }

        /// <summary>
        /// 마지막 위치
        /// </summary>
        public string? LAST_LOC { get; set; }

        /// <summary>
        /// 마지막 로그인 시간
        /// </summary>
        public DateTime? LAST_LOGIN_DT { get; set; }

        /// <summary>
        /// 근무지
        /// </summary>
        public string? SECTOR { get; set; }

        /// <summary>
        /// 근무유형
        /// </summary>
        public string? BIZTYPE { get; set; }

        /// <summary>
        /// 일별 최초 로그인시간
        /// </summary>
        public DateTime? FIRST_LOGIN_DT { get; set; }

        /// <summary>
        /// 로그아웃시간
        /// </summary>
        public DateTime? LOGOUT_DT { get; set; }
    }
}

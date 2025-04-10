namespace HpManagement.DBModel
{
    /// <summary>
    /// 시스템 설정정보 테이블
    /// </summary>
    public class SysConfigModel
    {
        /// <summary>
        /// 자동배정여부
        /// </summary>
        public string? AAUTOFLAG { get; set; }

        /// <summary>
        /// 임시(동일층)
        /// </summary>
        public int? SAME_FLO_TIME { get; set; }

        /// <summary>
        /// 임시(엘리베이터)
        /// </summary>
        public int? ELE_TIME { get; set; }

        /// <summary>
        /// 임시(집결지엘리베이터근처)
        /// </summary>
        public int? ELE_A_TIME { get; set; }

        /// <summary>
        /// 임시(집결지)
        /// </summary>
        public int? G_TIME { get; set; }

        /// <summary>
        /// 건물간이동시간
        /// </summary>
        public int? BET_TIME { get; set; }

        /// <summary>
        /// 이송수단 요율(걸어서)
        /// </summary>
        public int? WORK_RR { get; set; }

        /// <summary>
        /// 이송수단 요율(침대)
        /// </summary>
        public int? BED_RR { get; set;}

        /// <summary>
        /// 이송수단 요율(이동카)
        /// </summary>
        public int? MOV_RR { get; set; }

        /// <summary>
        /// 이송수단 요율(기타)
        /// </summary>
        public int? ETC_RR { get; set; }

        /// <summary>
        /// 미배정시간
        /// </summary>
        public int? ACCTIME { get; set; }

        /// <summary>
        /// 예약배정시간
        /// </summary>
        public int? RESTIME { get; set; }

        /// <summary>
        /// 묶음배정 요율
        /// </summary>
        public int? BTIME_RR { get; set; }

        /// <summary>
        /// 이송수단 요율(휠체어)
        /// </summary>
        public int? WH_RR { get; set; }

        /// <summary>
        /// 임시
        /// </summary>
        public string? MAUTOFLAG { get; set; }

        /// <summary>
        /// 예약가능시간
        /// </summary>
        public int? RESV_TIME { get; set; }

        /// <summary>
        /// 메시지CNT
        /// </summary>
        public int? MSG_CNT { get; set; }

        /// <summary>
        /// 이송시놓등(R: RED, Y: YELLOW, G: GREEN)
        /// </summary>
        public string? SIGN { get; set; }
    }
}

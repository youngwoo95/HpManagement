namespace HpManagement.DBModel
{
    /// <summary>
    /// SMS 발송내역 테이블
    /// </summary>
    public class SmsHistoryModel
    {
        /// <summary>
        /// 호출부서
        /// </summary>
        public string? CALLDEPT { get; set; }

        /// <summary>
        /// 원본SMS 메시지ID
        /// </summary>
        public string? PCMP_MSG_ID { get; set; }

        /// <summary>
        /// 호출시각
        /// </summary>
        public string? CALLTIME { get; set; }

        /// <summary>
        /// 완료일시
        /// </summary>
        public string? ENDTIME { get; set; }

        /// <summary>
        /// FROM 부서
        /// </summary>
        public string? FROMDEPT { get; set; }

        /// <summary>
        /// 수신번호
        /// </summary>
        public string? RSVPHNNO { get; set; }

        /// <summary>
        /// FROM 부서명
        /// </summary>
        public string? FROMDEPTNM { get; set; }

        /// <summary>
        /// 내용
        /// </summary>
        public string? MSG { get; set; }

        /// <summary>
        /// 재호출여부
        /// </summary>
        public string? RECALLYN { get; set; }

        /// <summary>
        /// 발송성공여부
        /// </summary>
        public string? SENTYN { get; set; }
        
        /// <summary>
        /// 이송업무구분
        /// </summary>
        public string? GUBUN { get; set; }

        /// <summary>
        /// 메시지
        /// </summary>
        public string? CMP_MSG_ID { get; set; }

        public string? REQUEST_YN { get; set; }
    }
}

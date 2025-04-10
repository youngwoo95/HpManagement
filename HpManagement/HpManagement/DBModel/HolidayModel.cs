namespace HpManagement.DBModel
{
    /// <summary>
    /// 휴일 정보 테이블
    /// </summary>
    public class HolidayModel
    {
        /// <summary>
        /// 휴일일자
        /// </summary>
        public DateTime DT { get; set; }
        
        /// <summary>
        /// 휴일설명
        /// </summary>
        public string? DT_DESC { get; set; }

        /// <summary>
        /// 등록일자
        /// </summary>
        public DateTime? REG_DT { get; set; }

        /// <summary>
        /// 등록자
        /// </summary>
        public string? REG_ID { get; set; }
    }
}

namespace HpManagement.DBModel
{
    /// <summary>
    /// 처방정보 테이블
    /// </summary>
    public class OrdCdModel
    {
        /// <summary>
        /// 처방코드
        /// </summary>
        public string ORD_CD { get; set; } = null!;

        /// <summary>
        /// 처방명
        /// </summary>
        public string ORD_NM { get; set; } = null!;

        /// <summary>
        /// 업무우선순위
        /// </summary>
        public int? ORD_SEQ { get; set; }

        /// <summary>
        /// 사용여부
        /// </summary>
        public string? STATUS { get; set; }

        /// <summary>
        /// 등록일
        /// </summary>
        public DateTime? RDATE { get; set; }
    }
}

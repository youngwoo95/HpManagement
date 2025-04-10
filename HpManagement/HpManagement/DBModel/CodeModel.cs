namespace HpManagement.DBModel
{
    /// <summary>
    /// 코드정보 테이블
    /// </summary>
    public class CodeModel
    {
        /// <summary>
        /// 그룹코드
        /// </summary>
        public string GRPCODE { get; set; } = null!;

        /// <summary>
        /// 코드
        /// </summary>
        public string CODE { get; set; } = null!;

        /// <summary>
        /// 코드명
        /// </summary>
        public string CODENM { get; set; } = null!;

        /// <summary>
        /// 코드설명
        /// </summary>
        public string? DESCRIPTION { get; set; }
        
        /// <summary>
        /// 순번
        /// </summary>
        public string? ORD { get; set; }

        /// <summary>
        /// 사용여부
        /// </summary>
        public string? STATUS { get; set; }

        /// <summary>
        /// 등록일
        /// </summary>
        public DateOnly? RDATE { get; set; }
    }
}

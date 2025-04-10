namespace HpManagement.DBModel
{
    /// <summary>
    /// 이송업무 유형정보 테이블
    /// </summary>
    public class BizTpModel
    {
        /// <summary>
        /// 업무 유형코드
        /// </summary>
        public string BIZTYPE { get; set; } = null!;

        /// <summary>
        /// 업무유형 명
        /// </summary>
        public string? BIZNM { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? AUTOACC { get; set; }

        /// <summary>
        /// 순번
        /// </summary>
        public string? ORD { get; set; }

        /// <summary>
        /// 등록자
        /// </summary>
        public string? USERID { get; set; }

        /// <summary>
        /// 등록일
        /// </summary>
        public DateTime? RDATE { get; set; }
    }
}

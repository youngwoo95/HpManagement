namespace HpManagement.DBModel
{
    /// <summary>
    /// 그룹코드 정보 테이블
    /// </summary>
    public class GrpCodeModel
    {
        /// <summary>
        /// 그룹코드
        /// </summary>
        public string GRPCODE { get; set; } = null!;

        /// <summary>
        /// 그룹코드명
        /// </summary>
        public string GRPCODENM { get; set; } = null!;

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

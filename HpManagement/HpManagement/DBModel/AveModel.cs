namespace HpManagement.DBModel
{
    /// <summary>
    /// 집결지 정보
    /// </summary>
    public class AveModel
    {
        /// <summary>
        /// 순번
        /// </summary>
        public int? SEQ { get; set; }

        /// <summary>
        /// 섹터코드
        /// </summary>
        public string? SECTOR { get; set; }

        /// <summary>
        /// 부서코드
        /// </summary>
        public string? DEPTCD { get; set; }

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

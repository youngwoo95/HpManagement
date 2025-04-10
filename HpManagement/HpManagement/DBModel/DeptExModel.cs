namespace HpManagement.DBModel
{
    /// <summary>
    /// 예외부서 정보 테이블
    /// </summary>
    public class DeptExModel
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
        public DateOnly? RDATE { get; set; }

    }
}

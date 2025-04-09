namespace HpManagement.DBModel
{
    /// <summary>
    /// 세부부서 정보
    /// </summary>
    public class DeptDetailModel
    {
        /// <summary>
        /// 상위부서 코드
        /// </summary>
        public string UP_DPRT_CD { get; set; } = null!;

        /// <summary>
        /// 임시부서 코드
        /// </summary>
        public string? MID_DPRT_CD { get; set; }

        /// <summary>
        /// 부서코드
        /// </summary>
        public string DPRT_CD { get; set; } = null!;

        /// <summary>
        /// 출발지 여부
        /// </summary>
        public string? FROM_YN { get; set; }

        /// <summary>
        /// 도착지 여부
        /// </summary>
        public string? TO_YN { get; set; }

        /// <summary>
        /// 정렬 순서
        /// </summary>
        public string? SEQ { get; set; }
    }
}

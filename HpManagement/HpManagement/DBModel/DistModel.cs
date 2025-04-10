namespace HpManagement.DBModel
{
    /// <summary>
    /// 부서간 거리정보 테이블
    /// </summary>
    public class DistModel
    {
        /// <summary>
        /// 출발지
        /// </summary>
        public string? FROMDEPT { get; set; }

        /// <summary>
        /// 도착지
        /// </summary>
        public string? TODEPT { get; set; }

        /// <summary>
        /// 소요시간
        /// </summary>
        public int? LTIME { get; set; }
    }
}

namespace HpManagement.DBModel
{
    /// <summary>
    /// 부서정보
    /// </summary>
    public class DeptModel
    {
        /// <summary>
        /// 부서코드
        /// </summary>
        public string DRPT_CD { get; set; } = null!;

        /// <summary>
        /// ?
        /// </summary>
        public string? STSS_DPRT_NM { get; set; }

        /// <summary>
        /// 부서명
        /// </summary>
        public string? KORN_DPRT_NM { get; set; }

        /// <summary>
        /// 약어부서코드
        /// </summary>
        public string? ABRV_DPRT_CD { get; set; }

        /// <summary>
        /// 연락처
        /// </summary>
        public string? PHNNO { get; set; }

        /// <summary>
        /// 조직구분코드
        /// </summary>
        public string? MDCR_GRP_DVSN_CD { get; set; }

        /// <summary>
        /// 건물코드
        /// </summary>
        public string? LCDV_CD { get; set; }

        /// <summary>
        /// 층
        /// </summary>
        public string? FLOR_NO { get; set; }

        /// <summary>
        /// 방향코드
        /// </summary>
        public string? DRCN_CD { get; set; }

        /// <summary>
        /// 순번
        /// </summary>
        public string? MCDP_SEQ { get; set; }

        /// <summary>
        /// 수정일
        /// </summary>
        public DateTime? LAST_UPDT_DT { get; set; }

        /// <summary>
        /// 사용여부
        /// </summary>
        public string? USE_YN { get; set; }
    }
}

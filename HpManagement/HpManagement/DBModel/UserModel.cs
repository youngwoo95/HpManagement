namespace HpManagement.DBModel
{
    /// <summary>
    /// 사용자정보 테이블
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// 사용자 ID
        /// </summary>
        public string EMNO { get; set; } = null!;

        /// <summary>
        /// 사용자 명
        /// </summary>
        public string? EMPY_NM { get; set; }

        /// <summary>
        /// 부서코드
        /// </summary>
        public string? DPRT_CD { get; set; }

        /// <summary>
        /// 전화번호
        /// </summary>
        public string? CMPN_TLNO { get; set; }

        /// <summary>
        /// 수정일자
        /// </summary>
        public DateTime? LAST_UPDT_DT { get; set; }

        /// <summary>
        /// 사용여부
        /// </summary>
        public string? STATUS { get; set; }

        /// <summary>
        /// 패스워드
        /// </summary>
        public string? PASSWD { get; set; }
    }
}

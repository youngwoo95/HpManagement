namespace HpManagement.DBModel.DBDTO
{
    /// <summary>
    /// 로그인 쿼리 결과 DTO
    /// </summary>
    public class LoginDbDto
    {
        /// <summary>
        /// 로그인 ID
        /// </summary>
        public string? USERID { get; set; }

        /// <summary>
        /// 비밀번호
        /// </summary>
        public string? PASSWD { get; set; }

        /// <summary>
        /// 사용자 명
        /// </summary>
        public string? USERNM { get; set; }

        /// <summary>
        /// 전화번호
        /// </summary>
        public string? PHNNO { get; set; }

        /// <summary>
        /// 관리자 유형
        /// </summary>
        public string? PERMISSION { get; set; }

        /// <summary>
        /// 부서코드
        /// </summary>
        public string? DEPTCD { get; set; }

        /// <summary>
        /// 등록일자
        /// </summary>
        public DateTime? RDATE { get; set; }

        /// <summary>
        /// 해지일자
        /// </summary>
        public DateTime? CDATE { get; set; }

        /// <summary>
        /// 관리자
        /// </summary>
        public string? SECTOR { get; set; }
    }
}

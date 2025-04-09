namespace HpManagement.DBModel
{
    public class AdminModel
    {
        /// <summary>
        /// 사용자 ID
        /// </summary>
        public string? USERID { get; set; }

        /// <summary>
        /// 패스워드
        /// </summary>
        public string? PASSWD { get; set; }

        /// <summary>
        /// 사용자명
        /// </summary>
        public string? USERNM { get; set; }

        /// <summary>
        /// 전화번호
        /// </summary>
        public string? PHNNO { get; set; }

        /// <summary>
        /// 관리자유형
        /// </summary>
        public string? PERMISSION { get; set; } = "X";

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
        public string? SECTOR { get; set; } = "X";
    }
}

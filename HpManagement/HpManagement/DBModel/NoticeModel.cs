namespace HpManagement.DBModel
{
    /// <summary>
    /// 공지사항 테이블
    /// </summary>
    public class NoticeModel
    {
        /// <summary>
        /// 색인번호
        /// </summary>
        public int IDX { get; set; }

        /// <summary>
        /// 우선순위
        /// </summary>
        public string FLAG { get; set; } = null!;

        /// <summary>
        /// 제목
        /// </summary>
        public string TITLE { get; set; } = null!;

        /// <summary>
        /// 내용
        /// </summary>
        public string CONTENTS { get; set; } = null!;

        /// <summary>
        /// 등록일자
        /// </summary>
        public DateTime? CDATE { get; set; }

        /// <summary>
        /// 작성자
        /// </summary>
        public string? USERID { get; set; }
    }
}

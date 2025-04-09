namespace HpManagement
{
    public class ResponseModel<T>
    {
        /// <summary>
        /// 데이터 내용
        /// </summary>
        public T? data { get; set; }

        /// <summary>
        /// 상태코드
        /// </summary>
        public int code { get; set; }
    }
}

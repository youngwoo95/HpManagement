using System.Text.RegularExpressions;

namespace HpManagement.Helpers
{
    /// <summary>
    /// 패스워드 유효성 검증 Helper Class
    /// </summary>
    public class Validator
    {
        /// <summary>
        /// 패스워드 유효성 검증
        /// 1. 공백 X
        /// 2. 길이 8 보다 크고 20보다 작아야함
        /// 영숫자+특수문자 조합
        /// 동일 문자 (영+숫자) 4회 연속
        /// </summary>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public static bool passwordValidator(string passWord)
        {
            if(String.IsNullOrEmpty(passWord) || ContainsWhitespace(passWord))
            {
                /* 넘어온 값이 없거나 or 공백이 포함되어있음 */
                return false;
            }

            if(passWord.Length < 8 || passWord.Length > 20)
            {
                /* 길이 조건을 만족하지 못함. */
                return false;
            }

            // 영문, 숫자 + 특수문자 조합 검사
            // - [a-zA-z0-9] 와 [!,@,#,$,%,^,&,*,?,_,~] 중 적어도 하나씩 포함
            var RegexCheck = new Regex(
                 @"([a-zA-Z0-9].*[!,@,#,$,%,^,&,*,?,_,~])" +
            @"|([!,@,#,$,%,^,&,*,?,_,~].*[a-zA-Z0-9])");

            if(!RegexCheck.IsMatch(passWord))
            {
                /* 특수문자 포함안됨 */
                return false;
            }

            // 동일 문자(영숫자, 언더바 포함) 4회 연속 금지
            var repeatCheck = new Regex(@"(\w)\1\1\1");
            if(repeatCheck.IsMatch(passWord))
            {
                /* 4회 넘어감 */
                return false;
            }

            // 동일 문자 4회 연속 금지
            var repeatAny = new Regex(@"(.)\1\1\1");
            if(repeatAny.IsMatch(passWord))
            {
                /* 동일 문자가 4회 넘어감 */
                return false;
            }

            /* 모두 통과하면 true */
            return true;
        }

        private static bool ContainsWhitespace(string s)
        {
            return s.Any(char.IsWhiteSpace);
        }
    }
}

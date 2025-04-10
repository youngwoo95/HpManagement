using System.Security.Cryptography;
using System.Text;

namespace HpManagement.Helpers
{
    /// <summary>
    /// 암호화 관련 Helper Class
    /// </summary>
    public class CipherUtil
    {
        /// <summary>
        /// 입력 문자열을 SHA-256 해시로 변환하고, 16진수 문자열로 반환한다.
        /// </summary>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public static string EncryptSHA256(string passWord)
        {
            // SHA256 해시 알고리즘 인스턴스 생성
            using (var sha = SHA256.Create())
            {
                // 입력 문자열을 바이트로 변환 후 해시 계산
                byte[] hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(passWord));

                // 바이트 배열을 2자리 16진수 문자열로 변환
                var sb = new StringBuilder();
                foreach(byte b  in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}

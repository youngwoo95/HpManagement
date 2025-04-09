using HpManagement.DBModel;
using HpManagement.DTO;

namespace HpManagement.Repository.Login
{
    public interface ILoginRepository
    {
        /// <summary>
        /// 관리자정보 가져오기
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task<AdminModel> GetAdminInfoAsync(string userid);
    }
}

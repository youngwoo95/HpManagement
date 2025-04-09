using Dapper;
using HpManagement.DBModel;
using System.Data;

namespace HpManagement.Repository.Login
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbConnection DbConnection;

        public LoginRepository(IDbConnection _dbconnection)
        {
            this.DbConnection = _dbconnection;
        }

        public async Task<AdminModel> GetAdminInfoAsync(string userid)
        {
            try
            {
                string sql = "SELECT * FROM stss_admin";
                var result = await DbConnection.QueryFirstOrDefaultAsync<AdminModel>(sql);

                return result;
            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}

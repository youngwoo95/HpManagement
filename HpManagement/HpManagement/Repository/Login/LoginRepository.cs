using Dapper;
using HpManagement.DBModel;
using HpManagement.DBModel.DBDTO;
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

        public async Task<LoginDbDto> GetLoginAsync(string userid)
        {
            try
            {
                string sql = @"SELECT USERID, PASSWD, USERNM, PHNNO, IFNULL(PERMISSION,'X') AS PERMISSION, '' as DEPTCD, RDATE, CDATE, SECTOR " +
                    "FROM STSS_ADMIN " +
                    "WHERE USERID = @UserId";


                var result = await DbConnection.QueryFirstOrDefaultAsync<LoginDbDto>(sql, new { UserId = userid });
                return result;

            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}

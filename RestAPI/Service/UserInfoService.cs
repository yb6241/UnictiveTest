using Dapper;
using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Models;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RestAPI.Service
{
    public class UserInfoService : IUserInfoService
    {
        private readonly DbContextClass _dbContext;
        public UserInfoService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserInfo> GetUserInfo(string email, string password)
        {
            var procedureName = "Usp_GetUserInfo";
            var parameters = new DynamicParameters();
            parameters.Add("email", email, DbType.String, ParameterDirection.Input);
            parameters.Add("password", password, DbType.String, ParameterDirection.Input);

            using (var connection = _dbContext.CreateConnection())
            {
                var userInfo = await connection.QueryFirstOrDefaultAsync<UserInfo>
                    (procedureName, parameters, commandType: CommandType.StoredProcedure);
                return userInfo;
            }
        }
    }
}

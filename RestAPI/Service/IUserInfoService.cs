using RestAPI.Models;

namespace RestAPI.Service
{
    public interface IUserInfoService
    {
        public Task<UserInfo> GetUserInfo(string email, string password);
    }
}

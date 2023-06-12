using RestAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RestAPI.Service
{
    public interface IMemberService
    {
        public Task<IEnumerable<Member>> GetMember();
        public Task<Member> GetMemberById(int Id);
        public Task<Member> GetMemberByEmail(string Email);
        public Task AddMember(Member member);
        public Task UpdateMember(int Id, Member member);
        public Task DeleteMember(int Id);
        public Task AddNewHobby(List<MemberHobby> hobby);
        public Task UpdateHobby(List<MemberHobby> hobby);
    }
}

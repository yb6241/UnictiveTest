using RestAPI.Data;
using RestAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Dapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;

namespace RestAPI.Service
{
    public class MemberService : IMemberService
    {
        private readonly DbContextClass _dbContext;

        public MemberService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Member>> GetMember()
        {
            var procedureName = "Usp_GetMemberList";

            using (var connection = _dbContext.CreateConnection())
            {
                var memberDict = new Dictionary<int, Member>();
                var members = await connection.QueryAsync<Member, MemberHobby, Member>(
                    procedureName, (member, hobby) =>
                    {
                        if (!memberDict.TryGetValue(member.Id, out var currentMember))
                        {
                            currentMember = member;
                            memberDict.Add(currentMember.Id, currentMember);
                        }
                        currentMember.Hobby.Add(hobby);
                        return currentMember;
                    }, commandType: CommandType.StoredProcedure
                );
                return members.Distinct().ToList();
            }
        }

        public async Task<Member> GetMemberById(int Id)
        {
            var procedureName = "Usp_GetMemberByID";
            var parameters = new DynamicParameters();
            parameters.Add("Id", Id, DbType.Int32, ParameterDirection.Input);

            using (var connection = _dbContext.CreateConnection())
            {
                var memberDict = new Dictionary<int, Member>();
                var members = await connection.QueryAsync<Member, MemberHobby, Member>(
                    procedureName, (member, hobby) =>
                    {
                        if (!memberDict.TryGetValue(member.Id, out var currentMember))
                        {
                            currentMember = member;
                            memberDict.Add(currentMember.Id, currentMember);
                        }
                        currentMember.Hobby.Add(hobby);
                        return currentMember;
                    }, parameters, commandType: CommandType.StoredProcedure
                );
                return members.Distinct().FirstOrDefault();
            }
        }

        public async Task<Member> AddMember(Member member)
        {
            var procedureName = "Usp_AddNewMember";
            var parameters = new DynamicParameters();
            parameters.Add("Nama", member.Nama, DbType.String);
            parameters.Add("Email", member.Email, DbType.String);
            parameters.Add("Phone", member.Phone, DbType.String);
            using (var connection = _dbContext.CreateConnection())
            {
                var Id = await connection.QuerySingleAsync<int>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var hobby = AddHobby(member.Hobby);
             
                var addMember = new Member
                {
                    Id = Id,
                    Nama = member.Nama,
                    Email = member.Email,
                    Phone = member.Phone,
                    Hobby = member.Hobby
                };

                return addMember;
            }
        }

        public async Task<Member> AddHobby(Member member)
        {
            var procedureName = "Usp_AddNewMember";
            var parameters = new DynamicParameters();
            parameters.Add("Nama", member.Nama, DbType.String);
            parameters.Add("Email", member.Email, DbType.String);
            parameters.Add("Phone", member.Phone, DbType.String);
            using (var connection = _dbContext.CreateConnection())
            {
                var Id = await connection.QuerySingleAsync<int>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                var hobby = AddHobby(member.Hobby);

                var addMember = new Member
                {
                    Id = Id,
                    Nama = member.Nama,
                    Email = member.Email,
                    Phone = member.Phone,
                    Hobby = member.Hobby
                };

                return addMember;
            }
        }

        public async Task UpdateMember(int Id, Member member)
        {
            var procedureName = "Usp_UpdateMember";
            var parameters = new DynamicParameters();
            parameters.Add("Id", Id, DbType.Int32);
            parameters.Add("Nama", member.Nama, DbType.String);
            parameters.Add("Email", member.Email, DbType.String);
            parameters.Add("Phone", member.Phone, DbType.String);
            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task DeleteMember(int Id)
        {
            var procedureName = "Usp_UpdateMember";
            var parameters = new DynamicParameters();
            parameters.Add("Id", Id, DbType.Int32);
            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}

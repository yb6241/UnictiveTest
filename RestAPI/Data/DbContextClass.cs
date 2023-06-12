using RestAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Emit;
using Microsoft.Data.SqlClient;
using System.Data;

namespace RestAPI.Data
{
    public class DbContextClass : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DbContextClass(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}

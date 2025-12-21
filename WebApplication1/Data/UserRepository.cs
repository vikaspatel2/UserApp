using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class UserRepository
    {
        private readonly string _connectionString;
        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Users> GetAllUsers()
        {
            var users = new List<Users>();
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("Usp_GetAllUsers", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new Users
                        {
                            Id = reader["Id"].ToString(), // Because Id from IdentityUser is string
                            UserName = reader["UserName"].ToString(),
                            Email = reader["Email"].ToString(),
                            PasswordHash = reader["PasswordHash"].ToString(),
                            Role = reader["Role"].ToString(),
                            CreateUid = reader["createuid"] as int?,
                            CreateDt = reader["createdt"] as DateTime?,
                            LModifyBy = reader["lmodifyby"] as int?,
                            LModifyDt = reader["lmodifydt"] as DateTime?,
                            DelUid = reader["deluid"] as int?,
                            DelDt = reader["deldt"] as DateTime?
                        });
                    }
                }
            }
            return users;
        }
    }
}

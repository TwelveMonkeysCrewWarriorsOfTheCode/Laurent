using ADOLibrary;
using KravMagaAPI_DAL.Models_DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KravMagaAPI_DAL.Services_DAL
{
    internal class LogInServiceDAL
    {
        private readonly string _connectionString;

        public LogInServiceDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        private Connection ToLogIn() => new(_connectionString);

        public BeLoggedModelDAL Converter(SqlDataReader reader)
        {
            return new BeLoggedModelDAL
            {
                Id = (int)reader["Id"],
                Email = reader["Email"].ToString(),
                LastName = reader["LastName"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                AutorisationID = (int)reader["AutorisationID"]
            };
        }

        public BeLoggedModelDAL LogIn(LogInModelDAL logIn)
        {
            Command cmd = new("PasswordVerification", true);
            cmd.AddParameter("email", logIn.Email);
            cmd.AddParameter("password", logIn.Password);

            try
            {
                return ToLogIn().ExecuteReader(cmd, Converter).FirstOrDefault(); ;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

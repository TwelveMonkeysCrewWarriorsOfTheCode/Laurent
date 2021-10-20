using ADOLibrary;
using AdoptDevDAL.Interfaces;
using AdoptDevDAL.Models.Security;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptDevDAL.Services
{
    public class LogInService : ILoginService
    {
        private readonly string _connectionString;

        public LogInService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        private Connection ToLogIn() => new(_connectionString);

        public BeLoggedModel Converter(SqlDataReader reader)
        {
            return new BeLoggedModel
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                IsOwner = Convert.ToBoolean(reader["IsOwner"])
            };
        }

        public BeLoggedModel LogIn(LogInModel logIn)
        {
            Command cmd = new("LogIn", true);
            cmd.AddParameter("Email", logIn.Email);
            cmd.AddParameter("Password", logIn.Password);

            try
            {
                return ToLogIn().ExecuteReader(cmd, Converter).FirstOrDefault();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }          
        }
    }
}

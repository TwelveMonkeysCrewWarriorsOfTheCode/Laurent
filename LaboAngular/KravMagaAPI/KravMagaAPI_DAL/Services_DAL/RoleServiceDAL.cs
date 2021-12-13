using ADOLibrary;
using KravMagaAPI_DAL.Interfaces_DAL;
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
    internal class RoleServiceDAL : ICRUDServiceDAL<RoleModelDAL>
    {
        private readonly string _connectionString;

        public RoleServiceDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        private Connection ToLogIn() => new(_connectionString);

        public RoleModelDAL Converter(SqlDataReader reader)
        {
            return new RoleModelDAL
            {
                Id = (int)reader["Id"],
                RoleName = reader["Role"].ToString(),
            };
        }

        public void Create(RoleModelDAL member)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RoleModelDAL> GetAll()
        {
            Command cmd = new("RoleGetAll", true);

            try
            {
                return ToLogIn().ExecuteReader(cmd, Converter);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public RoleModelDAL GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(RoleModelDAL model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}


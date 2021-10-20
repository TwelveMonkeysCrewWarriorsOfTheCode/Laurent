using ADOLibrary;
using AdoptDevDAL.Interfaces;
using AdoptDevDAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptDevDAL.Services
{
    public class UserSkillService : ICRUDService<UserSkillModel>
    {
        private readonly string _connectionString;

        public UserSkillService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        private Connection ToLogIn() => new(_connectionString);

        public UserSkillModel Converter(SqlDataReader reader)
        {
            return new UserSkillModel
            {
                Id = (int)reader["Id"],
                SkillId = (int)reader["SkillId"],
                UserId = (int)reader["UserId"]
            };
        }

        public UserSkillModel CreateIdReturn(UserSkillModel model)
        {
            throw new NotImplementedException();
        }

        public void Create(UserSkillModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserSkillModel> GetAll()
        {
            Command cmd = new("UserSkillGetAll", true);

            try
            {
                return ToLogIn().ExecuteReader(cmd, Converter);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public UserSkillModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserSkillModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

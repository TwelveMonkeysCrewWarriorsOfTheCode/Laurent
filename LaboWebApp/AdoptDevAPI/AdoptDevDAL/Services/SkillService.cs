using ADOLibrary;
using AdoptDevDAL.Interfaces;
using AdoptDevDAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AdoptDevDAL.Services
{
    public class SkillService : ICRUDService<SkillModel>
    {
        private readonly string _connectionString;

        public SkillService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        private Connection ToLogIn() => new(_connectionString);

        public SkillModel Converter(SqlDataReader reader)
        {
            return new SkillModel
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                Description = reader["Description"].ToString(),
                CategoryId = (int)reader["CategoryId"]
            };
        }

        public SkillModel CreateIdReturn(SkillModel model)
        {
            throw new NotImplementedException();
        }

        public void Create(SkillModel skill)
        {
            Command cmd = new("SkillRegister", true);
            cmd.AddParameter("Name", skill.Name);
            cmd.AddParameter("Description", skill.Description);
            cmd.AddParameter("CategoryId", skill.CategoryId);
            
            try
            {
                ToLogIn().ExecuteNonQuery(cmd);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<SkillModel> GetAll()
        {
            Command cmd = new("SkillGetAll", true);

            try
            {
                return ToLogIn().ExecuteReader(cmd, Converter);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public SkillModel GetById(int id)
        {
            Command cmd = new("SkillGetById", true);
            cmd.AddParameter("Id", id);
            try
            {
                return ToLogIn().ExecuteReader(cmd, Converter).FirstOrDefault();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(SkillModel skill)
        {
            Command cmd = new("SkillUpdate", true);
            cmd.AddParameter("Name", skill.Name);
            cmd.AddParameter("Description", skill.Description);
            cmd.AddParameter("CategoryId", skill.CategoryId);

            try
            {
                ToLogIn().ExecuteNonQuery(cmd);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(int id)
        {
            Command cmd = new("SkillDelete", true);
            cmd.AddParameter("Id", id);

            try
            {
                ToLogIn().ExecuteNonQuery(cmd);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

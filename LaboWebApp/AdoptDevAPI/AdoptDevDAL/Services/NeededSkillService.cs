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
    public class NeededSkillService : ICRUDService<NeededSkillModel>
    {
        private readonly string _connectionString;

        public NeededSkillService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        private Connection ToLogIn() => new(_connectionString);

        public NeededSkillModel Converter(SqlDataReader reader)
        {
            return new NeededSkillModel
            {
                Id = (int)reader["Id"],
                ContractId = (int)reader["ContractId"],
                SkillId = (int)reader["SkillId"],
            };
        }

        public NeededSkillModel CreateIdReturn(NeededSkillModel model)
        {
            throw new NotImplementedException();
        }

        public void Create(NeededSkillModel neededSkill)
        {
            Command cmd = new("NeededSkillCreate", true);
            cmd.AddParameter("ContractId", neededSkill.ContractId);
            cmd.AddParameter("SkillId", neededSkill.SkillId);

            try
            {
                ToLogIn().ExecuteNonQuery(cmd);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<NeededSkillModel> GetAll()
        {
            Command cmd = new("NeededSkillGetAll", true);

            try
            {
                return ToLogIn().ExecuteReader(cmd, Converter);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public NeededSkillModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(NeededSkillModel neededSkill)
        {
            Command cmd = new("NeededSkillUpdate", true);
            cmd.AddParameter("Id", neededSkill.Id);
            cmd.AddParameter("ContractId", neededSkill.ContractId);
            cmd.AddParameter("SkillId", neededSkill.SkillId);

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
            Command cmd = new("NeededSkillDelete", true);
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

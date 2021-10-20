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
    public class ListService : IListService
    {
        private readonly string _connectionString;

        public ListService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        private Connection ToLogIn() => new(_connectionString);

        public NeededSkillModel NeededSkillConverter(SqlDataReader reader)
        {
            NeededSkillModel neededSkillModel = new();
            neededSkillModel.ContractId = (int)reader["ContractId"];
            neededSkillModel.SkillId = (int)reader["SkillId"];
            return neededSkillModel;
        }
                
        public IEnumerable<NeededSkillModel> SkillNameGetByContractId(int id)
        {
            Command cmd = new("NeededSkillGetByContractId", true);
            cmd.AddParameter("Id", id);
            try
            {
                return ToLogIn().ExecuteReader(cmd, NeededSkillConverter);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

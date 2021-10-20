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
    public class ContractService : ICRUDService<ContractModel>
    {
        private readonly string _connectionString;

        public ContractService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        private Connection ToLogIn() => new(_connectionString);

        public ContractModel Converter(SqlDataReader reader)
        {
            ContractModel contractModel = new();
            contractModel.Id = (int)reader["Id"];
            contractModel.Description = reader["Description"].ToString();
            contractModel.Price = Convert.ToSingle(reader["Price"]);
            contractModel.DeadLine = Convert.ToDateTime(reader["DeadLine"]);
            contractModel.OwnerId = (int)reader["OwnerId"];
            contractModel.DevId = (reader["DevId"] == DBNull.Value) ? null : (int)reader["DevId"];
            return contractModel;
        }

        public ContractModel CreateIdReturn(ContractModel contract)
        {
            Command cmd = new("ContractCreate", true);
            cmd.AddParameter("Description", contract.Description);
            cmd.AddParameter("Price", contract.Price);
            cmd.AddParameter("DeadLine", contract.DeadLine);
            cmd.AddParameter("OwnerId", contract.OwnerId);
            cmd.AddParameter("DevId", contract.DevId);

            try
            {
                return ToLogIn().ExecuteReader(cmd, Converter).FirstOrDefault();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Create(ContractModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContractModel> GetAll()
        {
            Command cmd = new("ContractGetAll", true);

            try
            {
                return ToLogIn().ExecuteReader(cmd, Converter);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public ContractModel GetById(int id)
        {
            Command cmd = new("ContractGetById", true);
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

        public void Update(ContractModel contract)
        {
            Command cmd = new("ContractUpdate", true);
            cmd.AddParameter("Id", contract.Id);
            cmd.AddParameter("Description", contract.Description);
            cmd.AddParameter("Price", contract.Price);
            cmd.AddParameter("DeadLine", contract.DeadLine);
            cmd.AddParameter("DevId", contract.DevId);

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
            Command cmd = new("ContractDelete", true);
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

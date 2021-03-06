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
    public class BeltServiceDAL : ICRUDServiceDAL<BeltModelDAL>
    {
        private readonly string _connectionString;

        public BeltServiceDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        private Connection ToLogIn() => new(_connectionString);

        public BeltModelDAL Converter(SqlDataReader reader)
        {
            return new BeltModelDAL
            {
                Id = (int)reader["Id"],
                BeltColor = reader["BeltColor"].ToString(),
            };
        }

        public void Create(BeltModelDAL member)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BeltModelDAL> GetAll()
        {
            Command cmd = new("BeltGetAll", true);

            try
            {
                return ToLogIn().ExecuteReader(cmd, Converter);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public BeltModelDAL GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(BeltModelDAL belt)
        {
            Command cmd = new("BeltUpdate", true);
            cmd.AddParameter("Id", belt.Id);
            cmd.AddParameter("BeltColor", belt.BeltColor);

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
            throw new NotImplementedException();
        }
    }
}

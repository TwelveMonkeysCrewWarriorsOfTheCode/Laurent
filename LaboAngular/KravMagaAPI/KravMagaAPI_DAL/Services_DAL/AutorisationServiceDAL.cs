using ADOLibrary;
using KravMagaAPI_DAL.Interfaces_DAL;
using KravMagaAPI_DAL.Models_DAL;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace KravMagaAPI_DAL.Services_DAL
{
    internal class AutorisationServiceDAL : ICRUDServiceDAL<AutorisationModelDAL>
    {
        private readonly string _connectionString;

        public AutorisationServiceDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        private Connection ToLogIn() => new(_connectionString);

        public AutorisationModelDAL Converter(SqlDataReader reader)
        {
            return new AutorisationModelDAL
            {
                Id = (int)reader["Id"],
                AutorisationType = reader["AutorisationType"].ToString(),
            };
        }


        public void Create(AutorisationModelDAL member)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AutorisationModelDAL> GetAll()
        {
            Command cmd = new("AutorisationGetAll", true);

            try
            {
                return ToLogIn().ExecuteReader(cmd, Converter);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public AutorisationModelDAL GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AutorisationModelDAL model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

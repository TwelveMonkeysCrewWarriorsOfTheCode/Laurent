using ADOLibrary;
using KravMagaAPI_DAL.Interfaces_DAL;
using KravMagaAPI_DAL.Models_DAL;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace KravMagaAPI_DAL.Services_DAL
{
    public class AuthorisationServiceDAL : ICRUDServiceDAL<AuthorisationModelDAL>
    {
        private readonly string _connectionString;

        public AuthorisationServiceDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        private Connection ToLogIn() => new(_connectionString);

        public AuthorisationModelDAL Converter(SqlDataReader reader)
        {
            return new AuthorisationModelDAL
            {
                Id = (int)reader["Id"],
                AuthorisationType = reader["AuthorisationType"].ToString(),
            };
        }


        public void Create(AuthorisationModelDAL member)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorisationModelDAL> GetAll()
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

        public AuthorisationModelDAL GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AuthorisationModelDAL model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

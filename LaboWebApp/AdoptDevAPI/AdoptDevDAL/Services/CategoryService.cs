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
    public class CategoryService : ICRUDService<CategoryModel>
    {
        private readonly string _connectionString;

        public CategoryService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        private Connection ToLogIn() => new(_connectionString);

        public CategoryModel Converter(SqlDataReader reader)
        {
            return new CategoryModel
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
            };
        }

        public CategoryModel CreateIdReturn(CategoryModel model)
        {
            throw new NotImplementedException();
        }

        public void Create(CategoryModel category)
        {
            Command cmd = new("CategoryRegister", true);
            cmd.AddParameter("Name", category.Name);

            try
            {
                ToLogIn().ExecuteNonQuery(cmd);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<CategoryModel> GetAll()
        {
            Command cmd = new("CategoryGetAll", true);

            try
            {
                return ToLogIn().ExecuteReader(cmd, Converter);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public CategoryModel GetById(int id)
        {
            Command cmd = new("CategoryGetById", true);
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

        public void Update(CategoryModel category)
        {
            Command cmd = new("SkillUpdate", true);
            cmd.AddParameter("Name", category.Name);

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
            Command cmd = new("CategoryDelete", true);
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

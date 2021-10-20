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
    public class UserService : ICRUDService<UserModel>
    {
        private readonly string _connectionString;

        public UserService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        private Connection ToLogIn() => new(_connectionString);

        public UserModel Converter(SqlDataReader reader)
        {
            return new UserModel
            {
                Id = (int)reader["Id"],
                Email = reader["Email"].ToString(),
                Name = reader["Name"].ToString(),
                Phone = reader["Phone"].ToString(),
                IsOwner = Convert.ToBoolean(reader["IsOwner"])
            };
        }

        public UserModel CreateIdReturn(UserModel model)
        {
            throw new NotImplementedException();
        }

        public void Create(UserModel user)
        {
            Command cmd = new("Register", true);
            cmd.AddParameter("Email", user.Email);
            cmd.AddParameter("Password", user.Password);
            cmd.AddParameter("Name", user.Name);
            cmd.AddParameter("Phone", user.Phone);
            cmd.AddParameter("Isowner", user.IsOwner);
                        
            try
            {
                ToLogIn().ExecuteNonQuery(cmd);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<UserModel> GetAll()
        {
            Command cmd = new("UserGetAll", true);

            try
            {
                return ToLogIn().ExecuteReader(cmd, Converter);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public UserModel GetById(int id)
        {
            Command cmd = new("UserGetById", true);
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

        public void Update(UserModel user)
        {
            Command cmd = new("UserUpdate", true);
            cmd.AddParameter("Id", user.Id);
            cmd.AddParameter("Email", user.Email);
            cmd.AddParameter("Name", user.Name);
            cmd.AddParameter("Phone", user.Phone);
            cmd.AddParameter("Isowner", user.IsOwner);

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
            Command cmd = new("UserDelete", true);
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

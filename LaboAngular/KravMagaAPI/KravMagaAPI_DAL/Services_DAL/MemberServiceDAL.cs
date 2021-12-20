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
    public class MemberServiceDAL : IMemberServiceDAL<MemberModelDAL>
    {
        private readonly string _connectionString;

        public MemberServiceDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        private Connection ToLogIn() => new(_connectionString);

        public MemberModelDAL Converter(SqlDataReader reader)
        {
            return new MemberModelDAL
            {
                Id = (int)reader["Id"],
                Email = reader["Email"].ToString(),
                LastName = reader["LastName"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                BirthDay = Convert.ToDateTime(reader["BirthDay"]),
                Adress = reader["Adress"].ToString(),
                Phone = reader["Phone"].ToString(),
                //Subscription = Convert.ToBoolean(reader["Subscription"]),
                LastDateSubscription = Convert.ToDateTime(reader["LastDateSubscription"]),
                AuthorisationID = (int)reader["AuthorisationId"],
                RoleID = (int)reader["RoleId"],
                BeltID = (int)reader["BeltId"],
                //AutorisationType = reader["AutorisationType"].ToString(),
                //Role = reader["Role"].ToString(),
                //BeltColor = reader["BeltColor"].ToString(),
            };
        }

        public BeLoggedModelDAL ConverterBeLogged(SqlDataReader reader)
        {
            return new BeLoggedModelDAL
            {
                Id = (int)reader["Id"],
                Email = reader["Email"].ToString(),
                LastName = reader["LastName"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                AuthorisationID = (int)reader["AuthorisationID"]
            };
        }

        public BeLoggedModelDAL Create(MemberModelDAL member)
        {
            Command cmd = new("MemberRegister", true);
            cmd.AddParameter("email", member.Email);
            cmd.AddParameter("password", member.Password);
            cmd.AddParameter("LastName", member.LastName);
            cmd.AddParameter("FirstName", member.FirstName);
            cmd.AddParameter("Birthday", member.BirthDay);
            cmd.AddParameter("Adress", member.Adress);
            cmd.AddParameter("Phone", member.Phone);

            try
            {
                return ToLogIn().ExecuteReader(cmd, ConverterBeLogged).FirstOrDefault();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }

        }

        public IEnumerable<MemberModelDAL> GetAll()
        {
            Command cmd = new("MemberGetAll", false);

            try
            {
                return ToLogIn().ExecuteReader(cmd, Converter);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(MemberModelDAL member)
        {
            Command cmd = new("MemberUpdate", true);
            cmd.AddParameter("Id", member.Id);
            cmd.AddParameter("LastDateSubscription", member.LastDateSubscription);
            cmd.AddParameter("RoleId", member.RoleID);
            cmd.AddParameter("BeltId", member.BeltID);

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
            Command cmd = new("MemberDelete", true);
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

        public MemberModelDAL GetById(int id)
        {
            Command cmd = new("MemberGetByIdAdmin", true);
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

        /*public MemberModelDAL Login(string email, string password)
        {
            Command cmd = new("MemberLogin", true);
            cmd.AddParameter("Email", email);
            cmd.AddParameter("Password", password);
            try
            {
                return ToLogIn().ExecuteReader(cmd, Converter).FirstOrDefault();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }*/
    }
}

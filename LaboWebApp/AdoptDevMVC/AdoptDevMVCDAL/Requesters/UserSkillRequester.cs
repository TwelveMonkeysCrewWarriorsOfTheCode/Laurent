using AdoptDevMVCDAL.Interfaces;
using AdoptDevMVCDAL.Models;
using AdoptDevMVCDAL.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AdoptDevMVCDAL.Requesters
{
    public class UserSkillRequester : ICRUDRequester<UserSkillModelDAL>
    {
        private Requester _request = new();

        public UserSkillModelDAL CreateIdReturn(UserSkillModelDAL model)
        {
            throw new NotImplementedException();
        }

        public void Create(UserSkillModelDAL model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserSkillModelDAL> GetAll()
        {
            using (HttpResponseMessage message = _request.client.GetAsync("api/UserSkill").Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<IEnumerable<UserSkillModelDAL>>(json);
            }
        }

        public UserSkillModelDAL GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserSkillModelDAL userSkill)
        {
            string jsonBody = JsonConvert.SerializeObject(userSkill);

            using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage message = _request.client.PutAsync("api/UserSkill", content).Result)
                {
                    if (!message.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException(message.StatusCode.ToString());
                    }
                    string json = message.Content.ReadAsStringAsync().Result;
                }
            }
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

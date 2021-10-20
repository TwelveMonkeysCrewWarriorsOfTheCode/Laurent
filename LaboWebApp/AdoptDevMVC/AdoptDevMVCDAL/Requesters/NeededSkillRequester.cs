using AdoptDevMVCDAL.Interfaces;
using AdoptDevMVCDAL.Models;
using AdoptDevMVCDAL.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdoptDevMVCDAL.Requesters
{
    public class NeededSkillRequester : ICRUDRequester<NeededSkillModelDAL>
    {
        private Requester _request = new();

        public NeededSkillModelDAL CreateIdReturn(NeededSkillModelDAL model)
        {
            throw new NotImplementedException();
        }

        public void Create(NeededSkillModelDAL neededSkill)
        {
            string jsonBody = JsonConvert.SerializeObject(neededSkill);

            using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage message = _request.client.PostAsync("api/NeededSkill", content).Result)
                {
                    if (!message.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException();
                    }
                    Console.WriteLine("Enregistrement ok");
                }
            }
        }

        public IEnumerable<NeededSkillModelDAL> GetAll()
        {
            using (HttpResponseMessage message = _request.client.GetAsync("api/NeededSkill").Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<IEnumerable<NeededSkillModelDAL>>(json);
            }
        }

        public NeededSkillModelDAL GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(NeededSkillModelDAL neededSkill)
        {
            string jsonBody = JsonConvert.SerializeObject(neededSkill);

            using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage message = _request.client.PutAsync("api/NeededSkill", content).Result)
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
            using (HttpResponseMessage message = _request.client.DeleteAsync("api/NeededSkill/" + id).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }
            }
        }
    }
}

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
    public class SkillRequester : ICRUDRequester<SkillModelDAL>
    {
        private Requester _request = new();

        public SkillModelDAL CreateIdReturn(SkillModelDAL model)
        {
            throw new NotImplementedException();
        }

        public void Create(SkillModelDAL model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SkillModelDAL> GetAll()
        {
            using (HttpResponseMessage message = _request.client.GetAsync("api/Skill").Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<IEnumerable<SkillModelDAL>>(json);
            }
        }

        public SkillModelDAL GetById(int id)
        {
            using (HttpResponseMessage message = _request.client.GetAsync("api/Skill/" + id).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<SkillModelDAL>(json);
            }
        }

        public void Update(SkillModelDAL model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

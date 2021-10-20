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
    public class ContractRequester : ICRUDRequester<ContractModelDAL>
    {
        private Requester _request = new();

        public ContractModelDAL CreateIdReturn(ContractModelDAL contract)
        {
            string jsonBody = JsonConvert.SerializeObject(contract);

            using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage message = _request.client.PostAsync("api/Contract", content).Result)
                {
                    if (!message.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException();
                    }
                    string json = message.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<ContractModelDAL>(json);
                }
            }
        }

        public void Create(ContractModelDAL model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContractModelDAL> GetAll()
        {
            using (HttpResponseMessage message = _request.client.GetAsync("api/Contract").Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<IEnumerable<ContractModelDAL>>(json);
            }
        }

        public ContractModelDAL GetById(int id)
        {
            using (HttpResponseMessage message = _request.client.GetAsync("api/Contract/" + id).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<ContractModelDAL>(json);
            }
        }
        
        public void Update(ContractModelDAL contract)
        {
            string jsonBody = JsonConvert.SerializeObject(contract);

            using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage message = _request.client.PutAsync("api/Contract", content).Result)
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
            using (HttpResponseMessage message = _request.client.DeleteAsync("api/Contract/" + id).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }
            }
        }
    }
}

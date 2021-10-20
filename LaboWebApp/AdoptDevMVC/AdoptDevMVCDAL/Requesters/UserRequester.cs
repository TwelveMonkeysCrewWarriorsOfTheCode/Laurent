using AdoptDevMVCDAL.Interfaces;
using AdoptDevMVCDAL.Models;
using AdoptDevMVCDAL.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AdoptDevMVCDAL.Services
{
    public class UserRequester : ICRUDRequester<UserModelDAL> 
    {
        private Requester _request = new();

        public UserModelDAL CreateIdReturn(UserModelDAL model)
        {
            throw new NotImplementedException();
        }

        public void Create(UserModelDAL user)
        {
            string jsonBody = JsonConvert.SerializeObject(user);

            using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage message = _request.client.PostAsync("api/User", content).Result)
                {
                    if (!message.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException();
                    }
                    Console.WriteLine("Enregistrement ok");
                }
            }
        }

        public IEnumerable<UserModelDAL> GetAll()
        {
            using (HttpResponseMessage message = _request.client.GetAsync("api/User").Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<IEnumerable<UserModelDAL>>(json);
            }
        }

        public UserModelDAL GetById(int id)
        {
            using (HttpResponseMessage message = _request.client.GetAsync("api/User/" + id).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<UserModelDAL>(json);
            }
        }

        public void Update(UserModelDAL user)
        {
            string jsonBody = JsonConvert.SerializeObject(user);

            using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage message = _request.client.PutAsync("api/User", content).Result)
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
            throw new System.NotImplementedException();
        }
    }
}

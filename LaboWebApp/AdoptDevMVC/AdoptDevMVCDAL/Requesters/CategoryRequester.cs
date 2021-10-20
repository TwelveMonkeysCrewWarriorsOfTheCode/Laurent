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
    public class CategoryRequester : ICRUDRequester<CategoryModelDAL>
    {
        private Requester _request = new();

        public CategoryModelDAL CreateIdReturn(CategoryModelDAL model)
        {
            throw new NotImplementedException();
        }

        public void Create(CategoryModelDAL user)
        {
            string jsonBody = JsonConvert.SerializeObject(user);

            using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage message = _request.client.PostAsync("api/Category", content).Result)
                {
                    if (!message.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException();
                    }
                    Console.WriteLine("Enregistrement ok");
                }
            }
        }

        public IEnumerable<CategoryModelDAL> GetAll()
        {
            using (HttpResponseMessage message = _request.client.GetAsync("api/Category").Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<IEnumerable<CategoryModelDAL>>(json);
            }
        }

        public CategoryModelDAL GetById(int id)
        {
            using (HttpResponseMessage message = _request.client.GetAsync("api/Category/" + id).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<CategoryModelDAL>(json);
            }
        }

        public void Update(CategoryModelDAL category)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

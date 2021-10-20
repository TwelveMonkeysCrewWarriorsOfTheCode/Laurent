using AdoptDevMVCDAL.Interfaces;
using AdoptDevMVCDAL.Models;
using AdoptDevMVCDAL.Models.Security;
using AdoptDevMVCDAL.Tools;
using Newtonsoft.Json;
using System.Collections;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace AdoptDevMVCDAL.Requesters
{
    public class SecurityRequester : ISecurityRequester
    {
        private Requester _requester = new();
        private ICRUDRequester<UserModelDAL> _userService;

        public SecurityRequester(ICRUDRequester<UserModelDAL> userService)
        {
            _userService = userService;
        }

        public BeLoggedModelDAL LogIn(LogInModelDAL logIn)
        {
            string jsonBody = JsonConvert.SerializeObject(logIn);

            using (HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
            {
                using (HttpResponseMessage message = _requester.client.PostAsync("api/Security", content).Result)
                {
                    if (!message.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException();
                    }
                    string json = message.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<BeLoggedModelDAL>(json);
                }
            }
        }

        public bool EmailExist(UserModelDAL register)
        {
            return (_userService.GetAll().Where(r => r.Email == register.Email).Select(r => r).FirstOrDefault() == null) ? false : true;      
        }

    }
}

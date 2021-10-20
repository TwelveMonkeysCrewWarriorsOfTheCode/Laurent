using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdoptDevMVCDAL.Tools
{
    public class Requester
    {
        private const string url = "https://localhost:44382/";

        public HttpClient client;

        public Requester()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
        }
    }
}

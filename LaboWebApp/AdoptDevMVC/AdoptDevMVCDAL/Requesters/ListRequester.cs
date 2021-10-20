using AdoptDevMVCDAL.Interfaces;
using AdoptDevMVCDAL.Models;
using AdoptDevMVCDAL.Tools;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace AdoptDevMVCDAL.Requesters
{
    public class ListRequester : IListRequester
    {
        private Requester _request = new();
        private readonly ICRUDRequester<ContractModelDAL> _contractRequester;
        private readonly ICRUDRequester<CategoryModelDAL> _categoryRequester;

        public ListRequester(ICRUDRequester<ContractModelDAL> contractRequester, ICRUDRequester<CategoryModelDAL> categoryRequester)
        {
            _contractRequester = contractRequester;
            _categoryRequester = categoryRequester;
        }

        public IEnumerable<ContractModelDAL> GetByOwerId(int id) => _contractRequester.GetAll().Where(c => c.OwnerId == id).Select(c => c);

        public IEnumerable<ContractModelDAL> GetByDevId(int id) => _contractRequester.GetAll().Where(c => c.DevId == id).Select(c => c);

        public IEnumerable<NeededSkillModelDAL> SkillNameGetByContractId(int id)
        {
            using (HttpResponseMessage message = _request.client.GetAsync("api/NeededSkill/" + id).Result)
            {
                if (!message.IsSuccessStatusCode)
                {
                    throw new HttpRequestException();
                }

                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<IEnumerable<NeededSkillModelDAL>>(json);
            }
        }

        public CategoryModelDAL CategoryNameGetBySkillId(int id) => _categoryRequester.GetById(id);            
    }
}

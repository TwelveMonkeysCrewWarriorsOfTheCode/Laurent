using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptDevMVC.Models
{
    public class NeededSkillModel
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}

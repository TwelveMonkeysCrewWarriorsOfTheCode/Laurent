using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptDevMVC.Models
{
    public class ContractModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public DateTime DeadLine { get; set; }
        public int OwnerId { get; set; }
        public int? DevId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerEmail { get; set; }
        public string DevName { get; set; }
        public string DevEmail { get; set; }
        public string CategoryName { get; set; }
        public int SkillDBId  { get; set; }
        public int SkillFrontId { get; set; }
        public int SkillBackId { get; set; }
        public IEnumerable<NeededSkillModel> NeededSkillList { get; set; }
        public IEnumerable<UserModels.UserModel> DevList { get; set; }
        public IEnumerable<SkillModel> SkillList { get; set; }
        public IEnumerable<CategoryModel> CategoryList { get; set; }
    }
}

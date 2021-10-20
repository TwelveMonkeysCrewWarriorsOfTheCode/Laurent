using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptDevMVC.Models
{
    public class UserModels
    {
        public class UserModel
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public bool IsOwner { get; set; }
        }

        public class UserDisplayModel
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public bool IsOwner { get; set; }
            public IEnumerable<UserSkillModel> UserSkillList { get; set; }
        }

        public class UserEditModel
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public bool IsOwner { get; set; }
            public string Json { get; set; }
            public IEnumerable<UserSkillModel> UserSkillList { get; set; }
            public IEnumerable<SkillModel> SkillList { get; set; }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptDevDAL.Models
{
    public class UserSkillModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SkillId { get; set; }
    }
}

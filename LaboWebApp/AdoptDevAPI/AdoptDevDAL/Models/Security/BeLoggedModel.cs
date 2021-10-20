using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptDevDAL.Models.Security
{
    public class BeLoggedModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOwner { get; set; }
        public bool LogOk { get; set; } 
    }
}

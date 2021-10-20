using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptDevAPI.Models.Security
{
    public class BeLoggedModelAPI
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOwner { get; set; }
        public bool LogOk { get; set; }
    }
}

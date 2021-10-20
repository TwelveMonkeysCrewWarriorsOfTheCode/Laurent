using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptDevMVC.Models.Security
{
    public class BeLoggedModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserType { get; set; }
        public bool LogOk { get; set; }
    }
}

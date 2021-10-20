using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptDevDAL.Models
{
    public class ContractModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public DateTime DeadLine { get; set; }
        public int OwnerId { get; set; }
        public int? DevId { get; set; }
        //public string OwnerName { get; set; }
        //public string DevName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptDevMVC.Models.Security
{
    public class LogInModel
    {
        [Required(ErrorMessage = "Ce champs est requis !")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ce champs est requis !")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.?[A-Z])(?=.?[a-z])(?=.?[0-9])(?=.?[#?!@$ %^&*-=]).{8,20}$")]
        public string Password { get; set; }
    }
}

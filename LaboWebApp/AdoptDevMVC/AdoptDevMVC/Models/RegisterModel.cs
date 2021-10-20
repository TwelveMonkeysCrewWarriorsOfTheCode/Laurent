using System.ComponentModel.DataAnnotations;

namespace AdoptDevMVC.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Ce champs est requis !")]
        [MaxLength(50, ErrorMessage = "Le nombre maximum de caractère est de 50")]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Ce champs est requis !")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,20}$")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Ce champs est requis !")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,20}$")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Ce champs est requis !")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ce champs est requis !")]
        [RegularExpression(@"^0[0-9]{3}[/][0-9]{2}[.][0-9]{2}[.][0-9]{2}$")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Ce champs est requis !")]
        public bool IsOwner { get; set; }
    }
}

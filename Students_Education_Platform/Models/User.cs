using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Students_Education_Platform.Models
{
    public class User
    {
        [DisplayName("ID")]
        [Key]
        public int Id { get; set; }
        [DisplayName("User Name")]
        [Required(ErrorMessage = "Enter your name")]
        [RegularExpression("^[a-zA-Z0-9_-]{3,16}$",ErrorMessage ="Not Match UserName")]
        public string Name { get; set; }
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Emai must be valid")]
        public string Email { get; set; }
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password  is Required")]
        [MinLength(5, ErrorMessage = "Password Min Length is 5")]

        public string Password { get; set; }
        [DisplayName("confirmPassword")]
        [NotMapped]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password  is Required")]
        [MinLength(5, ErrorMessage = "Password Min Length is 5")]
        [Compare("Password", ErrorMessage = "Confirm Password not match password")]
        public string ConfirmPassword { get; set; }
    }
}

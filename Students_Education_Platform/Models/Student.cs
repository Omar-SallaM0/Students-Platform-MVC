using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Students_Education_Platform.Models
{
    public class Student
    {
        [DisplayName("ID")]
        [Key]
        public int Id { get; set; }
        [DisplayName("Student Name")]
        [Required(ErrorMessage = "Enter your name")]
        [MinLength(3, ErrorMessage = "Name Min Length is 3")]
        [MaxLength(50, ErrorMessage = "Name max length is 50")]
        public string Name { get; set; }
        [DisplayName("Student Age")]
        [Range(20, 60, ErrorMessage = "Age must be between 20 and 60")]
        public int Age { get; set; }
        [DisplayName("Student Address")]
        [StringLength(30, ErrorMessage = "Adress must be between 5 and 35", MinimumLength = 5)]
        public string Address { get; set; }
        [DisplayName("Student Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Emai must be valid")]
        public string Email { get; set; }
        [DisplayName("Student Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password  is Required")]
        [MinLength(5, ErrorMessage = "Password Min Length is 5")]

        public string Password { get; set; }
        [DisplayName("Student confirmPassword")]
        [NotMapped]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password  is Required")]
        [MinLength(5, ErrorMessage = "Password Min Length is 5")]
        [Compare("Password", ErrorMessage = "Confirm Password not match password")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Department")]
        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public virtual Department Department { get; set; }
    }
}

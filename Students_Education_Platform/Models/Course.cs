using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students_Education_Platform.Models
{
    public class Course
    {
        [DisplayName("ID")]
        [Key]
        public int Id { get; set; }

        [DisplayName("Course Name")]
        [Required(ErrorMessage = "Course Name is required")]
        [MinLength(3, ErrorMessage = "Course Name min length is 3")]
        [MaxLength(50, ErrorMessage = "Course Name max length is 50")]
        public string CourseName { get; set; }

        [DisplayName("Duration (Hours)")]
        [Range(1, 200, ErrorMessage = "Duration must be between 1 and 200 hours")]
        public int Duration { get; set; }

        [DisplayName("Department")]
        [ForeignKey("Department")]
        public int DeptId { get; set; }

        public virtual Department? Department { get; set; }

        public virtual ICollection<Exam> Exams { get; set; } = new HashSet<Exam>();
    }
}

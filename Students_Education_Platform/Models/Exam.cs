using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students_Education_Platform.Models
{
    public class Exam
    {
        [DisplayName("ID")]
        [Key]
        public int Id { get; set; }

        [DisplayName("Exam Title")]
        [Required(ErrorMessage = "Exam Title is required")]
        [MinLength(3, ErrorMessage = "Exam Title min length is 3")]
        [MaxLength(100, ErrorMessage = "Exam Title max length is 100")]
        public string Title { get; set; }

        [DisplayName("Exam Date")]
        [Required(ErrorMessage = "Exam Date is required")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [DisplayName("Full Mark")]
        [Range(10, 100, ErrorMessage = "Full Mark must be between 10 and 100")]
        public int FullMark { get; set; }

        [DisplayName("Course")]
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public virtual Course? Course { get; set; }
    }
}

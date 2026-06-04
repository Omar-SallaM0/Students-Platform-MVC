namespace Students_Education_Platform.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DeptName { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}

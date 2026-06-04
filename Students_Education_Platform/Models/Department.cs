namespace Final_Project_ITI.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DeptName { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}

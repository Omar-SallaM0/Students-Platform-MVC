using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace Students_Education_Platform.Models
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=OMAR;database=FinalProjectITI;trusted_connection=true;trustServerCertificate=true");
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var depts = new List<Department>
            {
                new Department { Id = 1, DeptName = "SOC" },
                new Department { Id = 2, DeptName = "Asp .NET" },
                new Department { Id = 3, DeptName = "IS" },
                new Department { Id = 4, DeptName = "Laravel" },
                new Department { Id = 5, DeptName = "Cyber Security" },
                new Department { Id = 6, DeptName = "CS" },
                new Department { Id = 7, DeptName = "Front-End" }

            };
            var emps = new List<Student>
            {
                new Student{Id=1,Name="omar",Age=20,Address="Cleopatra's Needle",Email = "omaraahmed00@example.com", Password = "opoppoop",DeptId=3},
                new Student{Id=2,Name="ahmed",Age=25,Address="Bold Street",Email = "ahmedomar@example.com", Password = "mkimki",DeptId=2},
                new Student{Id=3,Name="ziad",Age=26,Address="Kensington High Street",Email = "zizoali@example.com", Password = "mekky00",DeptId=1},
                new Student{Id=4,Name="osman",Age=20,Address="Covent Garden",Email = "mousa@example.com", Password = "00mekky",DeptId=4},
                new Student{Id=5,Name="ali",Age=18,Address="Station Road",Email = "osman@example.com", Password = "me00kky",DeptId=6},
                new Student{Id=6,Name="diaa",Age=22,Address="Church Lane",Email = "diaa@example.com", Password = "mekk00y",DeptId=5},
                new Student{Id=7,Name="Zidan",Age=32,Address="Jude Street",Email = "zidan@example.com", Password = "mek00ky",DeptId=7},
            };
            var users = new List<User>
            {
                new User{Id=1,Name="omar",Email = "omaraahmed7@example.com", Password = "99999999"},
                new User{Id=2,Name="marawan",Email = "marawan@example.com", Password = "00000000"}
            };

            modelBuilder.Entity<Department>().HasData(depts);
            modelBuilder.Entity<Student>().HasData(emps);
            modelBuilder.Entity<User>().HasData(users);

            var courses = new List<Course>
            {
                new Course { Id = 1, CourseName = "OOP", Duration = 40, DeptId = 2 },
                new Course { Id = 2, CourseName = "Database & SQL", Duration = 36, DeptId = 3 },
                new Course { Id = 3, CourseName = ".Net Basics", Duration = 30, DeptId = 4 },
                new Course { Id = 4, CourseName = "Network Security", Duration = 45, DeptId = 5 },
                new Course { Id = 5, CourseName = "HTML & CSS & JS", Duration = 50, DeptId = 7 }
            };

            var exams = new List<Exam>
            {
                new Exam { Id = 1, Title = "OOP Final Exam", Date = new DateTime(2025, 06, 15, 10, 0, 0), FullMark = 100, CourseId = 1 },
                new Exam { Id = 2, Title = "SQL Practical Exam", Date = new DateTime(2025, 06, 18, 12, 0, 0), FullMark = 50, CourseId = 2 },
                new Exam { Id = 3, Title = "Laravel Basic Quiz", Date = new DateTime(2025, 06, 20, 9, 0, 0), FullMark = 20, CourseId = 3 },
                new Exam { Id = 4, Title = "Network Security Midterm", Date = new DateTime(2025, 06, 22, 14, 0, 0), FullMark = 100, CourseId = 4 },
                new Exam { Id = 5, Title = "Front-End Integration Test", Date = new DateTime(2025, 06, 25, 11, 0, 0), FullMark = 100, CourseId = 5 }
            };

            modelBuilder.Entity<Course>().HasData(courses);
            modelBuilder.Entity<Exam>().HasData(exams);

            base.OnModelCreating(modelBuilder);
        }
    }
}

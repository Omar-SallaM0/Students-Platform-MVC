using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_ITI.Models
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
            var users=new List<User>
            {
                new User{Id=1,Name="omar",Email = "omaraahmed7@example.com", Password = "99999999"},
                new User{Id=2,Name="marawan",Email = "marawan@example.com", Password = "00000000"}
            };

            modelBuilder.Entity<Department>().HasData(depts);
            modelBuilder.Entity<Student>().HasData(emps);
            modelBuilder.Entity<User>().HasData(users);
            base.OnModelCreating(modelBuilder);
        }
    }
}

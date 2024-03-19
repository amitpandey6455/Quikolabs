using crudApi1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LoginPage1.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> option) : base(option)
        {

        }
        public DbSet<Student> tbl_Students { get; set; }

        public DbSet<Departments> tbl_Departments { get; set; }
        public DbSet<LoginDetails> LoginDetails { get; set; }
        public DbSet<GetAllStudentListByID> GetAllStudentListByID { get; set; }


        


    }
}

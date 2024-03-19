using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LoginPage1.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }

       
        public string Name { get; set; }


       
        public string? Fname { get; set; }

       
        public string Email { get; set; }

       
        public int? DepID { get; set; }

        public string? Mobile { get; set; }

        public string? Description { get; set; }

        [NotMapped]
        public string? Department { get; set; }


    }
}

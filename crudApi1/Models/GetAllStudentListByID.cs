using System.ComponentModel.DataAnnotations;

namespace LoginPage1.Models
{
    public class GetAllStudentListByID
    {
        public int id { get; set; }
        public string Name { get; set; }


        public string Fname { get; set; }

       
        public string Email { get; set; }

     
        public int DepID { get; set; }

        
        public string mobile { get; set; }

        public string Description { get; set; }
    }
}

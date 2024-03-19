using System.ComponentModel.DataAnnotations;

namespace crudApi1.Models
{
    public class LoginDetails
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public int TrailCount { get; set; }
    }
}

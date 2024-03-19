using LoginPage1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crudApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly StudentContext _context;


        public HomeController(StudentContext context)
        {
            _context = context;
        }


        [HttpPost("register")]
        [Authorize]
        public async Task<IActionResult> Register([FromBody] Student model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.ID == 0)
            {
                _context.tbl_Students.Add(model);
                await _context.SaveChangesAsync();
                return Ok("inserted");

            }
            else
            {
                _context.tbl_Students.Add(model);               
                await _context.SaveChangesAsync();                
                return Ok("updated");
            }
           


            return Ok("Failed");
        }

        
        [HttpGet]
        [Route("GetAllStudents")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {

            return await _context.tbl_Students.ToListAsync();
        }

        [Authorize]
        [HttpPost]
        [Route("DeleteStudent")]
        public string deleteStudent(int id)
        {
            try
            {
                if(id!=null)
                {
                    var s = _context.tbl_Students.Where(x => x.ID == id).FirstOrDefault();
                    if (s == null)
                    {
                        return ("id is invalid");
                    }
                    _context.tbl_Students.Remove(s);
                    _context.SaveChanges();
                }
                else
                {
                    return ("id is invalid");
                }
                

            }catch(Exception ex)
            {
                return ("failed");
            }

           


            return ("Deleted");
        }
        [Authorize]
        [HttpGet]
        [Route("GetDetailsWithAuth")]
        public string GetDetailsWithAuth()
        {

            return "Get details with auth";
        }

       
        [HttpGet]
        [Route("GetDetailsWithoutAuth")]
        public string GetDetailsWithoutAuth()
        {

            return "Get details without auth";
        }

    }
}

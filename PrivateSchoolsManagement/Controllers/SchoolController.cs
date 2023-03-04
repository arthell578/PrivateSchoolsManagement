using Microsoft.AspNetCore.Mvc;
using PrivateSchoolsManagement.Models;

namespace PrivateSchoolsManagement.Controllers
{
    [Route("api/schools")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateSchool(School school)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllSchools()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetSchoolById(int id)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSchool(int id, School school)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSchool(int id)
        {
            return Ok();
        }
    }

}

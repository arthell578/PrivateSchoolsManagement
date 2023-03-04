using Microsoft.AspNetCore.Mvc;
using PrivateSchoolsManagement.Models;
using PrivateSchoolsManagement.Services;

namespace PrivateSchoolsManagement.Controllers
{
    [Route("api/schools")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly SchoolService _schoolService;

        public SchoolController(SchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpPost]
        public async Task<ActionResult<School>> CreateSchool(School school)
        {
            await _schoolService.CreateSchoolAsync(school);

            return CreatedAtAction("GetSchool", new { id = school.Id }, school);
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

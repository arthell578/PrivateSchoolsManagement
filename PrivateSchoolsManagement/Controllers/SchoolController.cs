using Microsoft.AspNetCore.Mvc;
using PrivateSchoolsManagement.DTOs;
using PrivateSchoolsManagement.Models;
using PrivateSchoolsManagement.Services;

namespace PrivateSchoolsManagement.Controllers
{
    [Route("api/school")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly SchoolService _schoolService;

        public SchoolController(SchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpPost]
        public async Task<ActionResult<School>> CreateSchool(SchoolDTO schoolDTO)
        {
            await _schoolService.CreateSchoolAsync(schoolDTO);

            return CreatedAtAction("GetSchool", new { id = schoolDTO.Id }, schoolDTO);
        }


        [HttpGet]
        public async Task<ActionResult<List<SchoolDTO>>> GetAllSchools()
        {
            var schools = await _schoolService.GetAllSchoolsAsync();

            if (schools == null || schools.Count == 0)
            {
                return NoContent();
            }

            return Ok(schools);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolDTO>> GetSchoolById(int id)
        {
            var school = await _schoolService.GetSchoolByIdAsync(id);

            if (school == null)
            {
                return NoContent();
            }

            return Ok(school);
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

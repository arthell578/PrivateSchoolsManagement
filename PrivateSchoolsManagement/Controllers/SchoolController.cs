using Microsoft.AspNetCore.Mvc;
using PrivateSchoolsManagement.DTOs;
using PrivateSchoolsManagement.Exceptions;
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
        public async Task<IActionResult> UpdateSchool(int id, SchoolDTO schoolDTO)
        {
            try
            {
                await _schoolService.UpdateSchoolAsync(id, schoolDTO);

                var updatedSchool = await _schoolService.GetSchoolByIdAsync(id);

                return Ok(updatedSchool);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            try
            {
                await _schoolService.DeleteSchoolAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }

}

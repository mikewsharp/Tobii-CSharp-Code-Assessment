using edu_services.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using edu_services.Services;

namespace edu_services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }

        [HttpPost("teacher")]
        public IActionResult AddTeacher([FromBody] Teacher teacher)
        {
            try
            {
                if (teacher == null)
                {
                    return BadRequest();
                }
                ClassroomService._service.AddTeacher(teacher);
                return Ok(teacher);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("student")]
        public IActionResult AddStudent([FromBody] Student student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest();
                }
                ClassroomService._service.AddStudent(student);
                return Ok(student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("roster")]
        public IActionResult GetRoster()
        {
            try
            {
                var (teacher, students) = ClassroomService._service.GetRoster();
                var roster = new List<object> { teacher };
                roster.AddRange(students);
                return Ok(roster);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}

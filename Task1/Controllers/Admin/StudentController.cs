using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Admin.Students;
using Services.Services;
using Services.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Task1.Controllers.Admin
{
    
    public class StudentController : BaseController
    {

        private readonly IStudentService _studentService;

        private readonly ILogger<StudentController> _logger;

        public StudentController(IStudentService studentService, ILogger<StudentController> logger)
        {
            _studentService = studentService;
            _logger = logger;     
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("country get all is working");

            return Ok(await _studentService.GetAllAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
          
            return Ok(await _studentService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentCreateDto request)
        {
            await _studentService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), new { response = "Data successfully Created" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, StudentEditDto request)
        {
            await _studentService.EditAsync(id, request);

            return Ok(new { response = "Data successfully updated" });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery][Required] int id)
        {
            await _studentService.DeleteAsync(id);
            return Ok(new { response = "Data successfully deleted" });
        }
 

    }
}

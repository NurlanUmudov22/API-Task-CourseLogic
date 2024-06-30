using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Admin.Students;
using Services.DTOs.Admin.Teachers;
using Services.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Task1.Controllers.Admin
{
  
    public class TeacherController : BaseController
    {
        private readonly ITeacherService _teachService;

        private readonly ILogger<TeacherController> _logger;

        public TeacherController(ITeacherService teachService, ILogger<TeacherController> logger)
        {
            _teachService = teachService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("teacher get all is working");

            return Ok(await _teachService.GetAllAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            return Ok(await _teachService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeacherCreateDto request)
        {
            await _teachService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), new { response = "Data successfully Created" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, TeacherEditDto request)
        {
            await _teachService.EditAsync(id, request);

            return Ok(new { response = "Data successfully updated" });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery][Required] int id)
        {
            await _teachService.DeleteAsync(id);
            return Ok(new { response = "Data successfully deleted" });
        }
    }
}

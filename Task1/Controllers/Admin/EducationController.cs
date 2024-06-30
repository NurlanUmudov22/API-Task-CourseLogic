using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Admin.Educations;
using Services.DTOs.Admin.Students;
using Services.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Task1.Controllers.Admin
{
 
    public class EducationController : BaseController
    {
        private readonly IEducationService _eduService;

        private readonly ILogger<EducationController> _logger;

        public EducationController(IEducationService eduService, ILogger<EducationController> logger)
        {
            _eduService = eduService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("education get all is working");

            return Ok(await _eduService.GetAllAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            return Ok(await _eduService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EducationCreateDto request)
        {
            await _eduService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), new { response = "Data successfully Created" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, EducationEditDto request)
        {
            await _eduService.EditAsync(id, request);

            return Ok(new { response = "Data successfully updated" });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery][Required] int id)
        {
            await _eduService.DeleteAsync(id);
            return Ok(new { response = "Data successfully deleted" });
        }
    }
}

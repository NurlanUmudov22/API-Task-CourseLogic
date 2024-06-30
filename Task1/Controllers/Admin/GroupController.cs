using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Admin.Groups;
using Services.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Task1.Controllers.Admin
{
   
    public class GroupController : BaseController
    {
        private readonly ILogger<GroupController> _logger;
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService, ILogger<GroupController> logger)
        {
            _logger = logger;
            _groupService = groupService;         
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            _logger.LogInformation("country get all is working");
            return Ok(await _groupService.GetAllAsync());
           
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GroupCreateDto request)
        {
            await _groupService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), new { response = "Data successfully Created" });
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _groupService.GetByIdAsync(id));

        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery][Required] int id)
        {
            await _groupService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] GroupEditDto request)
        {
            await _groupService.EditAsync(id, request);

            return Ok();
        }

    }
}

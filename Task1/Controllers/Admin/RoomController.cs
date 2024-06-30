using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Admin.Rooms;
using Services.DTOs.Admin.Students;
using Services.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Task1.Controllers.Admin
{
    
    public class RoomController : BaseController
    {
        private readonly IRoomService _roomService;

        private readonly ILogger<RoomController> _logger;

        public RoomController(IRoomService roomService, ILogger<RoomController> logger)
        {
            _roomService = roomService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("room get all is working");

            return Ok(await _roomService.GetAllAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            return Ok(await _roomService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoomCreateDto request)
        {
            await _roomService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), new { response = "Data successfully Created" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, RoomEditDto request)
        {
            await _roomService.EditAsync(id, request);

            return Ok(new { response = "Data successfully updated" });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery][Required] int id)
        {
            await _roomService.DeleteAsync(id);
            return Ok(new { response = "Data successfully deleted" });
        }
    }
}

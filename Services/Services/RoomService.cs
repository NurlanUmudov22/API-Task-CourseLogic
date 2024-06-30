using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Repositories.Interfaces;
using Services.DTOs.Admin.Groups;
using Services.DTOs.Admin.Rooms;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public  class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<RoomService> _logger;


        public RoomService(IRoomRepository roomRepo, IMapper mapper, ILogger<RoomService> logger)
        {

            _roomRepo = roomRepo;
            _mapper = mapper;
            _logger = logger;

        }



        public async Task CreateAsync(RoomCreateDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            await _roomRepo.CreateAsync(_mapper.Map<Room>(model));
        }



        public async Task DeleteAsync(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("Id is null");
                throw new ArgumentNullException();
            }

            var existRoom = await _roomRepo.GetByIdAsync((int)id);

            if (existRoom == null)
            {
                _logger.LogWarning("data not found");

                throw new NullReferenceException();

            }
            _roomRepo.DeleteAsync(existRoom);
        }




        public async Task EditAsync(int? id, RoomEditDto model)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));

            var existRoom = await _roomRepo.GetByIdAsync((int)id);

            if (existRoom == null) throw new NullReferenceException();

            _mapper.Map(model, existRoom);

            await _roomRepo.EditAsync(existRoom);
        }




        public async Task<IEnumerable<RoomDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<RoomDto>>(await _roomRepo.GetAllAsync());
        }




        public async Task<RoomDto> GetByIdAsync(int? id)
        {
            if (id == null) throw new ArgumentNullException();

            var existRoom = await _roomRepo.GetByIdAsync((int)id);

            if (existRoom == null) throw new NullReferenceException();

            return _mapper.Map<RoomDto>(existRoom);
        }
    }

}

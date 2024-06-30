using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Repositories.Interfaces;
using Services.DTOs.Admin.Groups;
using Services.DTOs.Admin.Teachers;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public  class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teachRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<TeacherService> _logger;


        public TeacherService(ITeacherRepository teachRepo, IMapper mapper, ILogger<TeacherService> logger)
        {

            _teachRepo = teachRepo;
            _mapper = mapper;
            _logger = logger;

        }



        public async Task CreateAsync(TeacherCreateDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            await _teachRepo.CreateAsync(_mapper.Map<Teacher>(model));
        }



        public async Task DeleteAsync(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("Id is null");
                throw new ArgumentNullException();
            }

            var existGroup = await _teachRepo.GetByIdAsync((int)id);

            if (existGroup == null)
            {
                _logger.LogWarning("data not found");

                throw new NullReferenceException();

            }
            _teachRepo.DeleteAsync(existGroup);
        }




        public async Task EditAsync(int? id, TeacherEditDto model)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));

            var existGroup = await _teachRepo.GetByIdAsync((int)id);

            if (existGroup == null) throw new NullReferenceException();

            _mapper.Map(model, existGroup);

            await _teachRepo.EditAsync(existGroup);
        }




        public async Task<IEnumerable<TeacherDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<TeacherDto>>(await _teachRepo.GetAllAsync());
        }




        public async Task<TeacherDto> GetByIdAsync(int? id)
        {
            if (id == null) throw new ArgumentNullException();

            var existGroup = await _teachRepo.GetByIdAsync((int)id);

            if (existGroup == null) throw new NullReferenceException();

            return _mapper.Map<TeacherDto>(existGroup);
        }
    }

}

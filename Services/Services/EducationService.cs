using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Repositories.Interfaces;
using Services.DTOs.Admin.Educations;
using Services.DTOs.Admin.Groups;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public  class EducationService : IEducationService
    {
        private readonly IEducationRepository _eduRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<EducationService> _logger;


        public EducationService(IEducationRepository eduRepo, IMapper mapper, ILogger<EducationService> logger)
        {

            _eduRepo = eduRepo;
            _mapper = mapper;
            _logger = logger;

        }



        public async Task CreateAsync(EducationCreateDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            await _eduRepo.CreateAsync(_mapper.Map<Education>(model));
        }



        public async Task DeleteAsync(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("Id is null");
                throw new ArgumentNullException();
            }

            var existEdu = await _eduRepo.GetByIdAsync((int)id);

            if (existEdu == null)
            {
                _logger.LogWarning("data not found");

                throw new NullReferenceException();

            }
            _eduRepo.DeleteAsync(existEdu);
        }




        public async Task EditAsync(int? id, EducationEditDto model)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));

            var existEdu = await _eduRepo.GetByIdAsync((int)id);

            if (existEdu == null) throw new NullReferenceException();

            _mapper.Map(model, existEdu);

            await _eduRepo.EditAsync(existEdu);
        }




        public async Task<IEnumerable<EducationDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<EducationDto>>(await _eduRepo.GetAllAsync());
        }




        public async Task<EducationDto> GetByIdAsync(int? id)
        {
            if (id == null) throw new ArgumentNullException();

            var existEdu = await _eduRepo.GetByIdAsync((int)id);

            if (existEdu == null) throw new NullReferenceException();

            return _mapper.Map<EducationDto>(existEdu);
        }
    }

}

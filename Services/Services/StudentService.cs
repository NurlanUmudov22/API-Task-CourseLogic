using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Repositories.Interfaces;
using Services.DTOs.Admin.Groups;
using Services.DTOs.Admin.Students;
using Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _stuRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<StudentService> _logger;


        public StudentService(IStudentRepository stuRepo, IMapper mapper, ILogger<StudentService> logger)
        {

            _stuRepo = stuRepo;
            _mapper = mapper;
            _logger = logger;

        }



        public async Task CreateAsync(StudentCreateDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            await _stuRepo.CreateAsync(_mapper.Map<Student>(model));
        }



        public async Task DeleteAsync(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("Id is null");
                throw new ArgumentNullException();
            }

            var existStu = await _stuRepo.GetByIdAsync((int)id);

            if (existStu == null)
            {
                _logger.LogWarning("data not found");

                throw new NullReferenceException();

            }            
                _stuRepo.DeleteAsync(existStu);

            
        }




        public async Task EditAsync(int? id, StudentEditDto model)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));

            var existStu = await _stuRepo.GetByIdAsync((int)id);

            if (existStu == null) throw new NullReferenceException();

            _mapper.Map(model, existStu);

            await _stuRepo.EditAsync(existStu);
        }




        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<StudentDto>>(await _stuRepo.GetAllAsync());
        }




        public async Task<StudentDto> GetByIdAsync(int? id)
        {
            if (id == null) throw new ArgumentNullException();

            var existStu = await _stuRepo.GetByIdAsync((int)id);

            if (existStu == null) throw new NullReferenceException();

            return _mapper.Map<StudentDto>(existStu);
        }
    }
}

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
        public Task CreateAsync(StudentCreateDto model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(int? id, StudentEditDto model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StudentDto> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}

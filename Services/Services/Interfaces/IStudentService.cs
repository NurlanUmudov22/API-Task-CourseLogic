using Services.DTOs.Admin.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public  interface IStudentService
    {

        Task<IEnumerable<StudentDto>> GetAllAsync();

        Task CreateAsync(StudentCreateDto model);

        Task<StudentDto> GetByIdAsync(int? id);

        Task DeleteAsync(int? id);

        Task EditAsync(int? id, StudentEditDto model);
    }
}

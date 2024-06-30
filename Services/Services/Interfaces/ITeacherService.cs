using Services.DTOs.Admin.Groups;
using Services.DTOs.Admin.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public  interface ITeacherService
    {
        Task<IEnumerable<TeacherDto>> GetAllAsync();

        Task CreateAsync(TeacherCreateDto model);

        Task<TeacherDto> GetByIdAsync(int? id);

        Task DeleteAsync(int? id);

        Task EditAsync(int? id, TeacherEditDto model);
    }
}

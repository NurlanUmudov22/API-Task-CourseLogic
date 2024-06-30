using Services.DTOs.Admin.Educations;
using Services.DTOs.Admin.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public  interface IEducationService
    {
        Task<IEnumerable<EducationDto>> GetAllAsync();

        Task CreateAsync(EducationCreateDto model);

        Task<EducationDto> GetByIdAsync(int? id);

        Task DeleteAsync(int? id);

        Task EditAsync(int? id, EducationEditDto model);
    }
}

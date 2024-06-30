using Services.DTOs.Admin.Groups;
using Services.DTOs.Admin.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.Interfaces
{
    public  interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetAllAsync();

        Task CreateAsync(RoomCreateDto model);

        Task<RoomDto> GetByIdAsync(int? id);

        Task DeleteAsync(int? id);

        Task EditAsync(int? id, RoomEditDto model);
    }
}

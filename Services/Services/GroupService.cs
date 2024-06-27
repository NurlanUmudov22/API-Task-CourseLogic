using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Repositories.Interfaces;
using Services.DTOs.Admin.Groups;
using Services.Services.Interfaces;


namespace Services.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<GroupService> _logger;


        public GroupService(IGroupRepository groupRepo, IMapper mapper, ILogger<GroupService> logger)
        {

            _groupRepo = groupRepo;
            _mapper = mapper;
            _logger = logger;

        }



        public async  Task CreateAsync(GroupCreateDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            await _groupRepo.CreateAsync(_mapper.Map<Group>(model));
        }









        public async  Task DeleteAsync(int? id)
        {
            if (id == null)
            {
                _logger.LogWarning("Id is null");
                throw new ArgumentNullException();
            }

            var existGroup = await _groupRepo.GetByIdAsync((int)id);

            if (existGroup == null)
            {
                _logger.LogWarning("data not found");

                throw new NullReferenceException();

            }
            _groupRepo.DeleteAsync(existGroup);
        }




        public async Task EditAsync(int? id, GroupEditDto model)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));

            var existGroup = await _groupRepo.GetByIdAsync((int)id);

            if (existGroup == null) throw new NullReferenceException();

            _mapper.Map(model, existGroup);

            await _groupRepo.EditAsync(existGroup);
        }




        public async  Task<IEnumerable<GroupDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<GroupDto>>(await _groupRepo.GetAllAsync());
        }




        public async  Task<GroupDto> GetByIdAsync(int? id)
        {
            if (id == null) throw new ArgumentNullException();

            var existGroup = await _groupRepo.GetByIdAsync((int)id);

            if (existGroup == null) throw new NullReferenceException();

            return _mapper.Map<GroupDto>(existGroup);
        }
    }
}

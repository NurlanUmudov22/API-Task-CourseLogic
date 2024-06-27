using AutoMapper;
using Domain.Entities;
using Services.DTOs.Admin.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    public  class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GroupCreateDto, Group>();
        }
    }
}

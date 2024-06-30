using AutoMapper;
using Domain.Entities;
using Repository.Repositories;
using Services.DTOs.Admin.Educations;
using Services.DTOs.Admin.Groups;
using Services.DTOs.Admin.Rooms;
using Services.DTOs.Admin.Students;
using Services.DTOs.Admin.Teachers;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

            CreateMap<Group, GroupDto>(); /*.ForMember(dest => dest.EducationName, opt => opt.MapFrom(src => src.Education.Name));
*/
            CreateMap<GroupEditDto, Group>();


            CreateMap<StudentCreateDto, Student>();

            CreateMap<Student, StudentDto>();

            CreateMap<StudentEditDto, Student>();


            CreateMap<EducationCreateDto, Education>();

            CreateMap<Education, EducationDto>();

            CreateMap<EducationEditDto, Education>();


            CreateMap<RoomCreateDto, Room>();

            CreateMap<Room, RoomDto>();

            CreateMap<RoomEditDto, Room>();


            CreateMap<TeacherCreateDto, Teacher>();

            CreateMap<Teacher, TeacherDto>();

            CreateMap<TeacherEditDto, Teacher>();
        }
    }
}

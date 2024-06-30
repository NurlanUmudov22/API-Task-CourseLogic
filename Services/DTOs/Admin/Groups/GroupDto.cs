using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Admin.Groups
{
    public  class GroupDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        //public List<GroupStudent> GroupStudents { get; set; }

        //public List<GroupTeacher> GroupTeachers { get; set; }

      

        //public string  EducationName { get; set; }

        //public string RoomName { get; set; }
    }
}

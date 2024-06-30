using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Admin.Groups
{
    public class GroupEditDto
    {
        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<GroupStudent> GroupStudents { get; set; }

        public List<GroupTeacher> GroupTeachers { get; set; }
    

        public Education Education { get; set; }

        public Room Room { get; set; }
    }
}

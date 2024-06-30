﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Admin.Teachers
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public int Salary { get; set; }

        public int Age { get; set; }

        //public List<GroupTeacher> GroupTeachers { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Admin.Students
{
    public  class StudentCreateDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public int GroupId { get; set; }

    }
}

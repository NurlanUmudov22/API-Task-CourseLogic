﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Admin.Groups
{
    public  class GroupCreateDto
    {
        public string  Name { get; set; }
        public int Capacity { get; set; }

        //public string Education { get; set; }

        //public Room Room { get; set; }

    }
}

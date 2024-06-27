﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GroupTeacher : BaseEntity
    {
        public int Id { get; set; }


        [ForeignKey(nameof(Group))]

        public int GroupId { get; set; }

        [ForeignKey(nameof(Teacher))]

        public int TeacherId { get; set; }


        public Teacher Teacher { get; set; }

        public Group Group { get; set; }
    }
}
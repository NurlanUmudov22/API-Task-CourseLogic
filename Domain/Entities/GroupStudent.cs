﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GroupStudent
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Group))]

        public int GroupId { get; set; }

        [ForeignKey(nameof(Student))]

        public int StudentId { get; set; }


        public Group  Group { get; set; }

        public Student Student { get; set; }
    }
}
 
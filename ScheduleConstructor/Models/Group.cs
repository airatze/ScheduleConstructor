﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleConstructor.Models
{
    public class Group
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleConstructor.Models
{
    public class Lesson
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}

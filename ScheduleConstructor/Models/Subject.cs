using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleConstructor.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public int LessonID { get; set; }
        public int GroupID { get; set; }
        public int AudienceNumber { get; set; }
        public int NumberInDay { get; set; }
        public int NumberInWeek { get; set; }
        public Audience Audience { get; set; }
        public Lesson Lesson { get; set; }
        public Group Group { get; set; }
    }
}

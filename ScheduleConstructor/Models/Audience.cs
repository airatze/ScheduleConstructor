using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleConstructor.Models
{
    public class Audience
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Number { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}

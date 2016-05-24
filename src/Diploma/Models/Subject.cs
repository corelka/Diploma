using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Models
{
    public class Subject
    {
        public Subject()
        {
            Groups = new HashSet<SubjectGroups>();
            Teachers = new HashSet<SubjectTeacher>();
            Schedules = new HashSet<Schedule>();
        }
        public int SubjectId { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<SubjectGroups> Groups { get; set; }
        public virtual ICollection<SubjectTeacher> Teachers { get; set; }
        public virtual ICollection<Schedule> Schedules{ get; set; }      
    }
}

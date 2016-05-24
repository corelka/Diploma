using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Models
{
    public class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
            Teachers = new HashSet<TeacherGroup>();
            Subjects = new HashSet<SubjectGroups>();
            Schedules = new HashSet<Schedule>();
        }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        //public Student Head { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<TeacherGroup> Teachers { get; set; }
        public virtual ICollection<SubjectGroups> Subjects { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}

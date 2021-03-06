﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Models
{
    public class Teacher
    {
        public Teacher()
        {
            Groups = new HashSet<TeacherGroup>();
            Subjects = new HashSet<SubjectTeacher>();
            Schedules = new HashSet<Schedule>();
        }
        public int TeacherId { get; set; }
        public virtual ICollection<TeacherGroup> Groups { get; set; }
        public virtual ICollection<SubjectTeacher> Subjects { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}

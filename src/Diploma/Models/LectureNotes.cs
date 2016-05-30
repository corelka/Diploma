using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Models
{
    public class LectureNotes
    {
        public LectureNotes()
        {

        }
        public LectureNotes(ViewModels.LectureNoteViewModel lct, Teacher teach)
        {
            Name = lct.Name;
            PubDate = DateTime.Now;
            Teacher = teach;
            Course = lct.Course;
        }
        public int LectureNotesId { get; set; }
        public string Name { get; set; }        
        public DateTime PubDate { get; set; }
        public string Attachment { get; set; }
        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        public int Course { get; set; }
    }
}

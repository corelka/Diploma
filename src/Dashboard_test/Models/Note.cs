using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_test.Models
{
    public class Note
    {
        public Note()
        {
            Groups = new HashSet<Group>();
        }
        public int NoteId { get; set; }
        public string Text { get; set; }
        public int TeacherId { get; set; }
        public ICollection<Group> Groups;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.ViewModels
{
    public class CreateEventViewModel
    {
        public string UserName { get; set; }
        public string title { get; set; }
        public bool allDay { get; set; }       
        public DateTime start { get; set; }        
        public DateTime end { get; set; }        
        public string url { get; set; }        
        public bool editable { get; set; }
    }
}
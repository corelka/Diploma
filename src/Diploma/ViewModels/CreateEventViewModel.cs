﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.ViewModels
{
    public class CreateEventViewModel
    {
        public string title { get; set; }
        public bool allDay { get; set; }       
        public string start { get; set; }        
        public string end { get; set; }        
        public string url { get; set; }        
        public bool editable { get; set; }
    }
}
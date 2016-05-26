using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Globalization;

namespace Diploma.Models
{
    public class CalendarEvent
    {
        public CalendarEvent() { }
        public CalendarEvent(ViewModels.CreateEventViewModel createEvent,string _UserName)
        {
            UserName = _UserName;
            title = createEvent.title;
            allDay = createEvent.allDay;
            start = Convert.ToDateTime(createEvent.start, new CultureInfo("en-US"));
            end = Convert.ToDateTime(createEvent.end, new CultureInfo("en-US"));
            url = createEvent.url;
            durationEditable = createEvent.editable;
            startEditable = createEvent.editable;
            editable = createEvent.editable;
        }
        
        public int id { get; set; }        
        public string UserName { get; set; }        
        public string title { get; set; }        
        public bool allDay { get; set; }        
        public DateTime start { get; set; }        
        public DateTime end { get; set; }        
        public string url { get; set; }        
        public string className { get; set; }        
        public bool editable { get; set; }        
        public bool startEditable { get; set; }        
        public bool durationEditable { get; set; }        
        public string rendering { get; set; }        
        public string color { get; set; }        
        public string backgroundColor { get; set; }        
        public string borderColor { get; set; }        
        public string textColor { get; set; }
    }
}

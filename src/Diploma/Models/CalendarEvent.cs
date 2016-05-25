using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Diploma.Models
{
    [DataContract]
    public class CalendarEvent
    {
        [IgnoreDataMember]
        public int id { get; set; }
        [IgnoreDataMember]
        public string UserName { get; set; }
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public bool allDay { get; set; }
        [DataMember]
        public DateTime start { get; set; }
        [DataMember]
        public DateTime end { get; set; }
        [DataMember]
        public string url { get; set; }
        [DataMember]
        public string className { get; set; }
        [DataMember]
        public bool editable { get; set; }
        [DataMember]
        public bool startEditable { get; set; }
        [DataMember]
        public bool durationEditable { get; set; }
        [DataMember]
        public string rendering { get; set; }
        [DataMember]
        public string color { get; set; }
        [DataMember]
        public string backgroundColor { get; set; }
        [DataMember]
        public string borderColor { get; set; }
        [DataMember]
        public string textColor { get; set; }
    }
}

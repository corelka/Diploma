using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_test.Models
{
    public class TimeTable
    {
        public TimeTable()
        {
            Schedules = new HashSet<Schedule>();
        }
        public int TimeTableId { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}

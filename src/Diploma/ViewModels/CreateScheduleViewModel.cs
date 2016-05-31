using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.ViewModels
{
    public class CreateScheduleViewModel
    {
        public string Subject { get; set; }
        public string Group { get; set; }
        public string Teacher { get; set; }
        public string Time { get; set; }
        public DayOfWeek Day { get; set; }
    }
}

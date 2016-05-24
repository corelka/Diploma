using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard_test.Models
{
    public class Table
    {
        public Table()
        {
            Issues = new HashSet<Issue>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int DashboardId { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
    }
}

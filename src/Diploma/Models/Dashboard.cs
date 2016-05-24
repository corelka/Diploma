using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diploma.Models
{
    public class Dashboard
    {
        public Dashboard()
        {
            Tables = new HashSet<Table>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
    }
}

using System;

namespace Diploma.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public DateTime Created { get; set; }
        public int TableId { get; set; }
    }
}
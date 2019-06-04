using System;
using System.Collections.Generic;

namespace Hr_management_system.Models
{
    public partial class Leaves
    {
        public Leaves()
        {
            
        }
        public int LeaveId { get; set; }
        public string Embg { get; set; }
        public string Title { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartDate { get; set; }
    }
}

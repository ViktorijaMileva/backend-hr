using System;
using System.Collections.Generic;

namespace Hr_management_system.Models
{
    public partial class Employees
    {
        public Employees()
        {
            
        }
        public string Embg { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? JobId { get; set; }
        public decimal? Salary { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime? DateHired { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Hr_management_system.Models
{
    public partial class EmployeeInfo
    {
        public EmployeeInfo()
        {
            
        }
        public string Embg { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
        public string Sex { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal? Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Hr_management_system.Models
{
    public partial class Departments
    {
        public Departments()
        {
            
        }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? ZipCode { get; set; }
        public string Street { get; set; }
        public int? DepartmentNumber { get; set; }
        public string DepartmentCity { get; set; }
        public string ManagerId { get; set; }
    }
}

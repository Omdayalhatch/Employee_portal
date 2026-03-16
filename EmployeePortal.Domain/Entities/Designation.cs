using EmployeeProtal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.Domain.Entities
{
    public class Designation
    {
        public int Id { get; set; }
        public string DesignationName { get; set; } = "";
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

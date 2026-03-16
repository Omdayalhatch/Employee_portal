using EmployeeProtal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.Application.DTO
{
    public class DesignationDTO
    {
        public int Id { get; set; }
        public string DesignationName { get; set; } = "";
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}

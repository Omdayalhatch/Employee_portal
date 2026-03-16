using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.Application.DTO
{
    public class EmployeeViewDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; } = "";

        public string? Contact { get; set; }

        public string DepartmentName { get; set; } = "";

        public string Email { get; set; } = "";

        public DateTime JoiningDate { get; set; }
    }
}

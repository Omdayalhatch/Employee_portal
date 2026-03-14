using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProtal.Application.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string? LastName { get; set; }
        public string? Profile { get; set; }
        public string? Contact { get; set; }
        public string Gender { get; set; } = "";
        public DateTime DateofBirth { get; set; }
        public string Address { get; set; } = "";
        public int UserId { get; set; }
        public string UserName { get; set; } = "";
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = "";
        public DateTime JoiningDate { get; set; } = DateTime.Now;
    }
}

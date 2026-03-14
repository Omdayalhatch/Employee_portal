using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProtal.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string? LastName { get; set; }
        public string? Contact { get; set; }
        public string? Profile { get; set; }
        public string Gender { get; set; } = "";
        public DateTime DateofBirth { get; set; }
        public string Address { get; set; } = "";
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public DateTime JoiningDate { get; set; } = DateTime.Now;
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}

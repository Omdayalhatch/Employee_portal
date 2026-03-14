using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProtal.Application.DTO
{
    public class AttendanceeDTO
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = "";
        public DateTime Date { get; set; }
        public TimeSpan CheckeIN { get; set; }
        public TimeSpan CheckeOut { get; set; }
    }
}

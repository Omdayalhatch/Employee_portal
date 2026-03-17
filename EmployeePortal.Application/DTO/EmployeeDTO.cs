using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProtal.Application.DTO
{

    public class EmployeeDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [MinLength(2, ErrorMessage = "First Name must be at least 2 characters")]
        public string FirstName { get; set; } = "";

        public string? LastName { get; set; }

        public string? Profile { get; set; }

        [Phone(ErrorMessage = "Invalid Contact Number")]
        public string? Contact { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; } = "";

        [Required(ErrorMessage = "Date of Birth is required")]
        public DateTime DateofBirth { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = "";

        // 👉 Optional karna hai to int? karo
        public int? UserId { get; set; }

        public string? UserName { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select valid Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select valid Designation")]
        public int DesignationId { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(1, 1000000, ErrorMessage = "Salary must be greater than 0")]
        public decimal Salary { get; set; }

        public string? DepartmentName { get; set; }

        public string? DesignationName { get; set; }

        public DateTime JoiningDate { get; set; } = DateTime.Now;
    }
}

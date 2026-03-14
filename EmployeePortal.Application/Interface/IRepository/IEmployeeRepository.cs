
using EmployeeProtal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProtal.Application.Interface.IRepository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee> AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task<bool> DeleteAsync(int id);
        Task<Employee?> GetDetailAsync(int id);
        Task<bool> DepartmentExistsAsync(int departmentId);
        Task<bool> HasEmployeeAsync(int employeeId);
        Task<bool> EmployeeUserExistsAsync(int userId);
    }
}


using EmployeePortal.Infrastucture.Data;
using EmployeeProtal.Application.Interface.IRepository;
using EmployeeProtal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.Infrastucture.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
       
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var e = await _context.Employees.FindAsync(id);
            if (e == null) return false;

            _context.Employees.Remove(e);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DepartmentExistsAsync(int departmentId)
        {
            return await _context.Departments
                .AnyAsync(d => d.Id == departmentId);
        }

        public async Task<bool> EmployeeUserExistsAsync(int userId)
        {
            return await _context.Employees.AnyAsync(e => e.UserId == userId);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.User)
                .ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.User)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee?> GetDetailAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.DepartmentId)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<bool> HasEmployeeAsync(int employeeId)
        {
            return await _context.Salaries.AnyAsync(s => s.EmployeeId == employeeId);
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }


    }
}

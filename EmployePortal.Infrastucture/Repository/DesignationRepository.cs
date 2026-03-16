using EmployeePortal.Application.Interface.IRepository;
using EmployeePortal.Domain.Entities;
using EmployeePortal.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployePortal.Infrastucture.Repository
{
    public class DesignationRepository: IDesignationRepository
    {
        private readonly AppDbContext _context;
        public DesignationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Designation> AddAsync(Designation designation)
        {
            _context.Designations.Add(designation);
            await _context.SaveChangesAsync();
            return designation;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var dept = await _context.Designations.FindAsync(id);
            if (dept == null)
                return false;
            _context.Designations.Remove(dept);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Designation>> GetAllAsync()
        {
            return await _context.Designations.ToListAsync();
        }

        public async Task<Designation?> GetByIdAsync(int id)
        {
            return await _context.Designations.FindAsync(id);
        }

        public async Task UpdateAsync(Designation existing)
        {
            _context.Designations.Update(existing);
            await _context.SaveChangesAsync();
        }
    }
}

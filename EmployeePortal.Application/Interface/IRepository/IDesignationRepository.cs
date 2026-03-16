using EmployeePortal.Domain.Entities;
using EmployeeProtal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.Application.Interface.IRepository
{
    public interface IDesignationRepository
    {
        Task<List<Designation>> GetAllAsync();
        Task<Designation?> GetByIdAsync(int id);
        Task<Designation> AddAsync(Designation designation);
        Task<bool> DeleteAsync(int id);
        Task UpdateAsync(Designation existing);
    }
}

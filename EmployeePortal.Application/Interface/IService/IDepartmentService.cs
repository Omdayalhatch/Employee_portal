using EmployeeProtal.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.Application.Interface.IService
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDTO>> GetAllAsync();
        Task<DepartmentDTO?> GetByIdAsync(int id);
        Task<DepartmentDTO> CreateAsync(DepartmentDTO dto);
        Task<DepartmentDTO> UpdateAsync(DepartmentDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}

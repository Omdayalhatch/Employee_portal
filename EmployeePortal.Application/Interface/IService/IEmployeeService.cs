
using EmployeeProtal.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProtal.Application.Interface.IService
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllAsync();
        Task<EmployeeDTO?> GetByIdAsync(int id);
        Task<EmployeeDTO> CreateAsync(EmployeeDTO dto);
        Task<EmployeeDTO> UpdateAsync(EmployeeDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<EmployeeDTO?> GetDetailAsync(int id);
    }
}

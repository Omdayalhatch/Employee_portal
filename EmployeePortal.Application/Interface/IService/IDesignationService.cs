using EmployeePortal.Application.DTO;
using EmployeeProtal.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.Application.Interface.IService
{
    public interface IDesignationService
    {
        Task<IEnumerable<DesignationDTO>> GetAllAsync();
        Task<DesignationDTO?> GetByIdAsync(int id);
        Task<DesignationDTO> CreateAsync(DesignationDTO dto);
        Task<DesignationDTO> UpdateAsync(DesignationDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}

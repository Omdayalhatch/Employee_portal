using EmployeePortal.Application.DTO;
using EmployeePortal.Application.Interface.IRepository;
using EmployeePortal.Application.Interface.IService;
using EmployeePortal.Domain.Entities;
using EmployeeProtal.Application.DTO;
using EmployePortal.Infrastucture.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Employee_portal.Service
{
    public class DesignationService : IDesignationService
    {
        private readonly IDesignationRepository _repo;
        public DesignationService(IDesignationRepository repo)
        {
            _repo = repo;
        }

        public async Task<DesignationDTO> CreateAsync(DesignationDTO dto)
        {
            var desi = new Designation
            {
                DesignationName = dto.DesignationName,
                CreatedDate = DateTime.Now,
                DepartmentId = dto.DepartmentId,
            };
            var result= await _repo.AddAsync(desi);
            return new DesignationDTO
            {
                Id = result.Id,
                DesignationName = result.DesignationName,
                CreatedDate = result.CreatedDate,
                DepartmentId = result.DepartmentId,
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<DesignationDTO>> GetAllAsync()
        {
            var result = await _repo.GetAllAsync();
            return result.Select(d => new DesignationDTO
            {
                Id = d.Id,
                DesignationName = d.DesignationName,
                CreatedDate = d.CreatedDate,
                DepartmentId = d.DepartmentId,
                DepartmentName = d.Department?.DepartmentName ?? "N/A"
        });
        }

        public async Task<DesignationDTO?> GetByIdAsync(int id)
        {
            var d = await _repo.GetByIdAsync(id);
            if (d == null) return null;
            return new DesignationDTO
            {
               Id = d.Id,
               DesignationName = d.DesignationName,
               CreatedDate = d.CreatedDate,
               DepartmentId = d.DepartmentId,
            };
            
        }

        public async Task<DesignationDTO> UpdateAsync(DesignationDTO dto)
        {
            var existing = await _repo.GetByIdAsync(dto.Id);

            if (existing == null)
                throw new Exception("Designation not found");

            existing.DesignationName = dto.DesignationName;
            existing.DepartmentId = dto.DepartmentId;

            await _repo.UpdateAsync(existing);
            
            return new DesignationDTO
            {
               Id = existing.Id,
               DesignationName = existing.DesignationName,
               CreatedDate = existing.CreatedDate,
               DepartmentId = existing.DepartmentId,
            };
        }
    }
}

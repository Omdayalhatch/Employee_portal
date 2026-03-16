using EmployeePortal.Application.DTO;
using EmployeePortal.Application.Interface.IRepository;
using EmployeePortal.Application.Interface.IService;
using EmployeePortal.Domain.Entities;
using EmployeeProtal.Application.DTO;
using EmployePortal.Infrastucture.Repository;

namespace Employee_portal.Service
{
    public class DesignationService : IDesignationService
    {
        private readonly IDesignationRepository _repo;
        public DesignationService(DesignationRepository repo)
        {
            _repo = repo;
        }

        public async Task<DesignationDTO> CreateAsync(DesignationDTO dto)
        {
            var desi = new Designation
            {
                DesignationName = dto.DesignationName,
                CreatedDate = dto.CreatedDate,

            };
            var result= await _repo.AddAsync(desi);
            return new DesignationDTO
            {
                Id = dto.Id,
                DesignationName = dto.DesignationName,
                CreatedDate = dto.CreatedDate,
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
            });
        }

        public async Task<DesignationDTO?> GetByIdAsync(int id)
        {
            var result = await _repo.GetAllAsync();
            if (result == null) return null;
            //return result.Select(d => new DesignationDTO
            //{
            //    Id = d.Id,
            //    DesignationName = d.DesignationName,
            //    CreatedDate = d.CreatedDate,
            //});
            return null;
        }

        public async Task<DesignationDTO> UpdateAsync(DesignationDTO dto)
        {
            var existing = await _repo.GetByIdAsync(dto.Id);

            if (existing == null)
                throw new Exception("Designation not found");

            existing.DesignationName = dto.DesignationName;

            await _repo.UpdateAsync(existing);
            return null ;
            //return new DepartmentDTO
            //{
            //    //Id = existing.Id,
            //    //DesignationName = existing.DesignationName,
            //    //CreatedDate = existing.CreatedDate,
            //};
        }
    }
}

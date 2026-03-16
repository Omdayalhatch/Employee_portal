using EmployeePortal.Application.Interface.IRepository;
using EmployeePortal.Application.Interface.IService;
using EmployeeProtal.Application.DTO;
using EmployeeProtal.Domain.Entities;
using System.Transactions;

namespace Employee_portal.Service
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IDepartmentRepository _repo;
        public DepartmentService(IDepartmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<DepartmentDTO> CreateAsync(DepartmentDTO dto)
        {
            var dept = new Department
            {
                DepartmentName = dto.DepartmentName,
                CreatedDate = dto.CreatedDate,
            };

            var result = await _repo.AddAsync(dept);

            return new DepartmentDTO
            {
                Id = result.Id,
                DepartmentName = result.DepartmentName,
                CreatedDate = result.CreatedDate,
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<DepartmentDTO>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(d => new DepartmentDTO
            {
                Id = d.Id,
                DepartmentName = d.DepartmentName,
                CreatedDate = d.CreatedDate,
            });
        }

        public async Task<DepartmentDTO?> GetByIdAsync(int id)
        {
            var d = await _repo.GetByIdAsync(id);
            if (d == null) return null;
            return new DepartmentDTO
            {
                Id = d.Id,
                DepartmentName = d.DepartmentName,
                CreatedDate = d.CreatedDate,
            };
        }

        public async Task<DepartmentDTO> UpdateAsync(DepartmentDTO dto)
        {
            var existing = await _repo.GetByIdAsync(dto.Id);

            if (existing == null)
                throw new Exception("Department not found");

            existing.DepartmentName = dto.DepartmentName;

            await _repo.UpdateAsync(existing);

            return new DepartmentDTO
            {
                Id = existing.Id,
                DepartmentName = existing.DepartmentName,
                CreatedDate = existing.CreatedDate,
            };
        }
    }
}

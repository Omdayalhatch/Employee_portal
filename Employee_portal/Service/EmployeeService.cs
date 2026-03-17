using EmployeePortal.Domain.Entities;
using EmployeeProtal.Application.DTO;
using EmployeeProtal.Application.Interface.IRepository;
using EmployeeProtal.Application.Interface.IService;
using EmployeeProtal.Domain.Entities;

namespace Employee_protal.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public async Task<EmployeeDTO> CreateAsync(EmployeeDTO dto)
        {
            Console.WriteLine($"DepartmentId: {dto.DepartmentId}");
            var departmentExists = await _repo.DepartmentExistsAsync(dto.DepartmentId);

            if (!departmentExists)
                throw new Exception("Department not found");
            //var userUsed = await _repo.EmployeeUserExistsAsync(dto.UserId);
            //if (userUsed)
            //    throw new Exception("This user is already assigned to another employee");

            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Address = dto.Address,
                Profile = dto.Profile,
                Gender = dto.Gender,
                Contact = dto.Contact,
                Salary = dto.Salary,
                DateofBirth = dto.DateofBirth,
                DesignationId = dto.DesignationId,
                DepartmentId = dto.DepartmentId,
                JoiningDate = dto.JoiningDate,
                //UserId = dto.UserId
            };

            var result = await _repo.AddAsync(employee);

            dto.Id = result.Id;

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var hasEmployee = await _repo.HasEmployeeAsync(id);
            if (hasEmployee)
                throw new InvalidOperationException(
                    "This Employee cannot be deleted"
                );

            return await _repo.DeleteAsync(id);

        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(e => new EmployeeDTO
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                //Email = e.Email,
                Address = e.Address,
                Profile = e.Profile,
                Gender = e.Gender,
                //UserId = e.UserId,
                Salary = e.Salary,
                UserName = e.User?.Username ?? "N/A",
                Contact = e.Contact,
                DateofBirth = e.DateofBirth,
                DesignationId = e.DesignationId,
                DesignationName = e.Designation?.DesignationName ?? "N/A",
                DepartmentId = e.DepartmentId,
                DepartmentName = e.Department?.DepartmentName ?? "N/A",
                JoiningDate = e.JoiningDate
            });
        }

        public async Task<EmployeeDTO?> GetByIdAsync(int id)
        {
            var e = await _repo.GetByIdAsync(id);
            if (e == null) return null;
            return new EmployeeDTO
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
               // Email = e.Email,
                Address = e.Address,
                Profile = e.Profile,
                Gender = e.Gender,
                //UserId = e.UserId,
                UserName = e.User?.Username ?? "N/A",
                Contact = e.Contact,
                Salary = e.Salary,
                DateofBirth = e.DateofBirth,
                DesignationId = e.DesignationId,
                DesignationName = e.Designation?.DesignationName ?? "N/A",
                DepartmentId = e.DepartmentId,
                DepartmentName = e.Department?.DepartmentName ?? "N/A",
                JoiningDate = e.JoiningDate
            };

        }

        public async Task<EmployeeDTO?> GetDetailAsync(int id)
        {
            var e = await _repo.GetDetailAsync(id);
            if (e == null) return null;
            return new EmployeeDTO
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
               // Email = e.Email,
                Address = e.Address,
                Profile = e.Profile,
                Gender = e.Gender,
                //UserId = e.UserId,
                UserName = e.User?.Username ?? "N/A",
                Contact = e.Contact,
                Salary = e.Salary,
                DateofBirth = e.DateofBirth,
                DesignationId = e.DesignationId,
                DesignationName = e.Designation?.DesignationName ?? "N/A",
                DepartmentId = e.DepartmentId,
                DepartmentName = e.Department?.DepartmentName ?? "N/A",
                JoiningDate = e.JoiningDate
            };
        }

        public async Task<EmployeeDTO> UpdateAsync(EmployeeDTO dto)
        {
            var existing = await _repo.GetByIdAsync(dto.Id);
            if (existing == null) return null;
            
            existing.FirstName = dto.FirstName;
            existing.LastName = dto.LastName;
            //existing.Email = dto.Email;
            existing.Address = dto.Address;
            existing.Profile = dto.Profile;
            existing.Gender = dto.Gender;
            existing.UserId = dto.UserId;
            existing.Contact = dto.Contact;
            existing.Salary = dto.Salary;
            existing.DateofBirth = dto.DateofBirth;
            existing.DesignationId = dto.DesignationId;
            existing.DepartmentId = dto.DepartmentId;
            existing.JoiningDate = dto.JoiningDate;
            await _repo.UpdateAsync(existing);
            return dto;
        }
    }
}

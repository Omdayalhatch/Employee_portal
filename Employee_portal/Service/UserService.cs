using Employee_Protal.Application.DTO;
using EmployeeProtal.Application.DTO;
using EmployeeProtal.Application.Interface.IRepository;
using EmployeeProtal.Application.Interface.IService;
using EmployeeProtal.Domain.Entities;

namespace Employee_portal.Service
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var users = await _repo.GetAllUsersAsync();
            return users.Select(x => new UserDTO
            {
                Id = x.Id,
                UserName = x.Username,
            }).ToList();
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginDTO dto)
        {
                var user = await _repo
                .GetUserByEmailAsync(dto.Email);

            if (user == null || user.PasswordHash != dto.Password)
            
                return null;
            

            return new LoginResponseDTO
            {
                Email = dto.Email,
                RoleId = user.RoleId,
                RoleName = user.Role.RoleName,
                Token = "JWT Token Here"
            };

        }
        public async Task<LoginResponseDTO> RegisterAsync(RegisterDTO dto)
        {
            var user = new User
            {
                Username = dto.UserName,
                Email = dto.Email,
                PasswordHash = dto.Password,
                RoleId = dto.RoleId
            };

            await _repo.AddUserAsync(user);
            await _repo.SaveAsync();

            return new LoginResponseDTO
            {
                Email = user.Email,
                RoleId = user.RoleId,
                RoleName = "User",
                Token = "JWT Token Here"
            };
        }
    }
}

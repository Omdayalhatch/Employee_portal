
using EmployeeProtal.Application.DTO;
using EmployeeProtal.Application.Interface.IRepository;
using EmployeeProtal.Application.Interface.IService;
using EmployeeProtal.Domain.Entities;

namespace Employee_portal.Service
{
    public class UserService: IUserService
    {
        private readonly JwtService _jwt;
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo, JwtService jwt)
        {
            _repo = repo;
            _jwt = jwt;
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
            var token = _jwt.GenerateToken(user);

            return new LoginResponseDTO
            {
                Email = dto.Email,
                RoleId = user.RoleId,
                RoleName = user.Role.RoleName,
                Token = token
                
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
            var token = _jwt.GenerateToken(user);
            return new LoginResponseDTO
            {
                Email = user.Email,
                RoleId = user.RoleId,
                RoleName = "User",
                Token = token
            };
        }
    }
}

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

            if (user == null)
            {
                return null;
            }

            var response = new LoginResponseDTO
            {
                Email = dto.Email,
                Token = "JWT Token Here"
            };

            return response;
        }
            public async Task<RegisterDTO> RegisterAsync(RegisterDTO dto)
        {
            var user = new User
            {
                Username = dto.UserName,
                Email = dto.Email,
                PasswordHash = dto.Password,
                RoleId = 2
            };

            try
            {
                await _repo.AddUserAsync(user);
                await _repo.SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return dto;
        }

        

    }
}


using Employee_Protal.Application.DTO;
using EmployeeProtal.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProtal.Application.Interface.IService
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUsersAsync();
        Task<LoginResponseDTO> LoginAsync(LoginDTO dto);
        Task<RegisterDTO> RegisterAsync(RegisterDTO dto);
    }
}

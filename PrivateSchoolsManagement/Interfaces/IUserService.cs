using PrivateSchoolsManagement.DTOs;
using PrivateSchoolsManagement.Models;

namespace PrivateSchoolsManagement.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> CreateUserAsync(User user);
        Task<UserDTO> GetUserByIdAsync(int userId);
        Task<List<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> UpdateUserAsync(int userId, User user);
        Task DeleteUserAsync(int userId);
        bool Authenticate(User user);
    }
}

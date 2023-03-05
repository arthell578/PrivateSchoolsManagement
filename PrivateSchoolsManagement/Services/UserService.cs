using AutoMapper;
using PrivateSchoolsManagement.Exceptions;
using PrivateSchoolsManagement.Helpers;
using PrivateSchoolsManagement.Models;

namespace PrivateSchoolsManagement.Services
{
    public class UserService
    {

        private readonly SchoolsManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(SchoolsManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            user.PasswordHash = PasswordHelper.HashPassword(userDTO.Password);
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new NotFoundException($"User with id {userId} not found.");
            }
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var users = await _dbContext.Users.ToListAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> UpdateUserAsync(int userId, UserDTO userDTO)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new NotFoundException($"User with id {userId} not found.");
            }
            _mapper.Map(userDTO, user);
            if (!string.IsNullOrEmpty(userDTO.Password))
            {
                user.PasswordHash = PasswordHelper.HashPassword(userDTO.Password);
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new NotFoundException($"User with id {userId} not found.");
            }
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}

using AutoMapper;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using PrivateSchoolsManagement.DTOs;
using PrivateSchoolsManagement.Exceptions;
using PrivateSchoolsManagement.Helpers;
using PrivateSchoolsManagement.Interfaces;
using PrivateSchoolsManagement.Models;

namespace PrivateSchoolsManagement.Services
{
    public class UserService : IUserService
    {

        private readonly SchoolsManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(SchoolsManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserDTO> CreateUserAsync(User user)
        {
            var newUser = _mapper.Map<User>(user);
            newUser.PasswordHash = PasswordHelper.HashPassword(user.Password);
            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<UserDTO>(newUser);
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

        public async Task<UserDTO> UpdateUserAsync(int userId, User user)
        {
            var updatedUser = await _dbContext.Users.FindAsync(userId);
            if (updatedUser == null)
            {
                throw new NotFoundException($"User with id {userId} not found.");
            }
            if (!string.IsNullOrEmpty(user.Password))
            {
                updatedUser.PasswordHash = PasswordHelper.HashPassword(user.Password);
            }
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<UserDTO>(updatedUser);
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

        public bool Authenticate(User user)
        {
            var authUser = _dbContext.Users.SingleOrDefault(x => x.Email == user.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(user.Password,user.PasswordHash))
            {
                return false;
            }

            return true;
        }

    }
}

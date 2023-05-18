using BLL.DTOs;

namespace BLL.Services.UserServices
{
    public interface IUserService
    {
        public Task<IEnumerable<UserDTO>> GetAllAsync();
        public Task<UserDTO?> GetUserByIdAsync(int id);
        public Task<UserDTO> DeleteUserAsync(UserDTO user);
        public Task<UserDTO> UpdateUserAsync(UserDTO user);
        public Task<IEnumerable<string>> UserRolesAsync(UserDTO user);
    }
}

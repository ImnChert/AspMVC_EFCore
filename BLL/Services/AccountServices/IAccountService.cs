using BLL.DTOs;

namespace BLL.Services.AccountServices
{
    public interface IAccountService
    {
        public Task<bool> RegisterAsync(UserDTO user, string password, string role);
        public Task<bool> LoginAsync(string email, string password);
        public Task LogoutAsync();
    }
}

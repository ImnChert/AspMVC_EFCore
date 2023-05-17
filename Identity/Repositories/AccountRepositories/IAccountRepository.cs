using Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Identity.Repositories.AccountRepositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> RegisterAsync(ApplicationUser user, string password, string role);
        public Task<SignInResult> LoginAsync(string email, string password);
        public Task LogoutAsync();
    }
}

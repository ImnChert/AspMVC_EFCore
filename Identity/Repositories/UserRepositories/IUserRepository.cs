using Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace Identity.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        public Task<IEnumerable<ApplicationUser>> GetAllAsync();
        public Task<ApplicationUser?> GetUserByIdAsync(int id);
        public Task<IdentityResult> DeleteUserAsync(ApplicationUser user);
        public Task<IdentityResult> UpdateUserAsync(ApplicationUser user);
        public Task<IEnumerable<string>> UserRolesAsync(ApplicationUser user);
    }
}

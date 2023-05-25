using Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Repositories.UserRepositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> DeleteUserAsync(ApplicationUser user)
        {
            user.Hide = 1;
            var result = await _userManager.UpdateAsync(user);

            return result;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            var result = await _userManager.Users.ToListAsync();

            return result;
        }

        public async Task<ApplicationUser?> GetUserByIdAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            return user;
        }

        public async Task<IdentityResult> UpdateUserAsync(ApplicationUser user)
        {
            var result = await _userManager.UpdateAsync(user);

            return result;
        }

        public async Task<IEnumerable<string>> UserRolesAsync(ApplicationUser user)
        {
            var result = await _userManager.GetRolesAsync(user);

            return result;
        }
    }
}

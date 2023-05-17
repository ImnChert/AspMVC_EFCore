using Microsoft.AspNetCore.Identity;

namespace Identity.Entities
{
    public class ApplicationRole : IdentityRole<int>
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}

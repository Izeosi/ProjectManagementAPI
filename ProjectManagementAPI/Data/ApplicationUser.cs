using Microsoft.AspNetCore.Identity;

namespace ProjectManagementAPI.Data
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}

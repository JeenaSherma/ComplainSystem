using Microsoft.AspNetCore.Identity;

namespace ComplaintSystem.Model
{
    public class ApplicationUser : IdentityUser
    {
        public int? BranchId { get; set; }
        public int? MunicipalityId { get; set; }
    }
}

using ComplaintSystem.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComplaintSystem.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Complain> complains { get; set; }
        public DbSet<ComplainerInfo> complainerInfos { get; set; }
        public DbSet<ComplainStatus> complainStatuses { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Municipality> municipalities { get; set; }
        public DbSet<QRinfo> qRinfos { get; set; }
        public DbSet<Token> tokens { get; set; }
        public DbSet<Ward> wards { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<BranchType> branchTypes { get; set; }
        public DbSet<RuralMunicipality> ruralMunicipalities { get; set; }
        public DbSet<Branch> branches { get; set; } 
        
    }
}

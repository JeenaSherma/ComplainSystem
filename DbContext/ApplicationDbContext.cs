using ComplaintSystem.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComplaintSystem.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
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
        
    }
}

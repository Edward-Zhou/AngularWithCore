using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AngularWithCore.Models;

namespace AngularWithCore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Thread> Thread { get; set; }
        public DbSet<Forum> Forum { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().Property(p => p.ConcurrencyStamp).IsConcurrencyToken(false);
            builder.Entity<ApplicationUser_Forum>()
                   .HasKey(af=>new { af.ApplicationUserId, af.ForumId});
            builder.Entity<ApplicationUser_Forum>()
                   .HasOne(af => af.Forum)
                   .WithMany(f => f.ApplicationUser_Forums)
                   .HasForeignKey(f=>f.ForumId);
            builder.Entity<ApplicationUser_Forum>()
                   .HasOne(af => af.ApplicationUser)
                   .WithMany(f => f.ApplicationUser_Forums)
                   .HasForeignKey(f => f.ApplicationUserId);
        }
        public DbSet<AngularWithCore.Models.ApplicationUser> ApplicationUser { get; set; }
    }
}

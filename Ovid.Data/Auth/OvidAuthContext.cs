using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ovid.Data.Auth.Models.Api;
using Ovid.Data.Auth.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ovid.Data.Auth
{
    /// <summary>
    /// Ovid Auth Db Context
    /// </summary>
    public class OvidAuthContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {


        #region Tables

        /// <summary>
        /// Authorization Apis
        /// </summary>
        public DbSet<ApiAuthRequest> ApiAuthRequests { get; set; }
        /// <summary>
        /// Social Providers
        /// </summary>
        public DbSet<SocialProvider> SocialProviders { get; set; }
        #endregion Tables


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public OvidAuthContext(DbContextOptions<OvidAuthContext> options) : base(options)
        {
            
        }
        /// <summary>
        /// Constructor
        /// </summary>
        protected OvidAuthContext()
        {

        }


        /// <summary>
        /// Configure Connection
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SQL5063.site4now.net;Initial Catalog=DB_9FA651_authovid;User Id=DB_9FA651_authovid_admin;Password=Shwn2004;");
        }


        /// <summary>
        /// Cretae Model
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().HasMany(u => u.Claims).WithOne().HasForeignKey(c => c.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationUser>().HasMany(u => u.Roles).WithOne().HasForeignKey(r => r.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationRole>().HasMany(r => r.Claims).WithOne().HasForeignKey(c => c.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationRole>().HasMany(r => r.Users).WithOne().HasForeignKey(r => r.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUser>().HasMany(r => r.ApiTokens).WithOne().HasForeignKey(r => r.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            


        }


    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Ovid.Auth.Extension.Configuration;
using Ovid.Data.Auth;
using Ovid.Data.Auth.Models.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ovid.Auth.Extension
{
    /// <summary>
    /// Ovid OAuth & OIDC Server Extensions
    /// </summary>
    public static class OvidAuthExtension
    {

        /// <summary>
        /// Add Ovid Authentication Pipeline
        /// </summary>
        /// <param name="configuration">Configuration Source</param>
        /// <param name="migrationAssembly">Migration Assembly Name</param>
        public static IServiceCollection AddOvidIdenityServer(this IServiceCollection services, IConfiguration configuration, string migrationAssembly)
        {
            // add data source
            services.AddDbContext<OvidAuthContext>(options => options.UseSqlServer(configuration.GetConnectionString("AuthDbConnection"), xt => xt.MigrationsAssembly(migrationAssembly)),
                ServiceLifetime.Transient);


            var cfg = configuration.GetSection("AuthConfig");
            var conf = cfg.Get<AuthConfig>();


            // add Identity Services
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
            })
                .AddEntityFrameworkStores<OvidAuthContext>()
                .AddDefaultTokenProviders();

            // add Identity Server
            var builder = services.AddIdentityServer(o =>
            {
                o.IssuerUri = conf.IssuerUri;
                o.Cors.CorsPolicyName = conf.CorsPolicyName;
                o.Cors.CorsPaths.Add("/graphql");
            })
                .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
                .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
                .AddInMemoryClients(IdentityServerConfig.GetClients(configuration))
                .AddInMemoryCaching()
                .AddInMemoryPersistedGrants()
                .AddAspNetIdentity<ApplicationUser>()
                .AddProfileService<ProfileService>();

            if (conf.AddDeveloperSigningCredential)
            {

                builder.AddDeveloperSigningCredential(conf.AddDeveloperSigningCredential);
            }
            else
            {
                var cert = new X509Certificate2(System.IO.Path.Combine(Directory.GetCurrentDirectory(), conf.TlsPath), conf.TlsPassword);
                builder.AddSigningCredential(cert);
            }

            if (conf.AddDeveloperSigningCredential)
            {
                IdentityModelEventSource.ShowPII = true;
            }
            else
            {
                IdentityModelEventSource.ShowPII = false;
            }


            // Add Api Authentication service
            services.AddAuthentication();
            services.AddAuthorization();

            return services;
        }

        /// <summary>
        /// Use Ovid Authentication Pipeline
        /// </summary>
        public static IApplicationBuilder UseOvidIdenityServer(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            return app;
        }


        /// <summary>
        /// Ensure Database is created
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder CreateAuthDatabase(this IApplicationBuilder app)
        {

            using (var scp = app.ApplicationServices.CreateScope())
            {
                var db = scp.ServiceProvider.GetRequiredService<OvidAuthContext>();
                if (!db.Database.EnsureCreated())
                {
                    // TODO : Log Db Create Failed 
                }
            }
            return app;
        }

        /// <summary>
        /// Seed The Auth Database for development data
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder SeedAuthDatabase(this IApplicationBuilder app)
        {

            using (var scp = app.ApplicationServices.CreateScope())
            {
                var db = scp.ServiceProvider.GetRequiredService<OvidAuthContext>();
                var urm = scp.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();


                #region create the roles
                ApplicationRole r1 = new ApplicationRole()
                {
                    Id = "E03C6809-3944-40B7-9458-459733F6246C",
                    Name = "ovidadmin",
                    NormalizedName = "ovidadmin".ToUpper()
                };
                if (!db.Roles.Where(m=>m.Id == "E03C6809-3944-40B7-9458-459733F6246C").Any())
                {
                    db.Roles.Add(r1);
                }

                ApplicationRole r2 = new ApplicationRole()
                {
                    Id = "A48B5BE8-AB54-4A28-827E-60F4E14CA655",
                    Name = "ovidsupport",
                    NormalizedName = "ovidsupport".ToUpper()
                };

                if (!db.Roles.Where(m => m.Id == "A48B5BE8-AB54-4A28-827E-60F4E14CA655").Any())
                {
                    db.Roles.Add(r2);
                }

                ApplicationRole r3 = new ApplicationRole()
                {
                    Id = "C08A3C53-146E-4905-A27C-5730BFFE1255",
                    Name = "oviduser",
                    NormalizedName = "oviduser".ToUpper()
                };
                if (!db.Roles.Where(m => m.Id == "C08A3C53-146E-4905-A27C-5730BFFE1255").Any())
                {
                    db.Roles.Add(r3);
                }

                ApplicationRole r4 = new ApplicationRole()
                {
                    Id = "CF008FC4-C085-4602-87B3-614D05E222A8",
                    Name = "ovidinfluencer",
                    NormalizedName = "ovidinfluencer".ToUpper()
                };
                if (!db.Roles.Where(m => m.Id == "CF008FC4-C085-4602-87B3-614D05E222A8").Any())
                {
                    db.Roles.Add(r4);
                }

                ApplicationRole r5 = new ApplicationRole()
                {
                    Id = "FB8AC3A8-169E-4F51-86B9-7E7A7B25F9E2",
                    Name = "ovidmarekter",
                    NormalizedName = "ovidmarekter".ToUpper()
                };
                if (!db.Roles.Where(m => m.Id == "FB8AC3A8-169E-4F51-86B9-7E7A7B25F9E2").Any())
                {
                    db.Roles.Add(r5);
                }
                db.SaveChanges();
                #endregion create the roles

                #region created default users
                ApplicationUser u1 = new ApplicationUser()
                {
                    Id= "B9F2D210-0CCB-48BD-A1E0-CA77FDE96E00",
                    Email="admin@keeper.mj-2.com",
                    EmailConfirmed=true,
                    PhoneNumber="0000000000",
                    UserName="admin",
                };

                if(!db.Users.Where(m=>m.Id == "B9F2D210-0CCB-48BD-A1E0-CA77FDE96E00").Any()){
                    urm.CreateAsync(u1, "Pass123");
                }


                ApplicationUser u2 = new ApplicationUser()
                {
                    Id = "F572BEE6-D4A8-412F-9844-03220F82DB9F",
                    Email = "markerter1@keeper.mj-2.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0000000000",
                    UserName = "markerterone",
                };

                if (!db.Users.Where(m => m.Id == "F572BEE6-D4A8-412F-9844-03220F82DB9F").Any())
                {
                    urm.CreateAsync(u2, "Pass123");
                }


                ApplicationUser u3 = new ApplicationUser()
                {
                    Id = "1F1CBC88-2B99-4FA6-9EBB-75DBD627CF5E",
                    Email = "markerter2@keeper.mj-2.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0000000000",
                    UserName = "markertertwo",
                };

                if (!db.Users.Where(m => m.Id == "1F1CBC88-2B99-4FA6-9EBB-75DBD627CF5E").Any())
                {
                    urm.CreateAsync(u3, "Pass123");
                }


                ApplicationUser u4 = new ApplicationUser()
                {
                    Id = "B9223C1C-BD8A-4B1B-A41F-E49B514B45A7",
                    Email = "influence@keeper.mj-2.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0000000000",
                    UserName = "influencer",
                };

                if (!db.Users.Where(m => m.Id == "B9223C1C-BD8A-4B1B-A41F-E49B514B45A7").Any())
                {
                    urm.CreateAsync(u4, "Pass123");
                }


                ApplicationUser u5 = new ApplicationUser()
                {
                    Id = "D831D4F4-DE85-409D-961F-588F70F64A20",
                    Email = "user1@keeper.mj-2.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0000000000",
                    UserName = "userone",
                };
                if (!db.Users.Where(m => m.Id == "D831D4F4-DE85-409D-961F-588F70F64A20").Any())
                {
                    urm.CreateAsync(u5, "Pass123");
                }


                ApplicationUser u6 = new ApplicationUser()
                {
                    Id = "5E82AF45-9712-4837-A1D9-21505CC4F1CA",
                    Email = "user2@keeper.mj-2.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0000000000",
                    UserName = "usertwo",
                };
                if (!db.Users.Where(m => m.Id == "5E82AF45-9712-4837-A1D9-21505CC4F1CA").Any())
                {
                    urm.CreateAsync(u6, "Pass123");
                }
                #endregion created default users

                // add providers list
                // TODO add provider list

                // add tracing 


            }
            return app;
        }






    }

}

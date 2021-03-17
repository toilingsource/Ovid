using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Ovid.Data;
using Ovid.Data.Sales;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Ovid.GraphQL.Extensions.Types.Accounts;
using Ovid.GraphQL.Extensions.Resolvers.Accounts;
using Ovid.GraphQL.Extensions.Types.Advertising;
using Ovid.GraphQL.Extensions.Types.Campaigns;
using Ovid.GraphQL.Extensions.Types.Common;
using Ovid.GraphQL.Extensions.Types.Marketers;
using Ovid.GraphQL.Extensions.Types.Posts;
using Ovid.GraphQL.Extensions.Types.Products;
using Ovid.GraphQL.Extensions.Types.Ratings;
using Ovid.GraphQL.Extensions.Resolvers.SocialMedia;

namespace Ovid.GraphQL.Extensions
{
    public static class OvidGraphQlExtensions
    {

        public static IServiceCollection AddGraphServer(this IServiceCollection services, IConfiguration configuration, string migrationAssembly)
        {

            // Add Db Connections
            services.AddDbContext<OvidDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DbConnection"), xt => xt.MigrationsAssembly(migrationAssembly)),
                ServiceLifetime.Transient);
            services.AddDbContext<OvidSalesContext>(options => options.UseSqlServer(configuration.GetConnectionString("SalesDbConnection"), xt => xt.MigrationsAssembly(migrationAssembly)),
                ServiceLifetime.Transient);


            services.AddHttpContextAccessor();
            services.AddGraphQLServer()
                    .AddAuthorization()
                    .AddFiltering()
                    .AddSorting()
                    .AddType<AccountTypeGlType>()
                    .AddType<FollowedGlType>()
                    .AddType<UserAccountGlType>()
                    .AddType<UserIntrestGlType>()
                    .AddType<AdvertismentGlType>()
                    .AddType<UserAddClickGlType>()
                    .AddType<UserCampaignItemClickGlType>()
                    .AddType<UserCampaignClickGlType>()
                    .AddType<CampaignItemGlType>()
                    .AddType<CampaignTypeGlType>()
                    .AddType<CampaignGlType>()
                    .AddType<IntrestListGlType>()
                    .AddType<OcupationGlType>()
                    .AddType<SalalaryGlType>()
                    .AddType<MarketerGlType>()
                    .AddType<PostImageGlType>()
                    .AddType<UserPostGlType>()
                    .AddType<ProductCategoryGlType>()
                    .AddType<ProductImageGlType>()
                    .AddType<SponsoredProductGlType>()
                    .AddType<AccountRatingGlType>()
                    .AddType<UserProductClickGlType>()
                    .AddType<SocialFeedResolver>()
                    .AddQueryType<OvidQuery>();
                    //.AddMutationType<OvidMutation>();


            return services;
        }


        /// <summary>
        /// Use GraphQl Server
        /// </summary>
        public static IApplicationBuilder UseGraphServer(this IApplicationBuilder app, string corsPolicy)
        {

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL()
                .RequireCors(corsPolicy);
            });
            return app;
        }


        /// <summary>
        /// Ensure Database is created
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder CreateDatabase(this IApplicationBuilder app)
        {

            using (var scp = app.ApplicationServices.CreateScope())
            {
                var db = scp.ServiceProvider.GetRequiredService<OvidDbContext>();
                if (!db.Database.EnsureCreated())
                {
                    // TODO : Log Db Create Failed 
                }
                var db2 = scp.ServiceProvider.GetRequiredService<OvidSalesContext>();
                if (db2.Database.EnsureCreated())
                {
                    // ToDo Log Db Create Failed
                }
            }
             return app;
        }


        /// <summary>
        /// Seed database with default values for testing
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder SeedDefaultDatabase(this IApplicationBuilder app)
        {

            using (var scp = app.ApplicationServices.CreateScope())
            {
                var db = scp.ServiceProvider.GetRequiredService<OvidDbContext>();
            


                



            }
            return app;
        }
    }
}

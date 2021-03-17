using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ovid.Auth.Extension;
using Ovid.Auth.Extension.Configuration;
using Ovid.GraphQL.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Ovid.Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var assmName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddAutoMapper(typeof(Startup));

            services.AddHealthChecks();

            services.AddCors(options =>
            {
                options.AddPolicy("DevCorsPolicy",
                    builder => builder.WithOrigins("http://localhost:4200")
                        .WithOrigins("http://localhost:5000")
                        .WithOrigins("https://keeper.mj-2.com")
                        .WithOrigins("http://keeper.mj-2.com")
                        .WithOrigins("https://localhost:5001")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
                options.AddDefaultPolicy(b =>
                    b.WithOrigins("http://localhost:4200")
                        .WithOrigins("http://localhost:5000")
                        .WithOrigins("https://keeper.mj-2.com")
                        .WithOrigins("http://keeper.mj-2.com")
                        .WithOrigins("https://localhost:5001")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                );
            });

            var cfg = Configuration.GetSection("AuthConfig");
            var cf = cfg.Get<AuthConfig>();

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            services.AddOvidIdenityServer(Configuration, assmName);

            services.AddGraphServer(Configuration, assmName);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(options =>
           {
               options.Authority = cf.IssuerUri; //TODO : Make use of configuration values
               options.RequireHttpsMetadata = false;

               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateAudience = false
               };
           });

            services.AddAuthorization();


            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });


            services.AddControllersWithViews();

            var container = new ContainerBuilder();
            container.Populate(services);
            return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions()
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedHost | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.SeedAuthDatabase();
            }

            app.UseStaticFiles();
            app.UseRouting();
            // add Cors
            app.UseCors();
            app.UseOvidIdenityServer();
            app.UseGraphServer("DevCorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/metrics", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
                {
                    ResponseWriter = WriteResponse
                });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static Task WriteResponse(HttpContext context, HealthReport result)
        {
            context.Response.ContentType = "application/json";

            var json = new JObject(
                new JProperty("status", result.Status.ToString()),
                new JProperty("results", new JObject(result.Entries.Select(pair =>
                    new JProperty(pair.Key, new JObject(
                        new JProperty("status", pair.Value.Status.ToString()),
                        new JProperty("description", pair.Value.Description),
                        new JProperty("data", new JObject(pair.Value.Data.Select(
                            p => new JProperty(p.Key, p.Value))))))))));

            return context.Response.WriteAsync(
                json.ToString(Formatting.Indented));
        }
    }
}

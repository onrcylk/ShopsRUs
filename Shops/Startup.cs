using AutoMapper;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shops.Helper;

namespace Shops
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("MyConnection");
            services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));

            var jwtSettingsSection = Configuration.GetSection("JWTSettings");
            services.Configure<JWTSettings>(jwtSettingsSection);
            var appSettings = jwtSettingsSection.Get<JWTSettings>();
            var swaggerRestrictionsSection = Configuration.GetSection("SwaggerRestrictions");
            var swaggerRestrictions = swaggerRestrictionsSection.Get<SwaggerRestrictions>();
            services.AddSwaggerGen(gen =>
            {
                gen.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = appSettings.Audience, Version = "v1.0" });
                gen.DocumentFilter<SwaggerFilterOutControllers>(swaggerRestrictions);
                gen.CustomSchemaIds(x => GetCustomSchemaId(x));
            });
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddAutoMapper(typeof(Startup), typeof(AutoMapperProfile));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Token:Issuer"],
                    ValidAudience = Configuration["Token:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddControllers();
            services.AddHttpContextAccessor();

            var option = new SqlServerStorageOptions
            {
                PrepareSchemaIfNecessary = true,
                QueuePollInterval = TimeSpan.FromMinutes(5),
                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                UseRecommendedIsolationLevel = true,
                UsePageLocksOnDequeue = true,
                DisableGlobalLocks = true
            };
            services.AddHangfire(config =>
            {
                //config.UseSqlServerStorage(connectionString, option).WithJobExpirationTimeout(TimeSpan.FromHours(6));
                JobStorage.Current = new SqlServerStorage(connectionString, option);
            });

            services.AddHangfireServer();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseHangfireDashboard();
            app.UseRouting();
            app.UseAuthentication();           
            app.UseAuthorization();
            app.UseSwagger();
            string audience = Configuration["JWTSettings:Audience"];
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerUI(ui =>
            {
                ui.SwaggerEndpoint("/swagger/v1.0/swagger.json", audience + " Endpoint");
                ui.RoutePrefix = string.Empty;
            });

        }
        private string GetCustomSchemaId(Type type)
        {
            try
            {
                string response = "";
                if (!(type.IsGenericType && type.GenericTypeArguments.Length > 0))
                    response = type.Name;
                else
                {
                    string name = type.Name.Substring(0, type.Name.IndexOf("`")) + "<{type_name}>";
                    //string type_name = GetTypeName(type.GenericTypeArguments[0]);
                    string type_name = type.GenericTypeArguments[0].FullName;
                    response = name.Replace("{type_name}", type_name);
                    //response = name.Replace("{type_name}", type.Name);
                }
                Console.WriteLine(type.Name + " => " + response);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(type.Name);
                Console.WriteLine(ex);
                return type.Name;
            }
        }
    }
}

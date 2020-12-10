using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using WebApiContactChallenge.Api.Auth;
using WebApiContactChallenge.Application;
using WebApiContactChallenge.Application.Interface;
using WebApiContactChallenge.Common.Configuration;
using WebApiContactChallenge.Infrastructure.DapperSql.Base;
using WebApiContactChallenge.Infrastructure.Interface.Base;

namespace WebApiContactChallenge.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConfigHelper.SetConfig(ConfigHelper.ConnectionStringKey, Configuration.GetValue<string>(ConfigHelper.ConnectionStringKey));
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Contact Challenge : By Som Rintharamy", Version = "v1" });

                c.OperationFilter<HeaderForSwaggerAttribute>();

                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "SwaggerWebApiContactChallenge.xml");

                c.IncludeXmlComments(filePath);
            });

            //IOC
            services.AddScoped<IUowFactory, UowFactory>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IContactSkillsService, ContactSkillService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMyMiddleware();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Contact Challenge V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
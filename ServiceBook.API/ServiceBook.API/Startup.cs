using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ServiceBook.API.Entities;
using ServiceBook.API.Models;
using ServiceBook.API.Repositories;

namespace ServiceBook.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddDbContext<ServiceBookContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ServiceBookContext")));

            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IObjectRepository, ObjectRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ServiceBookContext serviceBookContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var cfg = new AutoMapper.Configuration.MapperConfigurationExpression();
            cfg.CreateMap<UserType, UserTypeDto>();
            cfg.CreateMap<User, UserDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src =>
                $"{src.FirstName} {src.LastName}"));
            cfg.CreateMap<Department, DepartmentDto>();
            cfg.CreateMap<Provider, ProviderDto>();
            cfg.CreateMap<Company, CompanyDto>();

            Mapper.Initialize(cfg);

            serviceBookContext.EnsureSeedDataForContext();
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseMvc();
        }
    }
}

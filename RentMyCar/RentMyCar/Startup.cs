using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Model.DB;
using Model;
using Model.Repository;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using RentMyCar.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;

namespace RentMyCar
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
            // seting identity
            services.AddIdentity<User, IdentityRole>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<RentMyCarContext>();

            //defing authentication methods and schema
            services.AddAuthentication().AddJwtBearer(cfg =>
            {
                cfg.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = Configuration.GetValue<string>("Tokens:Issuer"),
                    ValidAudience = Configuration.GetValue<string>("Tokens:Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Tokens:Key")))
                };
            }
            );

            //adding automapper to project
            services.AddAutoMapper();

            //adding connection to db
            services.AddDbContext<RentMyCarContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DbConnection")
                , b => b.MigrationsAssembly("RentMyCar")));

            //adding mvc and validatons
            services.AddMvc().AddJsonOptions(options =>
                 options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                    .AddFluentValidation();

            //adding repositories and validations
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRentRepository, RentRepository>();

            services.AddTransient<IValidator<Adress>, AdressValidator>();
            services.AddTransient<IValidator<Car>, CarValidator>();
            services.AddTransient<IValidator<Rent>, RentValidator>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //configuring behavior for specific stages
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //enable use of static files in wwwroot folder
            app.UseStaticFiles();

            //using authentications
            app.UseAuthentication();

            //creating routes
            app.UseMvc(routes =>
            {
                //creating deafult route
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //creating route for Angular Client
                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}

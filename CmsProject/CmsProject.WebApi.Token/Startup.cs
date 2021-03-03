using CmsProject.DataLayer.Context;
using CmsProject.Service.Repositories;
using CmsProject.Service.Services;
using CmsProject.WebApi.Token.Helpers;
using CmsProject.WebApi.Token.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CmsProject.WebApi.Token
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

            services.AddDbContext<UniversityWorker_Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UniversityWorker_Context")
                ));

            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddIdentity<DataLayer.Context.Model.ApplicationUser, IdentityRole>(options =>
            {
                // 1 =  حداقل یک کاراکتر یونیک در پسورد باشد
                options.Password.RequiredUniqueChars = 0;

                // ایمیل منحصر به فرد
                options.User.RequireUniqueEmail = true;

                // در نام کاربری چه کاراکترهایی میتواند وجود داشته باشد
                //options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-";

                // کاربر بعد از وارد کردن 5 بار (پیش فرض = 5) رمز اشتباه- به مدت 5 دقیقه قفل میشود
                //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            }).AddEntityFrameworkStores<UniversityWorker_Context>()
              .AddDefaultTokenProviders();

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            
            services.AddTransient<IPageGroupRepository, PageGroupRepository>();
            services.AddTransient<IPageRepository, PageRepository>();
            services.AddTransient<ILessonRepository, LessonRepository>();
            services.AddTransient<IGradeRepository, GradeRepository>();
            services.AddTransient<ITrainingCenterRepository, TrainingCenterRepository>();
            services.AddTransient<IMajorRepository, MajorRepository>();
            services.AddTransient<IStudyRepository, StudyRepository>();
            services.AddTransient<IEnumEntityRepository, EnumEntityRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IPersonelRepository, PersonelRepository>();
            services.AddTransient<IBankReportRepository, BankReportRepository>();
        }

        // configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}

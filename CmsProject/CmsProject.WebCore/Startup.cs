using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CmsProject.Service.Repositories;
using CmsProject.Service.Services;
using CmsProject.DataLayer.Context;
using Microsoft.AspNetCore.Identity;
using CmsProject.WebCore.Repositories.Email;
using CmsProject.DataLayer.Context.Model;

namespace CmsProject.WebCore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<UniversityWorker_Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UniversityWorker_Context")
                ));
            
            //services.AddIdentity<IdentityUser, IdentityRole>(options =>
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
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
              //.AddErrorDescriber<PersianIdentityErrorDescriber>();

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

            services.AddScoped<IMessageSender, MessageSender>(); // ارسال ایمیل

            services.AddRazorPages();
            services.AddHealthChecks();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
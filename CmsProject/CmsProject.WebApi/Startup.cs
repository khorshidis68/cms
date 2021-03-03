using CmsProject.DataLayer.Context;
using CmsProject.Service.Repositories;
using CmsProject.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CmsProject.WebApi
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
            services.AddControllers();

            services.AddDbContext<UniversityWorker_Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UniversityWorker_Context")
                ));

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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

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
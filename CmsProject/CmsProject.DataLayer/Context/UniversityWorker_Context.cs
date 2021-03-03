using CmsProject.DataLayer.Context.Model;
using CmsProject.DomainClass.BankReport;
using CmsProject.DomainClass.EnumEntity;
using CmsProject.DomainClass.Grade;
using CmsProject.DomainClass.HamavaInfo;
using CmsProject.DomainClass.HamavaInfoSchedule;
using CmsProject.DomainClass.Lesson;
using CmsProject.DomainClass.Major;
using CmsProject.DomainClass.Person;
using CmsProject.DomainClass.Personel;
using CmsProject.DomainClass.Student;
using CmsProject.DomainClass.StudentPayable;
using CmsProject.DomainClass.Study;
using CmsProject.DomainClass.Teacher;
using CmsProject.DomainClass.TeachGradePrice;
using CmsProject.DomainClass.TrainingCenter;
using CmsProject.DomainModelClass.Page;
using CmsProject.DomainModelClass.PageGroup;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CmsProject.DataLayer.Context
{
    public class UniversityWorker_Context : IdentityDbContext<ApplicationUser>
    {
        public UniversityWorker_Context(DbContextOptions<Context.UniversityWorker_Context> options)
            : base(options)
        { }

        public DbSet<Page> Pages { get; set; }
        public DbSet<PageGroup> PageGroups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<TrainingCenter> TrainingCenters { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Study> Studys { get; set; }
        public DbSet<EnumEntity> EnumEntities { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<BankReport> BankReports { get; set; }
        public DbSet<HamavaInfo> HamavaInfos { get; set; }
        public DbSet<HamavaInfoSchedule> HamavaInfoSchedules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentPayable> StudentPayables { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeachGradePrice> TeachGradePrices { get; set; }

    }
}
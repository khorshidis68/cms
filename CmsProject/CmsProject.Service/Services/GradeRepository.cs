using CmsProject.DataLayer.Context;
using CmsProject.DomainClass.Grade;
using CmsProject.Service.Repositories;
using CmsProject.Utilities.Paging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CmsProject.Service.Services
{
    /// <summary>
    /// توابع مقطع تحصیلی
    /// </summary>
    public class GradeRepository : IGradeRepository
    {

        private UniversityWorker_Context _context;
        private DbSet<Grade> _dbSet;

        public GradeRepository(UniversityWorker_Context context)
        {
            _context = context;
            _dbSet = context.Set<Grade>();
        }


        /// <summary>
        /// بدست آوردن مقطع تحصیلی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه مقطع تحصیلی</param>
        /// <returns>رکورد مقطع تحصیلی</returns>
        public Grade GetGradeById(int id) => _dbSet.Find(id);


        /// <summary>
        /// بدست آوردن مقطع تحصیلی براساس شناسه به صورت غیرهمزمان
        /// </summary>
        /// <param name="id">شناسه مقطع تحصیلی</param>
        /// <returns>رکورد مقطع تحصیلی</returns>
        public async Task<Grade> GetGradeByIdAsync(int id) => await _dbSet.FindAsync(id);


        /// <summary>
        /// بدست آوردن مقطع تحصیلی براساس شرط
        /// </summary>
        /// <param name="where">شرط مقطع تحصیلی</param>
        /// <returns>رکورد مقطع تحصیلی</returns>
        public Grade FirstOrDefaultGrade(Expression<Func<Grade, bool>> where) => _dbSet.FirstOrDefault(where);


        /// <summary>
        /// ثبت رکورد جدید مقطع تحصیلی
        /// </summary>
        /// <param name="entity">رکورد مقطع تحصیلی</param>
        public void InsertGrade(Grade entity) => _dbSet.Add(entity);


        /// <summary>
        /// ویرایش رکورد مقطع تحصیلی
        /// </summary>
        /// <param name="entity">رکورد مقطع تحصیلی</param>
        public void UpdateGrade(Grade entity) => _context.Entry(entity).State = EntityState.Modified;


        /// <summary>
        /// حذف رکورد مقطع تحصیلی
        /// </summary>
        /// <param name="entity">رکورد مقطع تحصیلی</param>
        public void DeleteGrade(Grade entity) => _context.Entry(entity).State = EntityState.Deleted;


        /// <summary>
        /// حذف مقطع تحصیلی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه مقطع تحصیلی</param>
        public void DeleteGradeById(int id) => DeleteGrade(GetGradeById(id));


        /// <summary>
        /// بدست آوردن کلیه اطلاعات مقطع تحصیلی
        /// </summary>
        /// <returns>لیست دزس</returns>
        public IEnumerable<Grade> GetAllGrade() => _dbSet.ToList();


        /// <summary>
        /// بدست آوردن لیستی از مقطع تحصیلیها بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد مقطع تحصیلی</returns>
        public IEnumerable<Grade> GetWhereGrade(Expression<Func<Grade, bool>> where)
        {
            IQueryable<Grade> queryable = _dbSet;
            if (where != null)
            {
                queryable.Where(where);
            }
            return queryable;
        }


        /// <summary>
        /// بدست آوردن تعداد مقطع تحصیلی
        /// </summary>
        /// <returns>تعداد مقطع تحصیلی</returns>
        public int CountAllGrade() => _dbSet.Count();


        /// <summary>
        /// بدست آوردن تعداد مقطع تحصیلی براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد مقطع تحصیلی</returns>
        public int CountWhereGrade(Expression<Func<Grade, bool>> where) => _dbSet.Count(where);


        /// <summary>
        /// بررسی وجود رکورد مقطع تحصیلی براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        public bool IsExistGrade(Expression<Func<Grade, bool>> Where) => _dbSet.Any(Where);


        /// <summary>
        /// جستجوی مقطع تحصیلی
        /// </summary>
        /// <param name="param">پارامتر جستجو</param>
        /// <returns>لیست مقطع تحصیلی</returns>
        public IEnumerable<Grade> SearchGrade(string param)
        {
            var lsit = _dbSet.Where(p => p.Name .Contains(param)
                    ).ToList();
            return lsit.Distinct().ToList();
        }


        /// <summary>
        /// لیست مقطع تحصیلی به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست مقطع تحصیلی</returns>
        public PagedResult<Grade> GetAllGrades_Paging(int page = 1, int pageSize = 10)
        {
            return _context.Grades.GetPaged(page, pageSize);
        }


        /// <summary>
        /// ذخیره سازی اطلاعات
        /// </summary>
        public void Save() => _context.SaveChanges();


        /// <summary>
        /// خالی کردن عملیات از حافظه
        /// </summary>
        public void Dispose() => _context?.Dispose();

    }
}
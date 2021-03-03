using CmsProject.DataLayer.Context;
using CmsProject.DomainClass.Major;
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
    /// توابع رشته تحصیلی
    /// </summary>
    public class MajorRepository : IMajorRepository
    {

        private UniversityWorker_Context _context;
        private DbSet<Major> _dbSet;
        private DbSet<Major> _dbSetMajor;

        public MajorRepository(UniversityWorker_Context context)
        {
            _context = context;
            _dbSet = context.Set<Major>();
            _dbSetMajor = context.Set<Major>();
        }


        /// <summary>
        /// بدست آوردن رشته تحصیلی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه رشته تحصیلی</param>
        /// <returns>رکورد رشته تحصیلی</returns>
        public Major GetMajorById(int id) =>  _dbSet.Find(id);


        /// <summary>
        /// بدست آوردن رشته تحصیلی براساس شناسه به صورت غیرهمزمان
        /// </summary>
        /// <param name="id">شناسه رشته تحصیلی</param>
        /// <returns>رکورد رشته تحصیلی</returns>
        public async Task<Major> GetMajorByIdAsync(int id) =>  await _dbSet.FindAsync(id);
        


        /// <summary>
        /// بدست آوردن رشته تحصیلی براساس شرط
        /// </summary>
        /// <param name="where">شرط رشته تحصیلی</param>
        /// <returns>رکورد رشته تحصیلی</returns>
        public Major FirstOrDefaultMajor(Expression<Func<Major, bool>> where) => _dbSet.FirstOrDefault(where);


        /// <summary>
        /// ثبت رکورد جدید رشته تحصیلی
        /// </summary>
        /// <param name="entity">رکورد رشته تحصیلی</param>
        public void InsertMajor(Major entity) => _dbSet.Add(entity);


        /// <summary>
        /// ویرایش رکورد رشته تحصیلی
        /// </summary>
        /// <param name="entity">رکورد رشته تحصیلی</param>
        public void UpdateMajor(Major entity) => _context.Entry(entity).State = EntityState.Modified;


        /// <summary>
        /// حذف رکورد رشته تحصیلی
        /// </summary>
        /// <param name="entity">رکورد رشته تحصیلی</param>
        public void DeleteMajor(Major entity) => _context.Entry(entity).State = EntityState.Deleted;


        /// <summary>
        /// حذف رشته تحصیلی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه رشته تحصیلی</param>
        public void DeleteMajorById(int id) => DeleteMajor(GetMajorById(id));


        /// <summary>
        /// بدست آوردن کلیه اطلاعات رشته تحصیلی
        /// </summary>
        /// <returns>لیست دزس</returns>
        public IEnumerable<Major> GetAllMajor() => _dbSet.ToList();


        /// <summary>
        /// بدست آوردن لیستی از رشته تحصیلیها بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد رشته تحصیلی</returns>
        public IEnumerable<Major> GetWhereMajor(Expression<Func<Major, bool>> where)
        {
            IQueryable<Major> queryable = _dbSet;
            if (where != null)
            {
                queryable.Where(where);
            }
            return queryable;
        }


        /// <summary>
        /// بدست آوردن تعداد رشته تحصیلی
        /// </summary>
        /// <returns>تعداد رشته تحصیلی</returns>
        public int CountAllMajor() => _dbSet.Count();


        /// <summary>
        /// بدست آوردن تعداد رشته تحصیلی براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد رشته تحصیلی</returns>
        public int CountWhereMajor(Expression<Func<Major, bool>> where) => _dbSet.Count(where);


        /// <summary>
        /// بررسی وجود رکورد رشته تحصیلی براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        public bool IsExistMajor(Expression<Func<Major, bool>> Where) => _dbSet.Any(Where);


        /// <summary>
        /// جستجوی رشته تحصیلی
        /// </summary>
        /// <param name="param">پارامتر جستجو</param>
        /// <returns>لیست رشته تحصیلی</returns>
        public IEnumerable<Major> SearchMajor(string param)
        {
            var lsit = _dbSet.Where(p => p.Name.Contains(param) ||
                                         p.GradeTitle.Contains(param) 
                    ).ToList();
            return lsit.Distinct().ToList();
        }


        /// <summary>
        /// لیست رشته تحصیلی به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست رشته تحصیلی</returns>
        public PagedResult<Major> GetAllMajors_Paging(int page = 1, int pageSize = 10)
        {
            return _context.Majors.GetPaged(page, pageSize);
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
using CmsProject.DataLayer.Context;
using CmsProject.DomainClass.TrainingCenter;
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
    /// توابع مرکز آموزشی
    /// </summary>
    public class TrainingCenterRepository : ITrainingCenterRepository
    {

        private UniversityWorker_Context _context;
        private DbSet<TrainingCenter> _dbSet;

        public TrainingCenterRepository(UniversityWorker_Context context)
        {
            _context = context;
            _dbSet = context.Set<TrainingCenter>();
        }


        /// <summary>
        /// بدست آوردن مرکز آموزشی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه مرکز آموزشی</param>
        /// <returns>رکورد مرکز آموزشی</returns>
        public TrainingCenter GetTrainingCenterById(int id) => _dbSet.Find(id);


        /// <summary>
        /// بدست آوردن مرکز آموزشی براساس شناسه به صورت غیرهمزمان
        /// </summary>
        /// <param name="id">شناسه مرکز آموزشی</param>
        /// <returns>رکورد مرکز آموزشی</returns>
        public async Task<TrainingCenter> GetTrainingCenterByIdAsync(int id) => await _dbSet.FindAsync(id);


        /// <summary>
        /// بدست آوردن مرکز آموزشی براساس شرط
        /// </summary>
        /// <param name="where">شرط مرکز آموزشی</param>
        /// <returns>رکورد مرکز آموزشی</returns>
        public TrainingCenter FirstOrDefaultTrainingCenter(Expression<Func<TrainingCenter, bool>> where) => _dbSet.FirstOrDefault(where);


        /// <summary>
        /// ثبت رکورد جدید مرکز آموزشی
        /// </summary>
        /// <param name="entity">رکورد مرکز آموزشی</param>
        public void InsertTrainingCenter(TrainingCenter entity) => _dbSet.Add(entity);


        /// <summary>
        /// ویرایش رکورد مرکز آموزشی
        /// </summary>
        /// <param name="entity">رکورد مرکز آموزشی</param>
        public void UpdateTrainingCenter(TrainingCenter entity) => _context.Entry(entity).State = EntityState.Modified;


        /// <summary>
        /// حذف رکورد مرکز آموزشی
        /// </summary>
        /// <param name="entity">رکورد مرکز آموزشی</param>
        public void DeleteTrainingCenter(TrainingCenter entity) => _context.Entry(entity).State = EntityState.Deleted;


        /// <summary>
        /// حذف مرکز آموزشی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه مرکز آموزشی</param>
        public void DeleteTrainingCenterById(int id) => DeleteTrainingCenter(GetTrainingCenterById(id));


        /// <summary>
        /// بدست آوردن کلیه اطلاعات مرکز آموزشی
        /// </summary>
        /// <returns>لیست مرکز آموزشی</returns>
        public IEnumerable<TrainingCenter> GetAllTrainingCenter() => _dbSet.ToList();


        /// <summary>
        /// بدست آوردن لیستی از مرکز آموزشیها بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد مرکز آموزشی</returns>
        public IEnumerable<TrainingCenter> GetWhereTrainingCenter(Expression<Func<TrainingCenter, bool>> where)
        {
            IQueryable<TrainingCenter> queryable = _dbSet;
            if (where != null)
            {
                queryable.Where(where);
            }
            return queryable;
        }


        /// <summary>
        /// بدست آوردن تعداد مرکز آموزشی
        /// </summary>
        /// <returns>تعداد مرکز آموزشی</returns>
        public int CountAllTrainingCenter() => _dbSet.Count();


        /// <summary>
        /// بدست آوردن تعداد مرکز آموزشی براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد مرکز آموزشی</returns>
        public int CountWhereTrainingCenter(Expression<Func<TrainingCenter, bool>> where) => _dbSet.Count(where);


        /// <summary>
        /// بررسی وجود رکورد مرکز آموزشی براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        public bool IsExistTrainingCenter(Expression<Func<TrainingCenter, bool>> Where) => _dbSet.Any(Where);


        /// <summary>
        /// جستجوی مرکز آموزشی
        /// </summary>
        /// <param name="param">پارامتر جستجو</param>
        /// <returns>لیست مرکز آموزشی</returns>
        public IEnumerable<TrainingCenter> SearchTrainingCenter(string param)
        {
            var lsit = _dbSet.Where(p => p.Name.Contains(param)).ToList();
            return lsit.Distinct().ToList();
        }


        /// <summary>
        /// لیست مرکز آموزشی به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست مرکز آموزشی</returns>
        public PagedResult<TrainingCenter> GetAllTrainingCenters_Paging(int page = 1, int pageSize = 10)
        {
            return _context.TrainingCenters.GetPaged(page, pageSize);
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
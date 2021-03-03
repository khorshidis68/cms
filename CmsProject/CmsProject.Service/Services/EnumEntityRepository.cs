using CmsProject.DataLayer.Context;
using CmsProject.DomainClass.EnumEntity;
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
    /// موجودیت مقادیر شمارشی - اینام
    /// </summary>
    public class EnumEntityRepository : IEnumEntityRepository
    {

        private UniversityWorker_Context _context;
        private DbSet<EnumEntity> _dbSet;

        public EnumEntityRepository(UniversityWorker_Context context)
        {
            _context = context;
            _dbSet = context.Set<EnumEntity>();
        }


        /// <summary>
        /// بدست آوردن مقادیر شمارشی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه مقادیر شمارشی</param>
        /// <returns>رکورد مقادیر شمارشی</returns>
        public EnumEntity GetEnumEntityById(int id) => _dbSet.Find(id);


        /// <summary>
        /// بدست آوردن مقادیر شمارشی براساس شناسه به صورت غیرهمزمان
        /// </summary>
        /// <param name="id">شناسه مقادیر شمارشی</param>
        /// <returns>رکورد مقادیر شمارشی</returns>
        public async Task<EnumEntity> GetEnumEntityByIdAsync(int id) => await _dbSet.FindAsync(id);


        /// <summary>
        /// بدست آوردن مقادیر شمارشی براساس شرط
        /// </summary>
        /// <param name="where">شرط مقادیر شمارشی</param>
        /// <returns>رکورد مقادیر شمارشی</returns>
        public EnumEntity FirstOrDefaultEnumEntity(Expression<Func<EnumEntity, bool>> where) => _dbSet.FirstOrDefault(where);


        /// <summary>
        /// ثبت رکورد جدید مقادیر شمارشی
        /// </summary>
        /// <param name="entity">رکورد مقادیر شمارشی</param>
        public void InsertEnumEntity(EnumEntity entity) => _dbSet.Add(entity);


        /// <summary>
        /// ویرایش رکورد مقادیر شمارشی
        /// </summary>
        /// <param name="entity">رکورد مقادیر شمارشی</param>
        public void UpdateEnumEntity(EnumEntity entity) => _context.Entry(entity).State = EntityState.Modified;


        /// <summary>
        /// حذف رکورد مقادیر شمارشی
        /// </summary>
        /// <param name="entity">رکورد مقادیر شمارشی</param>
        public void DeleteEnumEntity(EnumEntity entity) => _context.Entry(entity).State = EntityState.Deleted;


        /// <summary>
        /// حذف مقادیر شمارشی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه مقادیر شمارشی</param>
        public void DeleteEnumEntityById(int id) => DeleteEnumEntity(GetEnumEntityById(id));


        /// <summary>
        /// بدست آوردن کلیه اطلاعات مقادیر شمارشی
        /// </summary>
        /// <returns>لیست دزس</returns>
        public IEnumerable<EnumEntity> GetAllEnumEntity() => _dbSet.ToList();


        /// <summary>
        /// بدست آوردن لیستی از مقادیر شمارشیها بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد مقادیر شمارشی</returns>
        public IEnumerable<EnumEntity> GetWhereEnumEntity(Expression<Func<EnumEntity, bool>> where)
        {
            IQueryable<EnumEntity> queryable = _dbSet;
            if (where != null)
            {
                queryable.Where(where);
            }
            return queryable;
        }


        /// <summary>
        /// بدست آوردن تعداد مقادیر شمارشی
        /// </summary>
        /// <returns>تعداد مقادیر شمارشی</returns>
        public int CountAllEnumEntity() => _dbSet.Count();


        /// <summary>
        /// بدست آوردن تعداد مقادیر شمارشی براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد مقادیر شمارشی</returns>
        public int CountWhereEnumEntity(Expression<Func<EnumEntity, bool>> where) => _dbSet.Count(where);


        /// <summary>
        /// بررسی وجود رکورد مقادیر شمارشی براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        public bool IsExistEnumEntity(Expression<Func<EnumEntity, bool>> Where) => _dbSet.Any(Where);


        /// <summary>
        /// جستجوی مقادیر شمارشی
        /// </summary>
        /// <param name="param">پارامتر جستجو</param>
        /// <returns>لیست مقادیر شمارشی</returns>
        public IEnumerable<EnumEntity> SearchEnumEntity(string param)
        {
            var lsit = _dbSet.Where(p => p.Title.Contains(param)
                                        || p.GroupEnumEn.Contains(param)
                    ).ToList();
            return lsit.Distinct().ToList();
        }


        /// <summary>
        /// لیست مقادیر شمارشی به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست مقادیر شمارشی</returns>
        public PagedResult<EnumEntity> GetAllEnumEntitys_Paging(int page = 1, int pageSize = 10)
        {
            return _context.EnumEntities.GetPaged(page, pageSize);
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
using CmsProject.DataLayer.Context;
using CmsProject.DomainClass.Lesson;
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
    /// توابع درس
    /// </summary>
    public class LessonRepository : ILessonRepository
    {

        private UniversityWorker_Context _context;
        private DbSet<Lesson> _dbSet;

        public LessonRepository(UniversityWorker_Context context)
        {
            _context = context;
            _dbSet = context.Set<Lesson>();
        }


        /// <summary>
        /// بدست آوردن درس براساس شناسه
        /// </summary>
        /// <param name="id">شناسه درس</param>
        /// <returns>رکورد درس</returns>
        public Lesson GetLessonById(int id) => _dbSet.Find(id);


        /// <summary>
        /// بدست آوردن درس براساس شناسه به صورت غیرهمزمان
        /// </summary>
        /// <param name="id">شناسه درس</param>
        /// <returns>رکورد درس</returns>
        public async Task<Lesson> GetLessonByIdAsync(int id) => await _dbSet.FindAsync(id);


        /// <summary>
        /// بدست آوردن درس براساس شرط
        /// </summary>
        /// <param name="where">شرط درس</param>
        /// <returns>رکورد درس</returns>
        public Lesson FirstOrDefaultLesson(Expression<Func<Lesson, bool>> where) => _dbSet.FirstOrDefault(where);


        /// <summary>
        /// ثبت رکورد جدید درس
        /// </summary>
        /// <param name="entity">رکورد درس</param>
        public void InsertLesson(Lesson entity) => _dbSet.Add(entity);


        /// <summary>
        /// ویرایش رکورد درس
        /// </summary>
        /// <param name="entity">رکورد درس</param>
        public void UpdateLesson(Lesson entity) => _context.Entry(entity).State = EntityState.Modified;


        /// <summary>
        /// حذف رکورد درس
        /// </summary>
        /// <param name="entity">رکورد درس</param>
        public void DeleteLesson(Lesson entity) => _context.Entry(entity).State = EntityState.Deleted;


        /// <summary>
        /// حذف درس براساس شناسه
        /// </summary>
        /// <param name="id">شناسه درس</param>
        public void DeleteLessonById(int id) => DeleteLesson(GetLessonById(id));


        /// <summary>
        /// بدست آوردن کلیه اطلاعات درس
        /// </summary>
        /// <returns>لیست دزس</returns>
        public IEnumerable<Lesson> GetAllLesson() => _dbSet.ToList();


        /// <summary>
        /// بدست آوردن لیستی از درسها بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد درس</returns>
        public IEnumerable<Lesson> GetWhereLesson(Expression<Func<Lesson, bool>> where)
        {
            IQueryable<Lesson> queryable = _dbSet;
            if (where != null)
            {
                queryable.Where(where);
            }
            return queryable;
        }


        /// <summary>
        /// بدست آوردن تعداد درس
        /// </summary>
        /// <returns>تعداد درس</returns>
        public int CountAllLesson() => _dbSet.Count();


        /// <summary>
        /// بدست آوردن تعداد درس براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد درس</returns>
        public int CountWhereLesson(Expression<Func<Lesson, bool>> where) => _dbSet.Count(where);


        /// <summary>
        /// بررسی وجود رکورد درس براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        public bool IsExistLesson(Expression<Func<Lesson, bool>> Where) => _dbSet.Any(Where);


        /// <summary>
        /// جستجوی درس
        /// </summary>
        /// <param name="param">پارامتر جستجو</param>
        /// <returns>لیست درس</returns>
        public IEnumerable<Lesson> SearchLesson(string param)
        {
            var lsit = _dbSet.Where(p => p.Title.Contains(param) ||
                                         p.Code.Contains(param) ||
                                         p.LessonType.Contains(param)
                    ).ToList();
            return lsit.Distinct().ToList();
        }


        /// <summary>
        /// لیست درس به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست درس</returns>
        public PagedResult<Lesson> GetAllLessons_Paging(int page = 1, int pageSize = 10)
        {
            return _context.Lessons.GetPaged(page, pageSize);
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
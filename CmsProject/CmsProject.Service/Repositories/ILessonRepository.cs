using CmsProject.DomainClass.Lesson;
using CmsProject.Utilities.Paging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CmsProject.Service.Repositories
{
    /// <summary>
    /// توابع درس
    /// </summary>
    public interface ILessonRepository : IDisposable
    {

        /// <summary>
        /// بدست آوردن درس براساس شناسه
        /// </summary>
        /// <param name="id">شناسه درس</param>
        /// <returns>رکورد درس</returns>
        Lesson GetLessonById(int id);


        /// <summary>
        /// بدست آوردن درس براساس شناسه به صورت غیرهمزمان
        /// </summary>
        /// <param name="id">شناسه درس</param>
        /// <returns>رکورد درس</returns>
        Task<Lesson> GetLessonByIdAsync(int id);


        /// <summary>
        /// بدست آوردن درس براساس شرط
        /// </summary>
        /// <param name="where">شرط درس</param>
        /// <returns>رکورد درس</returns>
        Lesson FirstOrDefaultLesson(Expression<Func<Lesson, bool>> where);


        /// <summary>
        /// ثبت رکورد جدید درس
        /// </summary>
        /// <param name="entity">رکورد درس</param>
        void InsertLesson(Lesson entity);


        /// <summary>
        /// ویرایش رکورد درس
        /// </summary>
        /// <param name="entity">رکورد درس</param>
        void UpdateLesson(Lesson entity);


        /// <summary>
        /// حذف رکورد درس
        /// </summary>
        /// <param name="entity">رکورد درس</param>
        void DeleteLesson(Lesson entity);


        /// <summary>
        /// حذف درس براساس شناسه
        /// </summary>
        /// <param name="id">شناسه درس</param>
        void DeleteLessonById(int id);


        /// <summary>
        /// بدست آوردن کلیه درس ها
        /// </summary>
        /// <returns>لیست درس ها</returns>
        IEnumerable<Lesson> GetAllLesson();


        /// <summary>
        /// بدست آوردن لیستی از درس ها بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد درس</returns>
        IEnumerable<Lesson> GetWhereLesson(Expression<Func<Lesson, bool>> where);


        /// <summary>
        /// بدست آوردن تعداد درس
        /// </summary>
        /// <returns>تعداد درس</returns>
        int CountAllLesson();


        /// <summary>
        /// بدست آوردن تعداد درس براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد درس</returns>
        int CountWhereLesson(Expression<Func<Lesson, bool>> where);


        /// <summary>
        /// بررسی وجود رکورد درس براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        bool IsExistLesson(Expression<Func<Lesson, bool>> Where);


        /// <summary>
        /// جستجوی درس
        /// </summary>
        /// <param name="param">پارامتر جستجو</param>
        /// <returns>لیست درس</returns>
        IEnumerable<Lesson> SearchLesson(string param);


        /// <summary>
        /// لیست درس به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست درس</returns>
        PagedResult<Lesson> GetAllLessons_Paging(int page = 1, int pageSize = 10);


        /// <summary>
        /// خالی کردن عملیات از حافظه
        /// </summary>
        void Save();

    }
}
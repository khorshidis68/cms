using CmsProject.DomainClass.Grade;
using CmsProject.Utilities.Paging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CmsProject.Service.Repositories
{
    /// <summary>
    /// توابع مقطع تحصیلی
    /// </summary>
    public interface IGradeRepository : IDisposable
    {
        /// <summary>
        /// بدست آوردن مقطع تحصیلی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه مقطع تحصیلی</param>
        /// <returns>رکورد مقطع تحصیلی</returns>
        Grade GetGradeById(int id);


        /// <summary>
        /// بدست آوردن مقطع تحصیلی براساس شناسه به صورت غیرهمزمان
        /// </summary>
        /// <param name="id">شناسه مقطع تحصیلی</param>
        /// <returns>رکورد مقطع تحصیلی</returns>
        Task<Grade> GetGradeByIdAsync(int id);


        /// <summary>
        /// بدست آوردن مقطع تحصیلی براساس شرط
        /// </summary>
        /// <param name="where">شرط مقطع تحصیلی</param>
        /// <returns>رکورد مقطع تحصیلی</returns>
        Grade FirstOrDefaultGrade(Expression<Func<Grade, bool>> where);


        /// <summary>
        /// ثبت رکورد جدید مقطع تحصیلی
        /// </summary>
        /// <param name="entity">رکورد مقطع تحصیلی</param>
        void InsertGrade(Grade entity);


        /// <summary>
        /// ویرایش رکورد مقطع تحصیلی
        /// </summary>
        /// <param name="entity">رکورد مقطع تحصیلی</param>
        void UpdateGrade(Grade entity);


        /// <summary>
        /// حذف رکورد مقطع تحصیلی
        /// </summary>
        /// <param name="entity">رکورد مقطع تحصیلی</param>
        void DeleteGrade(Grade entity);


        /// <summary>
        /// حذف مقطع تحصیلی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه مقطع تحصیلی</param>
        void DeleteGradeById(int id);


        /// <summary>
        /// بدست آوردن کلیه مقطع تحصیلی ها
        /// </summary>
        /// <returns>لیست مقطع تحصیلی ها</returns>
        IEnumerable<Grade> GetAllGrade();


        /// <summary>
        /// بدست آوردن لیستی از مقطع تحصیلی ها بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد مقطع تحصیلی</returns>
        IEnumerable<Grade> GetWhereGrade(Expression<Func<Grade, bool>> where);


        /// <summary>
        /// بدست آوردن تعداد مقطع تحصیلی
        /// </summary>
        /// <returns>تعداد مقطع تحصیلی</returns>
        int CountAllGrade();


        /// <summary>
        /// بدست آوردن تعداد مقطع تحصیلی براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد مقطع تحصیلی</returns>
        int CountWhereGrade(Expression<Func<Grade, bool>> where);


        /// <summary>
        /// بررسی وجود رکورد مقطع تحصیلی براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        bool IsExistGrade(Expression<Func<Grade, bool>> Where);


        /// <summary>
        /// جستجوی مقطع تحصیلی
        /// </summary>
        /// <param name="param">پارامتر جستجو</param>
        /// <returns>لیست مقطع تحصیلی</returns>
        IEnumerable<Grade> SearchGrade(string param);


        /// <summary>
        /// لیست مقطع تحصیلی به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست مقطع تحصیلی</returns>
        PagedResult<Grade> GetAllGrades_Paging(int page = 1, int pageSize = 10);


        /// <summary>
        /// خالی کردن عملیات از حافظه
        /// </summary>
        void Save();
    }
}
using CmsProject.DomainClass.Major;
using CmsProject.Utilities.Paging;
using CmsProject.ViewModel.Major;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CmsProject.Service.Repositories
{
    /// <summary>
    /// توابع رشته تحصیلی
    /// </summary>
    public interface IMajorRepository : IDisposable
    {
        /// <summary>
        /// بدست آوردن رشته تحصیلی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه رشته تحصیلی</param>
        /// <returns>رکورد رشته تحصیلی</returns>
        Major GetMajorById(int id);


        /// <summary>
        /// بدست آوردن رشته تحصیلی براساس شناسه به صورت غیرهمزمان
        /// </summary>
        /// <param name="id">شناسه رشته تحصیلی</param>
        /// <returns>رکورد رشته تحصیلی</returns>
        Task<Major> GetMajorByIdAsync(int id);


        /// <summary>
        /// بدست آوردن رشته تحصیلی براساس شرط
        /// </summary>
        /// <param name="where">شرط رشته تحصیلی</param>
        /// <returns>رکورد رشته تحصیلی</returns>
        Major FirstOrDefaultMajor(Expression<Func<Major, bool>> where);


        /// <summary>
        /// ثبت رکورد جدید رشته تحصیلی
        /// </summary>
        /// <param name="entity">رکورد رشته تحصیلی</param>
        void InsertMajor(Major entity);


        /// <summary>
        /// ویرایش رکورد رشته تحصیلی
        /// </summary>
        /// <param name="entity">رکورد رشته تحصیلی</param>
        void UpdateMajor(Major entity);


        /// <summary>
        /// حذف رکورد رشته تحصیلی
        /// </summary>
        /// <param name="entity">رکورد رشته تحصیلی</param>
        void DeleteMajor(Major entity);


        /// <summary>
        /// حذف رشته تحصیلی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه رشته تحصیلی</param>
        void DeleteMajorById(int id);


        /// <summary>
        /// بدست آوردن کلیه رشته تحصیلی ها
        /// </summary>
        /// <returns>لیست رشته تحصیلی ها</returns>
        IEnumerable<Major> GetAllMajor();


        /// <summary>
        /// بدست آوردن لیستی از رشته تحصیلی ها بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد رشته تحصیلی</returns>
        IEnumerable<Major> GetWhereMajor(Expression<Func<Major, bool>> where);


        /// <summary>
        /// بدست آوردن تعداد رشته تحصیلی
        /// </summary>
        /// <returns>تعداد رشته تحصیلی</returns>
        int CountAllMajor();


        /// <summary>
        /// بدست آوردن تعداد رشته تحصیلی براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد رشته تحصیلی</returns>
        int CountWhereMajor(Expression<Func<Major, bool>> where);


        /// <summary>
        /// بررسی وجود رکورد رشته تحصیلی براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        bool IsExistMajor(Expression<Func<Major, bool>> Where);


        /// <summary>
        /// جستجوی رشته تحصیلی
        /// </summary>
        /// <param name="param">پارامتر جستجو</param>
        /// <returns>لیست رشته تحصیلی</returns>
        IEnumerable<Major> SearchMajor(string param);


        /// <summary>
        /// لیست رشته تحصیلی به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست رشته تحصیلی</returns>
        PagedResult<Major> GetAllMajors_Paging(int page = 1, int pageSize = 10);


        /// <summary>
        /// خالی کردن عملیات از حافظه
        /// </summary>
        void Save();
    }
}
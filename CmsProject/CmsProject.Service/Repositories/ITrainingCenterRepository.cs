using CmsProject.DomainClass.TrainingCenter;
using CmsProject.Utilities.Paging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CmsProject.Service.Repositories
{
    /// <summary>
    /// توابع مرکز آموزشی
    /// </summary>
    public interface ITrainingCenterRepository
    {
        /// <summary>
        /// بدست آوردن مرکز آموزشی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه مرکز آموزشی</param>
        /// <returns>رکورد مرکز آموزشی</returns>
        TrainingCenter GetTrainingCenterById(int id);


        /// <summary>
        /// بدست آوردن مرکز آموزشی براساس شناسه به صورت غیرهمزمان
        /// </summary>
        /// <param name="id">شناسه مرکز آموزشی</param>
        /// <returns>رکورد مرکز آموزشی</returns>
        Task<TrainingCenter> GetTrainingCenterByIdAsync(int id);


        /// <summary>
        /// بدست آوردن مرکز آموزشی براساس شرط
        /// </summary>
        /// <param name="where">شرط مرکز آموزشی</param>
        /// <returns>رکورد مرکز آموزشی</returns>
        TrainingCenter FirstOrDefaultTrainingCenter(Expression<Func<TrainingCenter, bool>> where);


        /// <summary>
        /// ثبت رکورد جدید مرکز آموزشی
        /// </summary>
        /// <param name="entity">رکورد مرکز آموزشی</param>
        void InsertTrainingCenter(TrainingCenter entity);


        /// <summary>
        /// ویرایش رکورد مرکز آموزشی
        /// </summary>
        /// <param name="entity">رکورد مرکز آموزشی</param>
        void UpdateTrainingCenter(TrainingCenter entity);


        /// <summary>
        /// حذف رکورد مرکز آموزشی
        /// </summary>
        /// <param name="entity">رکورد مرکز آموزشی</param>
        void DeleteTrainingCenter(TrainingCenter entity);


        /// <summary>
        /// حذف مرکز آموزشی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه مرکز آموزشی</param>
        void DeleteTrainingCenterById(int id);


        /// <summary>
        /// بدست آوردن کلیه مرکز آموزشی ها
        /// </summary>
        /// <returns>لیست مرکز آموزشی ها</returns>
        IEnumerable<TrainingCenter> GetAllTrainingCenter();


        /// <summary>
        /// بدست آوردن لیستی از مرکز آموزشی ها بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد مرکز آموزشی</returns>
        IEnumerable<TrainingCenter> GetWhereTrainingCenter(Expression<Func<TrainingCenter, bool>> where);


        /// <summary>
        /// بدست آوردن تعداد مرکز آموزشی
        /// </summary>
        /// <returns>تعداد مرکز آموزشی</returns>
        int CountAllTrainingCenter();


        /// <summary>
        /// بدست آوردن تعداد مرکز آموزشی براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد مرکز آموزشی</returns>
        int CountWhereTrainingCenter(Expression<Func<TrainingCenter, bool>> where);


        /// <summary>
        /// بررسی وجود رکورد مرکز آموزشی براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        bool IsExistTrainingCenter(Expression<Func<TrainingCenter, bool>> Where);


        /// <summary>
        /// جستجوی مرکز آموزشی
        /// </summary>
        /// <param name="param">پارامتر جستجو</param>
        /// <returns>لیست مرکز آموزشی</returns>
        IEnumerable<TrainingCenter> SearchTrainingCenter(string param);


        /// <summary>
        /// لیست مرکز آموزشی به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست مرکز آموزشی</returns>
        PagedResult<TrainingCenter> GetAllTrainingCenters_Paging(int page = 1, int pageSize = 10);


        /// <summary>
        /// خالی کردن عملیات از حافظه
        /// </summary>
        void Save();
    }
}
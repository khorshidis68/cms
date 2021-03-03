using CmsProject.DomainClass.EnumEntity;
using CmsProject.Utilities.Paging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CmsProject.Service.Repositories
{
    /// <summary>
    /// موجودیت مقادیر شمارشی - اینام
    /// </summary>
    public interface IEnumEntityRepository
    {
        /// <summary>
        /// بدست آوردن مقادیر شمارشی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه مقادیر شمارشی</param>
        /// <returns>رکورد مقادیر شمارشی</returns>
        EnumEntity GetEnumEntityById(int id);


        /// <summary>
        /// بدست آوردن مقادیر شمارشی براساس شناسه به صورت غیرهمزمان
        /// </summary>
        /// <param name="id">شناسه مقادیر شمارشی</param>
        /// <returns>رکورد مقادیر شمارشی</returns>
        Task<EnumEntity> GetEnumEntityByIdAsync(int id);


        /// <summary>
        /// بدست آوردن مقادیر شمارشی براساس شرط
        /// </summary>
        /// <param name="where">شرط مقادیر شمارشی</param>
        /// <returns>رکورد مقادیر شمارشی</returns>
        EnumEntity FirstOrDefaultEnumEntity(Expression<Func<EnumEntity, bool>> where);


        /// <summary>
        /// ثبت رکورد جدید مقادیر شمارشی
        /// </summary>
        /// <param name="entity">رکورد مقادیر شمارشی</param>
        void InsertEnumEntity(EnumEntity entity);


        /// <summary>
        /// ویرایش رکورد مقادیر شمارشی
        /// </summary>
        /// <param name="entity">رکورد مقادیر شمارشی</param>
        void UpdateEnumEntity(EnumEntity entity);


        /// <summary>
        /// حذف رکورد مقادیر شمارشی
        /// </summary>
        /// <param name="entity">رکورد مقادیر شمارشی</param>
        void DeleteEnumEntity(EnumEntity entity);


        /// <summary>
        /// حذف مقادیر شمارشی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه مقادیر شمارشی</param>
        void DeleteEnumEntityById(int id);


        /// <summary>
        /// بدست آوردن کلیه مقادیر شمارشی ها
        /// </summary>
        /// <returns>لیست مقادیر شمارشی ها</returns>
        IEnumerable<EnumEntity> GetAllEnumEntity();


        /// <summary>
        /// بدست آوردن لیستی از مقادیر شمارشی ها بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد مقادیر شمارشی</returns>
        IEnumerable<EnumEntity> GetWhereEnumEntity(Expression<Func<EnumEntity, bool>> where);


        /// <summary>
        /// بدست آوردن تعداد مقادیر شمارشی
        /// </summary>
        /// <returns>تعداد مقادیر شمارشی</returns>
        int CountAllEnumEntity();


        /// <summary>
        /// بدست آوردن تعداد مقادیر شمارشی براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد مقادیر شمارشی</returns>
        int CountWhereEnumEntity(Expression<Func<EnumEntity, bool>> where);


        /// <summary>
        /// بررسی وجود رکورد مقادیر شمارشی براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        bool IsExistEnumEntity(Expression<Func<EnumEntity, bool>> Where);


        /// <summary>
        /// جستجوی مقادیر شمارشی
        /// </summary>
        /// <param name="param">پارامتر جستجو</param>
        /// <returns>لیست مقادیر شمارشی</returns>
        IEnumerable<EnumEntity> SearchEnumEntity(string param);


        /// <summary>
        /// لیست مقادیر شمارشی به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست مقادیر شمارشی</returns>
        PagedResult<EnumEntity> GetAllEnumEntitys_Paging(int page = 1, int pageSize = 10);


        /// <summary>
        /// خالی کردن عملیات از حافظه
        /// </summary>
        void Save();
    }
}
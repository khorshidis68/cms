using CmsProject.DomainClass.Personel;
using CmsProject.Utilities.Paging;
using CmsProject.ViewModel.Personel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CmsProject.Service.Repositories
{
    /// <summary>
    /// موجودیت پرسنل
    /// </summary>
    public interface IPersonelRepository : IDisposable
    {
        /// <summary>
        /// بدست آوردن پرسنل براساس شناسه
        /// </summary>
        /// <param name="id">شناسه پرسنل</param>
        /// <returns>رکورد پرسنل</returns>
        Personel GetPersonelById(int id);


        /// <summary>
        /// بدست آوردن پرسنل براساس شناسه به صورت غیرهمزمان
        /// </summary>
        /// <param name="id">شناسه پرسنل</param>
        /// <returns>رکورد پرسنل</returns>
        Task<Personel> GetPersonelByIdAsync(int id);


        /// <summary>
        /// بدست آوردن پرسنل براساس شرط
        /// </summary>
        /// <param name="where">شرط پرسنل</param>
        /// <returns>رکورد پرسنل</returns>
        Personel FirstOrDefaultPersonel(Expression<Func<Personel, bool>> where);


        /// <summary>
        /// ثبت رکورد جدید پرسنل
        /// </summary>
        /// <param name="entity">رکورد پرسنل</param>
        void InsertPersonel(Personel entity);


        /// <summary>
        /// ویرایش رکورد پرسنل
        /// </summary>
        /// <param name="entity">رکورد پرسنل</param>
        void UpdatePersonel(Personel entity);


        /// <summary>
        /// حذف رکورد پرسنل
        /// </summary>
        /// <param name="entity">رکورد پرسنل</param>
        void DeletePersonel(Personel entity);


        /// <summary>
        /// حذف پرسنل براساس شناسه
        /// </summary>
        /// <param name="id">شناسه پرسنل</param>
        void DeletePersonelById(int id);


        /// <summary>
        /// بدست آوردن کلیه پرسنل ها
        /// </summary>
        /// <returns>لیست پرسنل ها</returns>
        IEnumerable<Personel> GetAllPersonel();


        /// <summary>
        /// بدست آوردن لیستی از پرسنل ها بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد پرسنل</returns>
        IEnumerable<Personel> GetWherePersonel(Expression<Func<Personel, bool>> where);


        /// <summary>
        /// بدست آوردن تعداد پرسنل
        /// </summary>
        /// <returns>تعداد پرسنل</returns>
        int CountAllPersonel();


        /// <summary>
        /// بدست آوردن تعداد پرسنل براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد پرسنل</returns>
        int CountWherePersonel(Expression<Func<Personel, bool>> where);


        /// <summary>
        /// بررسی وجود رکورد پرسنل براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        bool IsExistPersonel(Expression<Func<Personel, bool>> Where);


        /// <summary>
        /// جستجوی پرسنل
        /// </summary>
        /// <param name="param">پارامتر جستجو</param>
        /// <returns>لیست پرسنل</returns>
        IEnumerable<Personel> SearchPersonel(string param);


        /// <summary>
        /// لیست پرسنل به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست پرسنل</returns>
        PagedResult<Personel> GetAllPersonels_Paging(int page = 1, int pageSize = 10);

        /// <summary>
        /// لیست پرسنل به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست پرسنل</returns>
        PagedResult<PersonelViewModel> GetAllPersonelVM_Paging(int page = 1, int pageSize = 10);



        /// <summary>
        /// خالی کردن عملیات از حافظه
        /// </summary>
        void Save();
    }
}
using CmsProject.DomainModelClass.Page;
using CmsProject.Utilities.Paging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CmsProject.Service.Repositories
{
    /// <summary>
    /// توابع خبر
    /// </summary>
    public interface IPageRepository : IDisposable
    {

        /// <summary>
        /// بدست آوردن خبر براساس شناسه
        /// </summary>
        /// <param name="id">شناسه خبر</param>
        /// <returns>رکورد خبر</returns>
        Page GetPageById(int id);


        /// <summary>
        /// بدست آوردن خبر براساس شناسه به صورت غیرهمزمان
        /// </summary>
        /// <param name="id">شناسه خبر</param>
        /// <returns>رکورد خبر</returns>
        Task<Page> GetPageByIdAsync(int id);


        /// <summary>
        /// بدست آوردن خبر براساس شرط
        /// </summary>
        /// <param name="where">شرط خبر</param>
        /// <returns>رکورد خبر</returns>
        Page FirstOrDefaultPage(Expression<Func<Page, bool>> where);


        /// <summary>
        /// ثبت رکورد جدید خبر
        /// </summary>
        /// <param name="entity">رکورد خبر</param>
        void InsertPage(Page entity);


        /// <summary>
        /// ویرایش رکورد خبر
        /// </summary>
        /// <param name="entity">رکورد خبر</param>
        void UpdatePage(Page entity);


        /// <summary>
        /// حذف رکورد خبر
        /// </summary>
        /// <param name="entity">رکورد خبر</param>
        void DeletePage(Page entity);


        /// <summary>
        /// حذف خبر براساس شناسه
        /// </summary>
        /// <param name="id">شناسه خبر</param>
        void DeletePageById(int id);


        /// <summary>
        /// بدست آوردن کلیه اطلاعات خبر
        /// </summary>
        /// <returns>لیست خبر</returns>
        IEnumerable<Page> GetAllPage();


        /// <summary>
        /// بدست آوردن لیستی از خبرها بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد خبر</returns>
        IEnumerable<Page> GetWherePage(Expression<Func<Page, bool>> where);


        /// <summary>
        /// بدست آوردن تعداد خبر
        /// </summary>
        /// <returns>تعداد خبر</returns>
        int CountAllPage();


        /// <summary>
        /// بدست آوردن تعداد خبر براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد خبر</returns>
        int CountWherePage(Expression<Func<Page, bool>> where);


        /// <summary>
        /// بررسی وجود رکورد خبر براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        bool IsExistPage(Expression<Func<Page, bool>> Where);


        /// <summary>
        /// بدست آوردن پربازدیدترین اخبار
        /// </summary>
        /// <param name="take">تعداد خبر</param>
        /// <returns>لیست خبر</returns>
        IEnumerable<Page> GetTopPage(int take=5);


        /// <summary>
        /// بدست آوردن لیست خبرهای موجود در اسلایدر
        /// </summary>
        /// <returns>لیست خبر</returns>
        IEnumerable<Page> GetPagesInSlider();


        /// <summary>
        /// بدست آوردن لیست آخرین اخبار
        /// </summary>
        /// <param name="take">تعداد خبر</param>
        /// <returns>لیست خبر</returns>
        IEnumerable<Page> GetLatesPages(int take=5);


        /// <summary>
        /// بدست آوردن لیست خبرهای مربوط به گروه خبری
        /// </summary>
        /// <param name="groupId">شناسه گروه خبری</param>
        /// <returns>لیست خبر</returns>
        IEnumerable<Page> GetPagesByGroupId(int groupId);


        /// <summary>
        /// جستجوی خبر
        /// </summary>
        /// <param name="param">پارامتر جستجو</param>
        /// <returns>لیست خبر</returns>
        IEnumerable<Page> SearchPage(string param);


        /// <summary>
        /// لیست خبر به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست خبر</returns>
        PagedResult<Page> GetAllPages_Paging(int page = 1, int pageSize = 10);


        /// <summary>
        /// خالی کردن عملیات از حافظه
        /// </summary>
        void Save();

    }
}
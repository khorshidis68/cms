using CmsProject.DomainModelClass.PageGroup;
using CmsProject.Utilities.Paging;
using CmsProject.ViewModel.Page;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CmsProject.Service.Repositories
{
    /// <summary>
    /// توابع گروه خبری
    /// </summary>
    public interface IPageGroupRepository : IDisposable
    {
        /// <summary>
        /// بدست آوردن گروه خبری براساس شناسه
        /// </summary>
        /// <param name="id">شناسه گروه خبری</param>
        /// <returns>رکورد گروه خبری</returns>
        PageGroup GetPageGroupById(int id);


        /// <summary>
        /// بدست آوردن گروه خبری براساس شرط
        /// </summary>
        /// <param name="where">شرط گروه خبری</param>
        /// <returns>رکورد گروه خبری</returns>
        PageGroup FirstOrDefaultPageGroup(Expression<Func<PageGroup, bool>> where);


        /// <summary>
        /// ثبت رکورد جدید گروه خبری
        /// </summary>
        /// <param name="entity">رکورد گروه خبری</param>
        void InsertPageGroup(PageGroup entity);


        /// <summary>
        /// ویرایش رکورد گروه خبری
        /// </summary>
        /// <param name="entity">رکورد گروه خبری</param>
        void UpdatePageGroup(PageGroup entity);


        /// <summary>
        /// حذف رکورد گروه خبری
        /// </summary>
        /// <param name="entity">رکورد گروه خبری</param>
        void DeletePageGroup(PageGroup entity);


        /// <summary>
        /// حذف گروه خبری براساس شناسه
        /// </summary>
        /// <param name="id">شناسه گروه خبری</param>
        void DeletePageGroupById(int id);


        /// <summary>
        /// بدست آوردن کلیه اطلاعات گروه خبری
        /// </summary>
        /// <returns>لیست گروه خبری</returns>
        IEnumerable<PageGroup> GetAllPageGroup();


        /// <summary>
        /// بدست آوردن لیستی از گروه های خبری بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد گروه خبری</returns>
        IEnumerable<PageGroup> GetWherePageGroup(Expression<Func<PageGroup, bool>> where);


        /// <summary>
        /// بدست آوردن تعداد گروه خبری
        /// </summary>
        /// <returns>تعداد گروه خبری</returns>
        int CountAllPageGroup();


        /// <summary>
        /// بدست آوردن تعداد گروه خبری براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد گروه خبری</returns>
        int CountWherePageGroup(Expression<Func<PageGroup, bool>> where);


        /// <summary>
        /// بررسی وجود رکورد گروه خبری براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        bool IsExistPageGroup(Expression<Func<PageGroup, bool>> Where);


        /// <summary>
        /// نمایش لیست گروه خبری
        /// </summary>
        /// <returns>لیست گروه خبری</returns>
        List<ShowGroupsViewModel> GetListGroups();


        /// <summary>
        /// بدست آوردن تعداد اخبار براساس شناسه گروه خبری
        /// </summary>
        /// <param name="pageGroupId">شناسه گروه خبری</param>
        /// <returns>تعداد اخبار</returns>
        Task<ShowGroupsViewModel> GetPageCountByGroupIdAsync(int pageGroupId);


        /// <summary>
        /// لیست گروه خبری به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست گروه خبری</returns>
        PagedResult<PageGroup> GetAllPageGroups_Paging(int page = 1,int pageSize = 10);


        /// <summary>
        /// ذخیره سازی اطلاعات
        /// </summary>
        void Save();
    }
}
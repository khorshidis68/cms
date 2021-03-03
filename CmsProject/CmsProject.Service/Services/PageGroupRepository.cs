using CmsProject.DataLayer.Context;
using CmsProject.DomainModelClass.PageGroup;
using CmsProject.Service.Repositories;
using CmsProject.ViewModel.Page;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CmsProject.Utilities.Paging;
using System.Threading.Tasks;

namespace CmsProject.Service.Services
{
    /// <summary>
    /// توابع گروه خبری
    /// </summary>
    public class PageGroupRepository : IPageGroupRepository
    {
        private UniversityWorker_Context _context;
        private DbSet<PageGroup> _dbSet;

        public PageGroupRepository(UniversityWorker_Context context)
        {
            _context = context;
            _dbSet = context.Set<PageGroup>();
        }


        /// <summary>
        /// بدست آوردن گروه خبری براساس شناسه
        /// </summary>
        /// <param name="id">شناسه گروه خبری</param>
        /// <returns>رکورد گروه خبری</returns>
        public PageGroup GetPageGroupById(int id) => _dbSet.Find(id);


        /// <summary>
        /// بدست آوردن گروه خبری براساس شرط
        /// </summary>
        /// <param name="where">شرط گروه خبری</param>
        /// <returns>رکورد گروه خبری</returns>
        public PageGroup FirstOrDefaultPageGroup(Expression<Func<PageGroup, bool>> where) => _dbSet.FirstOrDefault(where);


        /// <summary>
        /// ثبت رکورد جدید گروه خبری
        /// </summary>
        /// <param name="entity">رکورد گروه خبری</param>
        public void InsertPageGroup(PageGroup entity) => _dbSet.Add(entity);


        /// <summary>
        /// ویرایش رکورد گروه خبری
        /// </summary>
        /// <param name="entity">رکورد گروه خبری</param>
        public void UpdatePageGroup(PageGroup entity) => _context.Entry(entity).State = EntityState.Modified;


        /// <summary>
        /// حذف رکورد گروه خبری
        /// </summary>
        /// <param name="entity">رکورد گروه خبری</param>
        public void DeletePageGroup(PageGroup entity) => _context.Entry(entity).State = EntityState.Deleted;


        /// <summary>
        /// حذف گروه خبری براساس شناسه
        /// </summary>
        /// <param name="id">شناسه گروه خبری</param>
        public void DeletePageGroupById(int id) => DeletePageGroup(GetPageGroupById(id));


        /// <summary>
        /// بدست آوردن کلیه اطلاعات گروه خبری
        /// </summary>
        /// <returns>لیست گروه خبری</returns>
        public IEnumerable<PageGroup> GetAllPageGroup() => _dbSet.ToList();


        /// <summary>
        /// بدست آوردن لیستی از گروه های خبری بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد گروه خبری</returns>
        public IEnumerable<PageGroup> GetWherePageGroup(Expression<Func<PageGroup, bool>> where)
        {
            IQueryable<PageGroup> queryable = _dbSet;
            if (where != null)
            {
                queryable.Where(where);
            }
            return queryable;
        }


        /// <summary>
        /// بدست آوردن تعداد گروه خبری
        /// </summary>
        /// <returns>تعداد گروه خبری</returns>
        public int CountAllPageGroup() => _dbSet.Count();


        /// <summary>
        /// بدست آوردن تعداد گروه خبری براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد گروه خبری</returns>
        public int CountWherePageGroup(Expression<Func<PageGroup, bool>> where) => _dbSet.Count(where);


        /// <summary>
        /// بررسی وجود رکورد گروه خبری براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        public bool IsExistPageGroup(Expression<Func<PageGroup, bool>> Where) => _dbSet.Any(Where);


        /// <summary>
        /// بدست آوردن لیست گروه خبری بر اساس ویو مدل
        /// </summary>
        /// <returns>لیست گروه خبری</returns>
        public List<ShowGroupsViewModel> GetListGroups()
        {
            return _dbSet.Select(grp => new ShowGroupsViewModel()
            {
                ID = grp.ID,
                GroupTitle = grp.GroupTitle,
                PageCount = grp.Pages.Count
            }).ToList();
        }


        /// <summary>
        /// بدست آوردن تعداد اخبار براساس شناسه گروه خبری
        /// </summary>
        /// <param name="pageGroupId">شناسه گروه خبری</param>
        /// <returns>تعداد اخبار</returns>
        public async Task<ShowGroupsViewModel> GetPageCountByGroupIdAsync(int pageGroupId)
        {
            return await _dbSet.Where(pg => pg.ID == pageGroupId).Select(grp => new ShowGroupsViewModel()
            {
                ID = grp.ID,
                GroupTitle = grp.GroupTitle,
                PageCount = grp.Pages.Count
            }).FirstOrDefaultAsync();
        }


        /// <summary>
        /// لیست گروه خبری به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست گروه خبری</returns>
        public PagedResult<PageGroup> GetAllPageGroups_Paging(int page = 1,int pageSize = 10)
        {
            return _context.PageGroups.GetPaged(page, pageSize);
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
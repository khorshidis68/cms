using CmsProject.DataLayer.Context;
using CmsProject.DomainModelClass.Page;
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
    /// توابع خبر
    /// </summary>
    public class PageRepository : IPageRepository
    {

        private UniversityWorker_Context _context;
        private DbSet<Page> _dbSet;

        public PageRepository(UniversityWorker_Context context)
        {
            _context = context;
            _dbSet = context.Set<Page>();
        }


        /// <summary>
        /// بدست آوردن خبر براساس شناسه
        /// </summary>
        /// <param name="id">شناسه خبر</param>
        /// <returns>رکورد خبر</returns>
        public Page GetPageById(int id) => _dbSet.Find(id);


        /// <summary>
        /// بدست آوردن خبر براساس شناسه به صورت غیرهمزمان
        /// </summary>
        /// <param name="id">شناسه خبر</param>
        /// <returns>رکورد خبر</returns>
        public async Task<Page> GetPageByIdAsync(int id) => await _dbSet.FindAsync(id);


        /// <summary>
        /// بدست آوردن خبر براساس شرط
        /// </summary>
        /// <param name="where">شرط خبر</param>
        /// <returns>رکورد خبر</returns>
        public Page FirstOrDefaultPage(Expression<Func<Page, bool>> where) => _dbSet.FirstOrDefault(where);


        /// <summary>
        /// ثبت رکورد جدید خبر
        /// </summary>
        /// <param name="entity">رکورد خبر</param>
        public void InsertPage(Page entity) => _dbSet.Add(entity);


        /// <summary>
        /// ویرایش رکورد خبر
        /// </summary>
        /// <param name="entity">رکورد خبر</param>
        public void UpdatePage(Page entity) => _context.Entry(entity).State = EntityState.Modified;


        /// <summary>
        /// حذف رکورد خبر
        /// </summary>
        /// <param name="entity">رکورد خبر</param>
        public void DeletePage(Page entity) => _context.Entry(entity).State = EntityState.Deleted;


        /// <summary>
        /// حذف خبر براساس شناسه
        /// </summary>
        /// <param name="id">شناسه خبر</param>
        public void DeletePageById(int id) => DeletePage(GetPageById(id));


        /// <summary>
        /// بدست آوردن کلیه اطلاعات خبر
        /// </summary>
        /// <returns>لیست خبر</returns>
        public IEnumerable<Page> GetAllPage() => _dbSet.ToList();


        /// <summary>
        /// بدست آوردن لیستی از خبرها بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد خبر</returns>
        public IEnumerable<Page> GetWherePage(Expression<Func<Page, bool>> where)
        {
            IQueryable<Page> queryable = _dbSet;
            if (where != null)
            {
                queryable.Where(where);
            }
            return queryable;
        }


        /// <summary>
        /// بدست آوردن تعداد خبر
        /// </summary>
        /// <returns>تعداد خبر</returns>
        public int CountAllPage() => _dbSet.Count();


        /// <summary>
        /// بدست آوردن تعداد خبر براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد خبر</returns>
        public int CountWherePage(Expression<Func<Page, bool>> where) => _dbSet.Count(where);


        /// <summary>
        /// بررسی وجود رکورد خبر براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        public bool IsExistPage(Expression<Func<Page, bool>> Where) => _dbSet.Any(Where);


        /// <summary>
        /// بدست آوردن پربازدیدترین اخبار
        /// </summary>
        /// <param name="take">تعداد خبر</param>
        /// <returns>لیست خبر</returns>
        public IEnumerable<Page> GetTopPage(int take = 4)
        {
            return _dbSet.OrderByDescending(p => p.PageVisit).Take(take).ToList();
        }


        /// <summary>
        /// بدست آوردن لیست خبرهای موجود در اسلایدر
        /// </summary>
        /// <returns>لیست خبرهای</returns>
        public IEnumerable<Page> GetPagesInSlider()
        {
            return _dbSet.Where(p => p.ShowInSlider).ToList();
        }


        /// <summary>
        /// بدست آوردن لیست آخرین اخبار
        /// </summary>
        /// <returns>لیست خبر</returns>
        public IEnumerable<Page> GetLatesPages(int take = 5)
        {
            return _dbSet.OrderByDescending(p => p.CreateDate).Take(take).ToList();
        }


        /// <summary>
        /// بدست آوردن لیست خبرهای مربوط به گروه خبری
        /// </summary>
        /// <param name="groupId">شناسه گروه خبری</param>
        /// <returns>لیست خبر</returns>
        public IEnumerable<Page> GetPagesByGroupId(int groupId)
        {
            return _dbSet.Where(p => p.PageGroupID == groupId).ToList();
        }


        /// <summary>
        /// جستجوی خبر
        /// </summary>
        /// <param name="param">پارامتر جستجو</param>
        /// <returns>لیست خبر</returns>
        public IEnumerable<Page> SearchPage(string param)
        {
            var pagelsit = _dbSet.Where(p => p.PageTitle.Contains(param) ||
                                         p.ShortDescription.Contains(param) ||
                                         p.PageText.Contains(param) ||
                                         p.PageTags.Contains(param)

                    ).ToList();
            return pagelsit.Distinct().ToList();
        }


        /// <summary>
        /// لیست خبر به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست خبر</returns>
        public PagedResult<Page> GetAllPages_Paging(int page = 1, int pageSize = 10)
        {
            return _context.Pages.GetPaged(page, pageSize);
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
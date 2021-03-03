using CmsProject.DomainClass.BankReport;
using CmsProject.Utilities.Paging;
using CmsProject.ViewModel.BankReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CmsProject.Service.Repositories
{
    /// <summary>
    /// توابع گزارش بانک
    /// </summary>
    public interface IBankReportRepository : IDisposable
    {
        /// <summary>
        /// بدست آوردن گزارش بانک براساس شناسه
        /// </summary>
        /// <param name="id">شناسه گزارش بانک</param>
        /// <returns>رکورد گزارش بانک</returns>
        BankReportViewModel GetBankReportById(int id);


        /// <summary>
        /// بدست آوردن گزارش بانک براساس شناسه به صورت غیرهمزمان
        /// </summary>
        /// <param name="id">شناسه گزارش بانک</param>
        /// <returns>رکورد گزارش بانک</returns>
        Task<BankReportViewModel> GetBankReportByIdAsync(int id);


        /// <summary>
        /// بدست آوردن گزارش بانک براساس شرط
        /// </summary>
        /// <param name="where">شرط گزارش بانک</param>
        /// <returns>رکورد گزارش بانک</returns>
        BankReportViewModel FirstOrDefaultBankReport(Expression<Func<BankReportViewModel, bool>> where);


        /// <summary>
        /// ثبت رکورد جدید گزارش بانک
        /// </summary>
        /// <param name="entity">رکورد گزارش بانک</param>
        void InsertBankReport(BankReportViewModel entity);


        /// <summary>
        /// ویرایش رکورد گزارش بانک
        /// </summary>
        /// <param name="entity">رکورد گزارش بانک</param>
        void UpdateBankReport(BankReportViewModel entity);


        /// <summary>
        /// حذف رکورد گزارش بانک
        /// </summary>
        /// <param name="entity">رکورد گزارش بانک</param>
        void DeleteBankReport(BankReportViewModel entity);


        /// <summary>
        /// حذف گزارش بانک براساس شناسه
        /// </summary>
        /// <param name="id">شناسه گزارش بانک</param>
        void DeleteBankReportById(int id);


        /// <summary>
        /// بدست آوردن کلیه گزارش بانک ها
        /// </summary>
        /// <returns>لیست گزارش بانک ها</returns>
        IEnumerable<BankReportViewModel> GetAllBankReport();


        /// <summary>
        /// بدست آوردن لیستی از گزارش بانک ها بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد گزارش بانک</returns>
        IEnumerable<BankReportViewModel> GetWhereBankReport(Expression<Func<BankReportViewModel, bool>> where);


        /// <summary>
        /// بدست آوردن تعداد گزارش بانک
        /// </summary>
        /// <returns>تعداد گزارش بانک</returns>
        int CountAllBankReport();


        /// <summary>
        /// بدست آوردن تعداد گزارش بانک براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد گزارش بانک</returns>
        int CountWhereBankReport(Expression<Func<BankReportViewModel, bool>> where);


        /// <summary>
        /// بررسی وجود رکورد گزارش بانک براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        bool IsExistBankReport(Expression<Func<BankReportViewModel, bool>> Where);


        /// <summary>
        /// جستجوی گزارش بانک
        /// </summary>
        /// <param name="param">پارامتر جستجو</param>
        /// <returns>لیست گزارش بانک</returns>
        IEnumerable<BankReportViewModel> SearchBankReport(string param);


        /// <summary>
        /// لیست گزارش بانک به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست گزارش بانک</returns>
        PagedResult<BankReport> GetAllBankReports_Paging(int page = 1, int pageSize = 10);

        /// <summary>
        /// لیست گزارش بانک به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست گزارش بانک</returns>
        PagedResult<BankReportViewModel> GetAllBankReportsVN_Paging(int page = 1, int pageSize = 10);

        IQueryable<BankReportViewModel> SelectBank();

        Task<List<BankReportViewModel>> SelectAllAsyncStudent(string nationCode);


        /// <summary>
        /// خالی کردن عملیات از حافظه
        /// </summary>
        void Save();
    }
}
using CmsProject.DataLayer.Context;
using CmsProject.DomainClass.BankReport;
using CmsProject.DomainClass.Person;
using CmsProject.DomainClass.Student;
using CmsProject.DomainClass.TrainingCenter;
using CmsProject.Service.Repositories;
using CmsProject.Utilities.Paging;
using CmsProject.ViewModel.BankReport;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace CmsProject.Service.Services
{
    /// <summary>
    /// توابع گزارش بانک
    /// </summary>
    public class BankReportRepository : IBankReportRepository
    {
        private UniversityWorker_Context _context;
        private DbSet<BankReportViewModel> _dbSet;
        private DbSet<Person> _dbSetPerson;
        private DbSet<Student> _dbSetStudent;
        private DbSet<TrainingCenter> _dbSetTrainingCenter;

        public BankReportRepository(UniversityWorker_Context context)
        {
            _context = context;
            _dbSet = context.Set<BankReportViewModel>();
            _dbSetPerson = context.Set<Person>();
            _dbSetStudent = context.Set<Student>();
            _dbSetTrainingCenter = context.Set<TrainingCenter>();
        }


        /// <summary>
        /// بدست آوردن گزارش بانک براساس شناسه
        /// </summary>
        /// <param name="id">شناسه گزارش بانک</param>
        /// <returns>رکورد گزارش بانک</returns>
        public BankReportViewModel GetBankReportById(int id) => _dbSet.Find(id);


        /// <summary>
        /// بدست آوردن گزارش بانک براساس شناسه به صورت غیرهمزمان
        /// </summary>
        /// <param name="id">شناسه گزارش بانک</param>
        /// <returns>رکورد گزارش بانک</returns>
        public async Task<BankReportViewModel> GetBankReportByIdAsync(int id) => await _dbSet.FindAsync(id);


        /// <summary>
        /// بدست آوردن گزارش بانک براساس شرط
        /// </summary>
        /// <param name="where">شرط گزارش بانک</param>
        /// <returns>رکورد گزارش بانک</returns>
        public BankReportViewModel FirstOrDefaultBankReport(Expression<Func<BankReportViewModel, bool>> where) => _dbSet.FirstOrDefault(where);


        /// <summary>
        /// ثبت رکورد جدید گزارش بانک
        /// </summary>
        /// <param name="entity">رکورد گزارش بانک</param>
        public void InsertBankReport(BankReportViewModel entity) => _dbSet.Add(entity);


        /// <summary>
        /// ویرایش رکورد گزارش بانک
        /// </summary>
        /// <param name="entity">رکورد گزارش بانک</param>
        public void UpdateBankReport(BankReportViewModel entity) => _context.Entry(entity).State = EntityState.Modified;


        /// <summary>
        /// حذف رکورد گزارش بانک
        /// </summary>
        /// <param name="entity">رکورد گزارش بانک</param>
        public void DeleteBankReport(BankReportViewModel entity) => _context.Entry(entity).State = EntityState.Deleted;


        /// <summary>
        /// حذف گزارش بانک براساس شناسه
        /// </summary>
        /// <param name="id">شناسه گزارش بانک</param>
        public void DeleteBankReportById(int id) => DeleteBankReport(GetBankReportById(id));


        /// <summary>
        /// بدست آوردن کلیه اطلاعات گزارش بانک
        /// </summary>
        /// <returns>لیست دزس</returns>
        public IEnumerable<BankReportViewModel> GetAllBankReport() => _dbSet.ToList();


        /// <summary>
        /// بدست آوردن لیستی از گزارش بانکها بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد گزارش بانک</returns>
        public IEnumerable<BankReportViewModel> GetWhereBankReport(Expression<Func<BankReportViewModel, bool>> where)
        {
            IQueryable<BankReportViewModel> queryable = _dbSet;
            if (where != null)
            {
                queryable.Where(where);
            }
            return queryable;
        }


        /// <summary>
        /// بدست آوردن تعداد گزارش بانک
        /// </summary>
        /// <returns>تعداد گزارش بانک</returns>
        public int CountAllBankReport() => _dbSet.Count();


        /// <summary>
        /// بدست آوردن تعداد گزارش بانک براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد گزارش بانک</returns>
        public int CountWhereBankReport(Expression<Func<BankReportViewModel, bool>> where) => _dbSet.Count(where);


        /// <summary>
        /// بررسی وجود رکورد گزارش بانک براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        public bool IsExistBankReport(Expression<Func<BankReportViewModel, bool>> Where) => _dbSet.Any(Where);


        /// <summary>
        /// جستجوی گزارش بانک
        /// </summary>
        /// <param name="param">پارامتر جستجو</param>
        /// <returns>لیست گزارش بانک</returns>
        public IEnumerable<BankReportViewModel> SearchBankReport(string param)
        {
            var lsit = _dbSet.Where(p => p.CreditorName.Contains(param)
                    ).ToList();
            return lsit.Distinct().ToList();
        }


        /// <summary>
        /// لیست گزارش بانک به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست گزارش بانک</returns>
        public PagedResult<BankReport> GetAllBankReports_Paging(int page = 1, int pageSize = 10)
        {
            return _context.BankReports.GetPaged(page, pageSize);
        }

        /// <summary>
        /// لیست گزارش بانک به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست گزارش بانک</returns>
        public PagedResult<BankReportViewModel> GetAllBankReportsVN_Paging(int page = 1, int pageSize = 10)
        {
            var items = from _bankReport in _dbSet
                        join _student in _dbSetStudent on _bankReport.PaymentNo equals _student.PaymentNo into objStudent
                        from studenttmp in objStudent.DefaultIfEmpty()
                        join prt in _dbSetPerson on studenttmp.NationCode equals prt.NationCode into objPerson
                        from persontmp in objPerson.DefaultIfEmpty()
                        join trt in _dbSetTrainingCenter on studenttmp.TrainingCenterId equals trt.ID into objTraining
                        from trainingtmp in objTraining.DefaultIfEmpty()
                        select new BankReportViewModel()
                        {
                            ID = _bankReport.ID,
                            Branch = _bankReport.Branch,
                            BranchCode = _bankReport.BranchCode,
                            CreditorName = _bankReport.CreditorName,
                            DateOf = _bankReport.DateOf,
                            PaymentNo = _bankReport.PaymentNo,
                            DebtorORCreditor = _bankReport.DebtorORCreditor,
                            Discription = _bankReport.Discription,
                            Evidenc = _bankReport.Evidenc,
                            StudentFullName = _bankReport.StudentFullName,
                            TimeOf = _bankReport.TimeOf,
                            TrainingCode = studenttmp.TrainingCenterCode,
                            TrainingName = trainingtmp.Name,
                            StudentNationCode = studenttmp.NationCode
                        };
            return items.GetPaged(page, pageSize);
        }

        public IQueryable<BankReportViewModel> SelectBank()
        {
            var items = from _bankReport in _dbSet
                        join _student in _dbSetStudent on _bankReport.PaymentNo equals _student.PaymentNo into objStudent
                        from studenttmp in objStudent.DefaultIfEmpty()
                        join prt in _dbSetPerson on studenttmp.NationCode equals prt.NationCode into objPerson
                        from persontmp in objPerson.DefaultIfEmpty()
                        join trt in _dbSetTrainingCenter on studenttmp.TrainingCenterId equals trt.ID into objTraining
                        from trainingtmp in objTraining.DefaultIfEmpty()
                        select new BankReportViewModel()
                        {
                            ID = _bankReport.ID,
                            Branch = _bankReport.Branch,
                            BranchCode = _bankReport.BranchCode,
                            CreditorName = _bankReport.CreditorName,
                            DateOf = _bankReport.DateOf,
                            PaymentNo = _bankReport.PaymentNo,
                            DebtorORCreditor = _bankReport.DebtorORCreditor,
                            Discription = _bankReport.Discription,
                            Evidenc = _bankReport.Evidenc,
                            StudentFullName = _bankReport.StudentFullName,
                            TimeOf = _bankReport.TimeOf,
                            TrainingCode = studenttmp.TrainingCenterCode,
                            TrainingName = trainingtmp.Name,
                            StudentNationCode = studenttmp.NationCode
                        };
            return items;
        }

        public async Task<List<BankReportViewModel>> SelectAllAsyncStudent(string nationCode)
        {
            return await SelectBank().Where(fn => fn.StudentNationCode == nationCode).ToListAsync();
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
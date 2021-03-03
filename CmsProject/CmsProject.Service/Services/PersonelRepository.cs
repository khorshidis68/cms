using CmsProject.DataLayer.Context;
using CmsProject.DomainClass.Person;
using CmsProject.DomainClass.Personel;
using CmsProject.DomainClass.TrainingCenter;
using CmsProject.Service.Repositories;
using CmsProject.Utilities.Paging;
using CmsProject.ViewModel.Personel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CmsProject.Service.Services
{
    /// <summary>
    /// موجودیت پرسنل
    /// </summary>
    public class PersonelRepository : IPersonelRepository
    {

        private UniversityWorker_Context _context;
        private DbSet<Personel> _dbSet;
        private DbSet<TrainingCenter> _dbSetTrainingCenter;
        private DbSet<Person> _dbSetPerson;

        public PersonelRepository(UniversityWorker_Context context)
        {
            _context = context;
            _dbSet = context.Set<Personel>();
            _dbSetTrainingCenter = context.Set<TrainingCenter>();
            _dbSetPerson = context.Set<Person>();
        }


        /// <summary>
        /// بدست آوردن پرسنل براساس شناسه
        /// </summary>
        /// <param name="id">شناسه پرسنل</param>
        /// <returns>رکورد پرسنل</returns>
        public Personel GetPersonelById(int id) => _dbSet.Find(id);


        /// <summary>
        /// بدست آوردن پرسنل براساس شناسه به صورت غیرهمزمان
        /// </summary>
        /// <param name="id">شناسه پرسنل</param>
        /// <returns>رکورد پرسنل</returns>
        public async Task<Personel> GetPersonelByIdAsync(int id) => await _dbSet.FindAsync(id);


        /// <summary>
        /// بدست آوردن پرسنل براساس شرط
        /// </summary>
        /// <param name="where">شرط پرسنل</param>
        /// <returns>رکورد پرسنل</returns>
        public Personel FirstOrDefaultPersonel(Expression<Func<Personel, bool>> where) => _dbSet.FirstOrDefault(where);


        /// <summary>
        /// ثبت رکورد جدید پرسنل
        /// </summary>
        /// <param name="entity">رکورد پرسنل</param>
        public void InsertPersonel(Personel entity) => _dbSet.Add(entity);


        /// <summary>
        /// ویرایش رکورد پرسنل
        /// </summary>
        /// <param name="entity">رکورد پرسنل</param>
        public void UpdatePersonel(Personel entity) => _context.Entry(entity).State = EntityState.Modified;


        /// <summary>
        /// حذف رکورد پرسنل
        /// </summary>
        /// <param name="entity">رکورد پرسنل</param>
        public void DeletePersonel(Personel entity) => _context.Entry(entity).State = EntityState.Deleted;


        /// <summary>
        /// حذف پرسنل براساس شناسه
        /// </summary>
        /// <param name="id">شناسه پرسنل</param>
        public void DeletePersonelById(int id) => DeletePersonel(GetPersonelById(id));


        /// <summary>
        /// بدست آوردن کلیه اطلاعات پرسنل
        /// </summary>
        /// <returns>لیست دزس</returns>
        public IEnumerable<Personel> GetAllPersonel() => _dbSet.ToList();


        /// <summary>
        /// بدست آوردن لیستی از پرسنلها بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد پرسنل</returns>
        public IEnumerable<Personel> GetWherePersonel(Expression<Func<Personel, bool>> where)
        {
            IQueryable<Personel> queryable = _dbSet;
            if (where != null)
            {
                queryable.Where(where);
            }
            return queryable;
        }


        /// <summary>
        /// بدست آوردن تعداد پرسنل
        /// </summary>
        /// <returns>تعداد پرسنل</returns>
        public int CountAllPersonel() => _dbSet.Count();


        /// <summary>
        /// بدست آوردن تعداد پرسنل براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد پرسنل</returns>
        public int CountWherePersonel(Expression<Func<Personel, bool>> where) => _dbSet.Count(where);


        /// <summary>
        /// بررسی وجود رکورد پرسنل براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        public bool IsExistPersonel(Expression<Func<Personel, bool>> Where) => _dbSet.Any(Where);


        /// <summary>
        /// جستجوی پرسنل
        /// </summary>
        /// <param name="param">پارامتر جستجو</param>
        /// <returns>لیست پرسنل</returns>
        public IEnumerable<Personel> SearchPersonel(string param)
        {
            var lsit = _dbSet.Where(p => p.NationCode.Contains(param)
                    ).ToList();
            return lsit.Distinct().ToList();
        }


        /// <summary>
        /// لیست پرسنل به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست پرسنل</returns>
        public PagedResult<Personel> GetAllPersonels_Paging(int page = 1, int pageSize = 10)
        {
            return _context.Personels.GetPaged(page, pageSize);
        }

        /// <summary>
        /// لیست پرسنل به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست پرسنل</returns>
        public PagedResult<PersonelViewModel> GetAllPersonelVM_Paging(int page = 1, int pageSize = 10)
        {
            var mainResult = (from personel in _context.Personels
                              join trainingCenter in _dbSetTrainingCenter on personel.TrainingCenterId equals trainingCenter.ID
                              join person in _dbSetPerson on personel.PersonId equals person.ID
                              select new PersonelViewModel
                              {
                                  NationCode = personel.NationCode,
                                  PersonCode = personel.PersonCode,
                                  PersonId = personel.PersonId,
                                  TrainingCenterId = personel.TrainingCenterId,
                                  TrainingCenterStr = trainingCenter.Name,
                                  PersonFullName = person.FullName
                              }).OrderByDescending(x => x.ID);
            return mainResult.GetPaged(page, pageSize);
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
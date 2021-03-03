using CmsProject.DataLayer.Context;
using CmsProject.DomainClass.Person;
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
    /// توابع شخص
    /// </summary>
    public class PersonRepository : IPersonRepository
    {

        private UniversityWorker_Context _context;
        private DbSet<Person> _dbSet;

        public PersonRepository(UniversityWorker_Context context)
        {
            _context = context;
            _dbSet = context.Set<Person>();
        }


        /// <summary>
        /// بدست آوردن شخص براساس شناسه
        /// </summary>
        /// <param name="id">شناسه شخص</param>
        /// <returns>رکورد شخص</returns>
        public Person GetPersonById(int id) => _dbSet.Find(id);


        /// <summary>
        /// بدست آوردن شخص براساس شناسه به صورت غیرهمزمان
        /// </summary>
        /// <param name="id">شناسه شخص</param>
        /// <returns>رکورد شخص</returns>
        public async Task<Person> GetPersonByIdAsync(int id) => await _dbSet.FindAsync(id);


        /// <summary>
        /// بدست آوردن شخص براساس شرط
        /// </summary>
        /// <param name="where">شرط شخص</param>
        /// <returns>رکورد شخص</returns>
        public Person FirstOrDefaultPerson(Expression<Func<Person, bool>> where) => _dbSet.FirstOrDefault(where);


        /// <summary>
        /// ثبت رکورد جدید شخص
        /// </summary>
        /// <param name="entity">رکورد شخص</param>
        public void InsertPerson(Person entity) => _dbSet.Add(entity);


        /// <summary>
        /// ویرایش رکورد شخص
        /// </summary>
        /// <param name="entity">رکورد شخص</param>
        public void UpdatePerson(Person entity) => _context.Entry(entity).State = EntityState.Modified;


        /// <summary>
        /// حذف رکورد شخص
        /// </summary>
        /// <param name="entity">رکورد شخص</param>
        public void DeletePerson(Person entity) => _context.Entry(entity).State = EntityState.Deleted;


        /// <summary>
        /// حذف شخص براساس شناسه
        /// </summary>
        /// <param name="id">شناسه شخص</param>
        public void DeletePersonById(int id) => DeletePerson(GetPersonById(id));


        /// <summary>
        /// بدست آوردن کلیه اطلاعات شخص
        /// </summary>
        /// <returns>لیست دزس</returns>
        public IEnumerable<Person> GetAllPerson() => _dbSet.ToList();


        /// <summary>
        /// بدست آوردن لیستی از شخصها بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد شخص</returns>
        public IEnumerable<Person> GetWherePerson(Expression<Func<Person, bool>> where)
        {
            IQueryable<Person> queryable = _dbSet;
            if (where != null)
            {
                queryable.Where(where);
            }
            return queryable;
        }


        /// <summary>
        /// بدست آوردن تعداد شخص
        /// </summary>
        /// <returns>تعداد شخص</returns>
        public int CountAllPerson() => _dbSet.Count();


        /// <summary>
        /// بدست آوردن تعداد شخص براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد شخص</returns>
        public int CountWherePerson(Expression<Func<Person, bool>> where) => _dbSet.Count(where);


        /// <summary>
        /// بررسی وجود رکورد شخص براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        public bool IsExistPerson(Expression<Func<Person, bool>> Where) => _dbSet.Any(Where);


        /// <summary>
        /// جستجوی شخص
        /// </summary>
        /// <param name="param">پارامتر جستجو</param>
        /// <returns>لیست شخص</returns>
        public IEnumerable<Person> SearchPerson(string param)
        {
            var lsit = _dbSet.Where(p => p.Name.Contains(param)
                    ).ToList();
            return lsit.Distinct().ToList();
        }


        /// <summary>
        /// لیست شخص به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست شخص</returns>
        public PagedResult<Person> GetAllPersons_Paging(int page = 1, int pageSize = 10)
        {
            return _context.Persons.GetPaged(page, pageSize);
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
using CmsProject.DomainClass.Person;
using CmsProject.Utilities.Paging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CmsProject.Service.Repositories
{
    /// <summary>
    /// توابع شخص
    /// </summary>
    public interface IPersonRepository : IDisposable
    {
        /// <summary>
        /// بدست آوردن شخص براساس شناسه
        /// </summary>
        /// <param name="id">شناسه شخص</param>
        /// <returns>رکورد شخص</returns>
        Person GetPersonById(int id);


        /// <summary>
        /// بدست آوردن شخص براساس شناسه به صورت غیرهمزمان
        /// </summary>
        /// <param name="id">شناسه شخص</param>
        /// <returns>رکورد شخص</returns>
        Task<Person> GetPersonByIdAsync(int id);


        /// <summary>
        /// بدست آوردن شخص براساس شرط
        /// </summary>
        /// <param name="where">شرط شخص</param>
        /// <returns>رکورد شخص</returns>
        Person FirstOrDefaultPerson(Expression<Func<Person, bool>> where);


        /// <summary>
        /// ثبت رکورد جدید شخص
        /// </summary>
        /// <param name="entity">رکورد شخص</param>
        void InsertPerson(Person entity);


        /// <summary>
        /// ویرایش رکورد شخص
        /// </summary>
        /// <param name="entity">رکورد شخص</param>
        void UpdatePerson(Person entity);


        /// <summary>
        /// حذف رکورد شخص
        /// </summary>
        /// <param name="entity">رکورد شخص</param>
        void DeletePerson(Person entity);


        /// <summary>
        /// حذف شخص براساس شناسه
        /// </summary>
        /// <param name="id">شناسه شخص</param>
        void DeletePersonById(int id);


        /// <summary>
        /// بدست آوردن کلیه شخص ها
        /// </summary>
        /// <returns>لیست شخص ها</returns>
        IEnumerable<Person> GetAllPerson();


        /// <summary>
        /// بدست آوردن لیستی از شخص ها بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد شخص</returns>
        IEnumerable<Person> GetWherePerson(Expression<Func<Person, bool>> where);


        /// <summary>
        /// بدست آوردن تعداد شخص
        /// </summary>
        /// <returns>تعداد شخص</returns>
        int CountAllPerson();


        /// <summary>
        /// بدست آوردن تعداد شخص براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد شخص</returns>
        int CountWherePerson(Expression<Func<Person, bool>> where);


        /// <summary>
        /// بررسی وجود رکورد شخص براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        bool IsExistPerson(Expression<Func<Person, bool>> Where);


        /// <summary>
        /// جستجوی شخص
        /// </summary>
        /// <param name="param">پارامتر جستجو</param>
        /// <returns>لیست شخص</returns>
        IEnumerable<Person> SearchPerson(string param);


        /// <summary>
        /// لیست شخص به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست شخص</returns>
        PagedResult<Person> GetAllPersons_Paging(int page = 1, int pageSize = 10);


        /// <summary>
        /// خالی کردن عملیات از حافظه
        /// </summary>
        void Save();
    }
}
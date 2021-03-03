using CmsProject.DomainClass.Study;
using CmsProject.Utilities.Paging;
using CmsProject.ViewModel.Study;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CmsProject.Service.Repositories
{
    /// <summary>
    /// توابع دروس مطالعه
    /// </summary>
    public interface IStudyRepository : IDisposable
    {
        /// <summary>
        /// بدست آوردن دروس مطالعه براساس شناسه
        /// </summary>
        /// <param name="id">شناسه دروس مطالعه</param>
        /// <returns>رکورد دروس مطالعه</returns>
        Study GetStudyById(int id);
        StudyViewModel GetStudyVMById(int id);


        /// <summary>
        /// بدست آوردن دروس مطالعه براساس شناسه به صورت غیرهمزمان
        /// </summary>
        /// <param name="id">شناسه دروس مطالعه</param>
        /// <returns>رکورد دروس مطالعه</returns>
        Task<Study> GetStudyByIdAsync(int id);


        /// <summary>
        /// بدست آوردن دروس مطالعه براساس شرط
        /// </summary>
        /// <param name="where">شرط دروس مطالعه</param>
        /// <returns>رکورد دروس مطالعه</returns>
        Study FirstOrDefaultStudy(Expression<Func<Study, bool>> where);


        /// <summary>
        /// ثبت رکورد جدید دروس مطالعه
        /// </summary>
        /// <param name="entity">رکورد دروس مطالعه</param>
        void InsertStudy(Study entity);


        /// <summary>
        /// ویرایش رکورد دروس مطالعه
        /// </summary>
        /// <param name="entity">رکورد دروس مطالعه</param>
        void UpdateStudy(Study entity);


        /// <summary>
        /// حذف رکورد دروس مطالعه
        /// </summary>
        /// <param name="entity">رکورد دروس مطالعه</param>
        void DeleteStudy(Study entity);


        /// <summary>
        /// حذف دروس مطالعه براساس شناسه
        /// </summary>
        /// <param name="id">شناسه دروس مطالعه</param>
        void DeleteStudyById(int id);


        /// <summary>
        /// بدست آوردن کلیه دروس مطالعه ها
        /// </summary>
        /// <returns>لیست دروس مطالعه ها</returns>
        IEnumerable<Study> GetAllStudy();


        /// <summary>
        /// بدست آوردن لیستی از دروس مطالعه ها بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد دروس مطالعه</returns>
        IEnumerable<Study> GetWhereStudy(Expression<Func<Study, bool>> where);


        /// <summary>
        /// بدست آوردن تعداد دروس مطالعه
        /// </summary>
        /// <returns>تعداد دروس مطالعه</returns>
        int CountAllStudy();


        /// <summary>
        /// بدست آوردن تعداد دروس مطالعه براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد دروس مطالعه</returns>
        int CountWhereStudy(Expression<Func<Study, bool>> where);


        /// <summary>
        /// بررسی وجود رکورد دروس مطالعه براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        bool IsExistStudy(Expression<Func<Study, bool>> Where);


        /// <summary>
        /// جستجوی دروس مطالعه
        /// </summary>
        /// <param name="param">پارامتر جستجو</param>
        /// <returns>لیست دروس مطالعه</returns>
        IEnumerable<Study> SearchStudy(string param);


        /// <summary>
        /// لیست دروس مطالعه به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست دروس مطالعه</returns>
        PagedResult<Study> GetAllStudys_Paging(int page = 1, int pageSize = 10);

        /// <summary>
        /// لیست دروس مطالعه به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست دروس مطالعه</returns>
        PagedResult<StudyViewModel> GetAllStudysVM_Paging(int page = 1, int pageSize = 10);


        /// <summary>
        /// خالی کردن عملیات از حافظه
        /// </summary>
        void Save();
    }
}
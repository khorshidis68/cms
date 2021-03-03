using CmsProject.DataLayer.Context;
using CmsProject.DomainClass.Grade;
using CmsProject.DomainClass.Study;
using CmsProject.Service.Repositories;
using CmsProject.Utilities.Paging;
using CmsProject.ViewModel.Study;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CmsProject.Service.Services
{
    /// <summary>
    /// توابع دروس مطالعه
    /// </summary>
    public class StudyRepository : IStudyRepository
    {
        private UniversityWorker_Context _context;
        private DbSet<Study> _dbSet;
        private DbSet<Grade> _dbSetGrade;

        public StudyRepository(UniversityWorker_Context context)
        {
            _context = context;
            _dbSet = context.Set<Study>();
            _dbSetGrade = context.Set<Grade>();
        }


        /// <summary>
        /// بدست آوردن دروس مطالعه براساس شناسه
        /// </summary>
        /// <param name="id">شناسه دروس مطالعه</param>
        /// <returns>رکورد دروس مطالعه</returns>
        public Study GetStudyById(int id) => _dbSet.Find(id);
        public StudyViewModel GetStudyVMById(int id)
        {
            return (from study in _dbSet
                    join grade in _dbSetGrade on study.GradeId equals grade.ID
                    where study.ID == id
                    select new StudyViewModel
                    {
                        Code = study.Code,
                        GradeId = study.GradeId,
                        GradeStr = grade.Name,
                        ID = study.ID,
                        LessonType = study.LessonType,
                        LessonTypeCode = study.LessonTypeCode,
                        Name = study.Name,
                        PracticalCount = study.PracticalCount,
                        PracticalHour = study.PracticalHour,
                        TheoreticalCount = study.TheoreticalCount,
                        TheoreticalHour = study.TheoreticalHour
                    }).FirstOrDefault();
        }


        /// <summary>
        /// بدست آوردن دروس مطالعه براساس شناسه به صورت غیرهمزمان
        /// </summary>
        /// <param name="id">شناسه دروس مطالعه</param>
        /// <returns>رکورد دروس مطالعه</returns>
        public async Task<Study> GetStudyByIdAsync(int id) => await _dbSet.FindAsync(id);


        /// <summary>
        /// بدست آوردن دروس مطالعه براساس شرط
        /// </summary>
        /// <param name="where">شرط دروس مطالعه</param>
        /// <returns>رکورد دروس مطالعه</returns>
        public Study FirstOrDefaultStudy(Expression<Func<Study, bool>> where) => _dbSet.FirstOrDefault(where);


        /// <summary>
        /// ثبت رکورد جدید دروس مطالعه
        /// </summary>
        /// <param name="entity">رکورد دروس مطالعه</param>
        public void InsertStudy(Study entity) => _dbSet.Add(entity);


        /// <summary>
        /// ویرایش رکورد دروس مطالعه
        /// </summary>
        /// <param name="entity">رکورد دروس مطالعه</param>
        public void UpdateStudy(Study entity) => _context.Entry(entity).State = EntityState.Modified;


        /// <summary>
        /// حذف رکورد دروس مطالعه
        /// </summary>
        /// <param name="entity">رکورد دروس مطالعه</param>
        public void DeleteStudy(Study entity) => _context.Entry(entity).State = EntityState.Deleted;


        /// <summary>
        /// حذف دروس مطالعه براساس شناسه
        /// </summary>
        /// <param name="id">شناسه دروس مطالعه</param>
        public void DeleteStudyById(int id) => DeleteStudy(GetStudyById(id));


        /// <summary>
        /// بدست آوردن کلیه اطلاعات دروس مطالعه
        /// </summary>
        /// <returns>لیست دزس</returns>
        public IEnumerable<Study> GetAllStudy() => _dbSet.ToList();


        /// <summary>
        /// بدست آوردن لیستی از دروس مطالعه بر اساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>مجموع رکورد دروس مطالعه</returns>
        public IEnumerable<Study> GetWhereStudy(Expression<Func<Study, bool>> where)
        {
            IQueryable<Study> queryable = _dbSet;
            if (where != null)
            {
                queryable.Where(where);
            }
            return queryable;
        }


        /// <summary>
        /// بدست آوردن تعداد دروس مطالعه
        /// </summary>
        /// <returns>تعداد دروس مطالعه</returns>
        public int CountAllStudy() => _dbSet.Count();


        /// <summary>
        /// بدست آوردن تعداد دروس مطالعه براساس شرط
        /// </summary>
        /// <param name="where">شرط فیلتر</param>
        /// <returns>تعداد دروس مطالعه</returns>
        public int CountWhereStudy(Expression<Func<Study, bool>> where) => _dbSet.Count(where);


        /// <summary>
        /// بررسی وجود رکورد دروس مطالعه براساس شرط
        /// </summary>
        /// <param name="Where">شرط فیلتر</param>
        /// <returns>درست/نادرست</returns>
        public bool IsExistStudy(Expression<Func<Study, bool>> Where) => _dbSet.Any(Where);


        /// <summary>
        /// جستجوی دروس مطالعه
        /// </summary>
        /// <param name="param">پارامتر جستجو</param>
        /// <returns>لیست دروس مطالعه</returns>
        public IEnumerable<Study> SearchStudy(string param)
        {
            var lsit = _dbSet.Where(p => p.Name.Contains(param)
                    ).ToList();
            return lsit.Distinct().ToList();
        }


        /// <summary>
        /// لیست دروس مطالعه به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست دروس مطالعه</returns>
        public PagedResult<Study> GetAllStudys_Paging(int page = 1, int pageSize = 10)
        {
            return _context.Studys.GetPaged(page, pageSize);
        }

        /// <summary>
        /// لیست دروس مطالعه به صورت صفحه بندی
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <param name="pageSize">تعداد نمایش</param>
        /// <returns>لیست دروس مطالعه</returns>
        PagedResult<StudyViewModel> IStudyRepository.GetAllStudysVM_Paging(int page, int pageSize)
        {
            var mainResult = (from study in _context.Studys
                              join grade in _dbSetGrade on study.GradeId equals grade.ID
                              select new StudyViewModel
                              {
                                  Code = study.Code,
                                  GradeId = study.GradeId,
                                  GradeStr = grade.Name,
                                  ID = study.ID,
                                  LessonType = study.LessonType,
                                  LessonTypeCode = study.LessonTypeCode,
                                  Name = study.Name,
                                  PracticalCount = study.PracticalCount,
                                  PracticalHour = study.PracticalHour,
                                  TheoreticalCount = study.TheoreticalCount,
                                  TheoreticalHour = study.TheoreticalHour
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
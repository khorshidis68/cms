using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CmsProject.Service.Repositories;
using Microsoft.AspNetCore.Authorization;
using CmsProject.DomainClass.Study;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using CmsProject.ViewModel.Study;

namespace CmsProject.WebCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
    public class StudysController : Controller
    {
        private IStudyRepository _studyRepository;
        private IGradeRepository _gradeRepository;

        public StudysController(IStudyRepository studyRepository, IGradeRepository gradeRepository)
        {
            _studyRepository = studyRepository;
            _gradeRepository = gradeRepository;
        }

        [Route("Study")]
        public IActionResult Index(int page = 1)
        {
            return View(_studyRepository.GetAllStudysVM_Paging(page, 10));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Study = _studyRepository.GetStudyVMById(id.Value);
            if (Study == null)
            {
                return NotFound();
            }

            return View(Study);
        }

        public IActionResult Create()
        {
            var lstGrade = _gradeRepository.GetAllGrade().ToList();
            ViewBag.Gradelist = lstGrade.Select(c => new SelectListItem()
                { Text = c.Name, Value = c.ID.ToString() }).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Code,Name,TheoreticalHour,PracticalHour,TheoreticalCount,PracticalCount,LessonType,LessonTypeCode,GradeId")] StudyViewModel study)
        {
            if (ModelState.IsValid)
            {
                Study newRecore = new Study() { 
                    ID = study.ID,
                    Code = study.Code,
                    GradeId = study.GradeId,
                    LessonType = study.LessonType,
                    LessonTypeCode = study.LessonTypeCode,
                    Name = study.Name,
                    PracticalCount = study.PracticalCount,
                    PracticalHour = study.PracticalHour,
                    TheoreticalCount = study.TheoreticalCount,
                    TheoreticalHour = study.TheoreticalHour
                };
                _studyRepository.InsertStudy(newRecore);
                _studyRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(study);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Study = _studyRepository.GetStudyVMById(id.Value);
            if (Study == null)
            {
                return NotFound();
            }
            var lstGrade = _gradeRepository.GetAllGrade().ToList();
            ViewBag.Gradelist = lstGrade.Select(c => new SelectListItem()
                { Text = c.Name, Value = c.ID.ToString() }).ToList();
            return View(Study);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Code,Name,TheoreticalHour,PracticalHour,TheoreticalCount,PracticalCount,LessonType,LessonTypeCode,GradeId")] Study study)
        {
            if (id != study.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _studyRepository.UpdateStudy(study);
                    _studyRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!studyExists(study.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(study);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var study = _studyRepository.GetStudyVMById(id.Value);
            if (study == null)
            {
                return NotFound();
            }

            return View(study);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _studyRepository.DeleteStudyById(id);
            _studyRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool studyExists(int id)
        {
            return _studyRepository.IsExistStudy(e => e.ID == id);
        }
    }
}
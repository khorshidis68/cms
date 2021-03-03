using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CmsProject.Service.Repositories;
using Microsoft.AspNetCore.Authorization;
using CmsProject.DomainClass.Grade;

namespace CmsProject.WebCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
    public class GradesController : Controller
    {
        private IGradeRepository _gradeRepository;

        public GradesController(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        [Route("Grades")]
        public IActionResult Index(int page = 1)
        {
            return View(_gradeRepository.GetAllGrades_Paging(page, 10));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Grade = _gradeRepository.GetGradeById(id.Value);
            if (Grade == null)
            {
                return NotFound();
            }

            return View(Grade);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,DefualtPay,ParentId")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                _gradeRepository.InsertGrade(grade);
                _gradeRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(grade);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Grade = _gradeRepository.GetGradeById(id.Value);
            if (Grade == null)
            {
                return NotFound();
            }
            return View(Grade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,DefualtPay,ParentId")] Grade grade)
        {
            if (id != grade.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _gradeRepository.UpdateGrade(grade);
                    _gradeRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!gradeExists(grade.ID))
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
            return View(grade);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grade = _gradeRepository.GetGradeById(id.Value);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _gradeRepository.DeleteGradeById(id);
            _gradeRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool gradeExists(int id)
        {
            return _gradeRepository.IsExistGrade(e => e.ID == id);
        }
    }
}
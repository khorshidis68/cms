using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CmsProject.Service.Repositories;
using Microsoft.AspNetCore.Authorization;
using CmsProject.DomainClass.Major;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace CmsProject.WebCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
    public class MajorsController : Controller
    {
        private IMajorRepository _majorRepository;
        private IGradeRepository _gradeRepository;

        public MajorsController(IMajorRepository majorRepository, IGradeRepository gradeRepository)
        {
            _majorRepository = majorRepository;
            _gradeRepository = gradeRepository;
        }

        [Route("Majors")]
        public IActionResult Index(int page = 1)
        {
            return View(_majorRepository.GetAllMajors_Paging(page, 10));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Major = _majorRepository.GetMajorById(id.Value);
            if (Major == null)
            {
                return NotFound();
            }

            return View(Major);
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
        public async Task<IActionResult> Create([Bind("ID,Name,GradeId,GradeTitle")] Major major)
        {
            if (ModelState.IsValid)
            {
                major.GradeTitle = _gradeRepository.GetGradeById(major.GradeId.Value).Name;
                _majorRepository.InsertMajor(major);
                _majorRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(major);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Major = _majorRepository.GetMajorById(id.Value);
            if (Major == null)
            {
                return NotFound();
            }
            var lstGrade = _gradeRepository.GetAllGrade().ToList();
            ViewBag.Gradelist = lstGrade.Select(c => new SelectListItem()
                    { Text = c.Name, Value = c.ID.ToString() }).ToList();
            return View(Major);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,GradeId,GradeTitle")] Major major)
        {
            if (id != major.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    major.GradeTitle = _gradeRepository.GetGradeById(major.GradeId.Value).Name;
                    _majorRepository.UpdateMajor(major);
                    _majorRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!majorExists(major.ID))
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
            return View(major);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var major = _majorRepository.GetMajorById(id.Value);
            if (major == null)
            {
                return NotFound();
            }

            return View(major);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _majorRepository.DeleteMajorById(id);
            _majorRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool majorExists(int id)
        {
            return _majorRepository.IsExistMajor(e => e.ID == id);
        }
    }
}
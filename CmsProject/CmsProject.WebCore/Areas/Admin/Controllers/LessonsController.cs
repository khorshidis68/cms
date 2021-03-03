using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CmsProject.Service.Repositories;
using Microsoft.AspNetCore.Authorization;
using CmsProject.DomainClass.Lesson;

namespace CmsProject.WebCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
    public class LessonsController : Controller
    {

        private ILessonRepository _lessonRepository;

        public LessonsController(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        [Route("Lessons")]
        public IActionResult Index(int page = 1)
        {
            return View(_lessonRepository.GetAllLessons_Paging(page, 10));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = _lessonRepository.GetLessonById(id.Value);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Code,LessonType,LessonTypeCode")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _lessonRepository.InsertLesson(lesson);
                _lessonRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(lesson);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = _lessonRepository.GetLessonById(id.Value);
            if (lesson == null)
            {
                return NotFound();
            }
            return View(lesson);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Code,LessonType,LessonTypeCode")] Lesson lesson)
        {
            if (id != lesson.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _lessonRepository.UpdateLesson(lesson);
                    _lessonRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonExists(lesson.ID))
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
            return View(lesson);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = _lessonRepository.GetLessonById(id.Value);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _lessonRepository.DeleteLessonById(id);
            _lessonRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonExists(int id)
        {
            return _lessonRepository.IsExistLesson(e => e.ID == id);
        }
    }
}
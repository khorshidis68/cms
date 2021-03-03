using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CmsProject.Service.Repositories;
using Microsoft.AspNetCore.Authorization;
using CmsProject.DomainClass.TrainingCenter;

namespace CmsProject.WebCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
    public class TrainingCentersController : Controller
    {
        private ITrainingCenterRepository _trainingCenterRepository;

        public TrainingCentersController(ITrainingCenterRepository trainingCenterRepository)
        {
            _trainingCenterRepository = trainingCenterRepository;
        }

        [Route("TrainingCenters")]
        public IActionResult Index(int page = 1)
        {
            return View(_trainingCenterRepository.GetAllTrainingCenters_Paging(page, 10));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TrainingCenter = _trainingCenterRepository.GetTrainingCenterById(id.Value);
            if (TrainingCenter == null)
            {
                return NotFound();
            }

            return View(TrainingCenter);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Code")] TrainingCenter TrainingCenter)
        {
            if (ModelState.IsValid)
            {
                _trainingCenterRepository.InsertTrainingCenter(TrainingCenter);
                _trainingCenterRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(TrainingCenter);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TrainingCenter = _trainingCenterRepository.GetTrainingCenterById(id.Value);
            if (TrainingCenter == null)
            {
                return NotFound();
            }
            return View(TrainingCenter);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Code")] TrainingCenter TrainingCenter)
        {
            if (id != TrainingCenter.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _trainingCenterRepository.UpdateTrainingCenter(TrainingCenter);
                    _trainingCenterRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!trainingCenterExists(TrainingCenter.ID))
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
            return View(TrainingCenter);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TrainingCenter = _trainingCenterRepository.GetTrainingCenterById(id.Value);
            if (TrainingCenter == null)
            {
                return NotFound();
            }

            return View(TrainingCenter);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _trainingCenterRepository.DeleteTrainingCenterById(id);
            _trainingCenterRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool trainingCenterExists(int id)
        {
            return _trainingCenterRepository.IsExistTrainingCenter(e => e.ID == id);
        }
    }
}
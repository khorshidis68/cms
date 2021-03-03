using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CmsProject.Service.Repositories;
using Microsoft.AspNetCore.Authorization;
using CmsProject.DomainClass.EnumEntity;

namespace CmsProject.WebCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
    public class EnumEntitysController : Controller
    {
        private IEnumEntityRepository _enumEntityRepository;

        public EnumEntitysController(IEnumEntityRepository enumEntityRepository)
        {
            _enumEntityRepository = enumEntityRepository;
        }

        [Route("EnumEntitys")]
        public IActionResult Index(int page = 1)
        {
            return View(_enumEntityRepository.GetAllEnumEntitys_Paging(page, 10));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var EnumEntity = _enumEntityRepository.GetEnumEntityById(id.Value);
            if (EnumEntity == null)
            {
                return NotFound();
            }

            return View(EnumEntity);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,GroupEnumEn,Title,Value")] EnumEntity enumEntity)
        {
            if (ModelState.IsValid)
            {
                _enumEntityRepository.InsertEnumEntity(enumEntity);
                _enumEntityRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(enumEntity);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var EnumEntity = _enumEntityRepository.GetEnumEntityById(id.Value);
            if (EnumEntity == null)
            {
                return NotFound();
            }
            return View(EnumEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,GroupEnumEn,Title,Value")] EnumEntity enumEntity)
        {
            if (id != enumEntity.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _enumEntityRepository.UpdateEnumEntity(enumEntity);
                    _enumEntityRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!enumEntityExists(enumEntity.ID))
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
            return View(enumEntity);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enumEntity = _enumEntityRepository.GetEnumEntityById(id.Value);
            if (enumEntity == null)
            {
                return NotFound();
            }

            return View(enumEntity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _enumEntityRepository.DeleteEnumEntityById(id);
            _enumEntityRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool enumEntityExists(int id)
        {
            return _enumEntityRepository.IsExistEnumEntity(e => e.ID == id);
        }
    }
}
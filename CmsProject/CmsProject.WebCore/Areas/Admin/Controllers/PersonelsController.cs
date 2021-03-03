using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CmsProject.Service.Repositories;
using Microsoft.AspNetCore.Authorization;
using CmsProject.DomainClass.Personel;

namespace CmsProject.WebCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
    public class PersonelsController : Controller
    {
        private IPersonelRepository _personelRepository;
        private ITrainingCenterRepository _trainingCenterRepository;
        private IPersonRepository _personRepository;

        public PersonelsController(IPersonelRepository personelRepository, ITrainingCenterRepository trainingCenterRepository, IPersonRepository personRepository)
        {
            _personelRepository = personelRepository;
            _trainingCenterRepository = trainingCenterRepository;
            _personRepository = personRepository;
        }

        [Route("Personels")]
        public IActionResult Index(int page = 1)
        {
            return View(_personelRepository.GetAllPersonelVM_Paging(page, 10));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Personel = _personelRepository.GetPersonelById(id.Value);
            if (Personel == null)
            {
                return NotFound();
            }

            return View(Personel);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personel = _personelRepository.GetPersonelById(id.Value);
            if (personel == null)
            {
                return NotFound();
            }

            return View(personel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _personelRepository.DeletePersonelById(id);
            _personelRepository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
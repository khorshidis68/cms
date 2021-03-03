using CmsProject.DataLayer.Context.Model;
using CmsProject.Service.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CmsProject.WebCore.Controllers
{
    public class HomeController : Controller
    {
        private IPageRepository _pageRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(IPageRepository pageRepository, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _pageRepository = pageRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewData["Slider"] = _pageRepository.GetPagesInSlider();
            return View(_pageRepository.GetLatesPages());
        }
    }
}
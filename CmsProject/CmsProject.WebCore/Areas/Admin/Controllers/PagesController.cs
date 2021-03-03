using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CmsProject.DomainModelClass.Page;
using CmsProject.Service.Repositories;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace CmsProject.WebCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Owner")]
    public class PagesController : Controller
    {

        private IPageGroupRepository _pageGroupRepository;
        private IPageRepository _pageRepository;

        public PagesController(IPageGroupRepository pageGroupRepository, IPageRepository pageRepository)
        {
            _pageGroupRepository = pageGroupRepository;
            _pageRepository = pageRepository;
        }

        public IActionResult Index(int page = 1)
        {
            return View(_pageRepository.GetAllPages_Paging(page));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = _pageRepository.GetPageById(id.Value);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        public IActionResult Create()
        {
            ViewData["PageGroupID"] = new SelectList(_pageGroupRepository.GetAllPageGroup(), "ID", "GroupTitle");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PageGroupID,PageTitle,ShortDescription,PageText,PageVisit,ImageName,PageTags,ShowInSlider,CreateDate")] Page page, IFormFile imgup)
        {
            if (ModelState.IsValid)
            {
                page.PageVisit = 0;
                page.CreateDate = DateTime.Now;

                if (imgup != null)
                {
                    page.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgup.FileName);
                    string savePath = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot\\PageImages\\" + page.ImageName
                        );

                    using (var stream = new FileStream(savePath,FileMode.Create))
                    {
                        await imgup.CopyToAsync(stream);
                    }
                }

                _pageRepository.InsertPage(page);
                _pageRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PageGroupID"] = new SelectList(_pageGroupRepository.GetAllPageGroup(), "ID", "GroupTitle", page.PageGroupID);
            return View(page);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = _pageRepository.GetPageById(id.Value);
            if (page == null)
            {
                return NotFound();
            }
            ViewData["PageGroupID"] = new SelectList(_pageGroupRepository.GetAllPageGroup(), "ID", "GroupTitle", page.PageGroupID);
            return View(page);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PageGroupID,PageTitle,ShortDescription,PageText,PageVisit,ImageName,PageTags,ShowInSlider,CreateDate")] Page page, IFormFile imgup)
        {
            if (id != page.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (imgup != null)
                    {
                        if (page.ImageName == null)
                        {
                            page.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imgup.FileName);
                        }
                        string savePath = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot\\PageImages\\" + page.ImageName
                            );

                        using (var stream = new FileStream(savePath, FileMode.Create))
                        {
                            await imgup.CopyToAsync(stream);
                        }
                    }

                    _pageRepository.UpdatePage(page);
                    _pageRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PageExists(page.ID))
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
            ViewData["PageGroupID"] = new SelectList(_pageGroupRepository.GetAllPageGroup(), "ID", "GroupTitle", page.PageGroupID);
            return View(page);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var page = _pageRepository.GetPageById(id.Value);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _pageRepository.DeletePageById(id);
            _pageRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool PageExists(int id)
        {
            return _pageRepository.IsExistPage(e => e.ID == id);
        }
    }
}
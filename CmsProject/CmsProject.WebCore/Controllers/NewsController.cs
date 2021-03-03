using CmsProject.Service.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CmsProject.WebCore.Controllers
{
    public class NewsController : Controller
    {
        private IPageRepository _pageRepository;
        private IPageGroupRepository _pageGroupRepository;

        public NewsController(IPageRepository pageRepository, IPageGroupRepository pageGroupRepository)
        {
            _pageRepository = pageRepository;
            _pageGroupRepository = pageGroupRepository;
        }

        [Route("News/{newsId}")]
        public IActionResult ShowNews(int newsId)
        {
            var page = _pageRepository.GetPageById(newsId);
            if (page != null)
            {
                page.PageVisit += 1;
                _pageRepository.UpdatePage(page);
                _pageRepository.Save();

                ViewData["GroupTitle"] = _pageGroupRepository.GetPageGroupById(page.PageGroupID).GroupTitle;
            }
            return View(page);
        }

        [Route("Group/{groupId}/{title}")]
        public IActionResult ShowNewsByGroupId(int groupId, string title)
        {
            ViewData["GroupTitle"] = title;
            return View(_pageRepository.GetPagesByGroupId(groupId));
        }

        [Route("AllNews")]
        public IActionResult ShowAllNews()
        {
            return View(_pageRepository.GetLatesPages(999999));
        }

        [Route("Search")]
        public IActionResult Search(string param)
        {
            ViewData["SearchParam"] = param;
            return View(_pageRepository.SearchPage(param));
        }

    }
}
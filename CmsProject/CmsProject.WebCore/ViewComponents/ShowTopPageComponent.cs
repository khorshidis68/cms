using CmsProject.Service.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CmsProject.WebCore.ViewComponents
{
    public class ShowTopPageComponent: ViewComponent
    {
        private IPageRepository _pageRepository;

        public ShowTopPageComponent(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("ShowTopPageComponent",
                _pageRepository.GetTopPage()));
        }
    }
}
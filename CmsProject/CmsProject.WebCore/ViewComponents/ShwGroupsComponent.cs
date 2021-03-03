using CmsProject.Service.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CmsProject.WebCore.ViewComponents
{
    public class ShowGroupsComponent : ViewComponent
    {
        private IPageGroupRepository _pageGroupRepository;

        public ShowGroupsComponent(IPageGroupRepository pageGroupRepository)
        {
            _pageGroupRepository = pageGroupRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(
                (IViewComponentResult) 
                    View("ShowGroupsComponent", _pageGroupRepository.GetListGroups())
                );
        }

    }
}
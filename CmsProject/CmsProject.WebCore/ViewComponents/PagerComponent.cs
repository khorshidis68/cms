using CmsProject.Utilities.Paging;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CmsProject.WebCore.ViewComponents
{
    public class PagerComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("PagerComponent", result));
        }
    }
}
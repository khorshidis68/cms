using CmsProject.Service.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using CmsProject.WebApi.Token.DataTransferObject.PageGroup;
using CmsProject.WebApi.Token.Helpers;

namespace CmsProject.WebApi.Token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageGroupController : ControllerBase
    {
        private IPageGroupRepository pageGroupRepository;
        public PageGroupController(IPageGroupRepository _pageGroupRepository)
        {
            pageGroupRepository = _pageGroupRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetPageGroupByIdAsync(PageGroupRequestDTO req)
        {
            try
            {
                //// sample Call By postman:
                //    { "Id": 2 }
                
                var resultValue = await pageGroupRepository.GetPageCountByGroupIdAsync(req.Id);
                if (resultValue != null)
                {
                    var response = new PageGroupResponseDTO
                    {
                        TitlePageGroup = resultValue.GroupTitle,
                        CountPage = resultValue.PageCount
                    };
                    return Ok(response);
                }
                else
                {
                    return NotFound(new { message = "اطلاعاتی یافت نشد" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(ex.Message));
            }
        }

    }
}
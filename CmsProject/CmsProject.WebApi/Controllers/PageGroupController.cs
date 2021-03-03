using CmsProject.Service.Repositories;
using CmsProject.WebApi.DataTransferObject.PageGroup;
using CmsProject.WebApi.Models.BaseModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CmsProject.WebApi.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetPageGroupByIdAsync(RequestBase<PageGroupRequestDTO> req)
        {
            try
            {
                //// sample Call By postman:
                //{
                //    "UserName": "__P@g3gR0UpUser8001937!@$cmsPROJECT-", 
                //    "Password": "__P@g3gR0UpPassword46229#%@cmsPROJECT-",
                //    "RequestPayload": 
                //    { "Id": 2 }
                //}

                CheckPass(req.UserName, req.Password);

                var resultValue = await pageGroupRepository.GetPageCountByGroupIdAsync(req.RequestPayload.Id);
                var response = new PageGroupResponseDTO
                {
                    TitlePageGroup = resultValue.GroupTitle,
                    CountPage = resultValue.PageCount
                };
                if (resultValue != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(ex.Message));
            }
        }

        protected void CheckPass(string userName, string pass)
        {
            if (!(userName == Constant.Constants.PageGroupUser && pass == Constant.Constants.PageGroupPass))
            {
                throw new ArgumentException(JsonConvert.SerializeObject("نام کاربری یا رمز عبور اشتباه است"));
            }
        }
    }
}
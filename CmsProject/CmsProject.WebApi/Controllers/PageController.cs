using CmsProject.Service.Repositories;
using CmsProject.WebApi.DataTransferObject;
using CmsProject.WebApi.DataTransferObject.Page;
using CmsProject.WebApi.Models.BaseModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CmsProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private IPageGroupRepository pageGroupRepository;
        private IPageRepository pageRepository;

        public PageController(IPageRepository _pageRepository,
            IPageGroupRepository _pageGroupRepository)
        {
            pageRepository = _pageRepository;
            pageGroupRepository = _pageGroupRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPageByIdAsync(RequestBase<PageRequestDTO> req)
        {
            try
            {
                //// sample Call By postman:
                //{
                //    "UserName": "__P@g3User9132004@#!cmsPROJECT-", 
                //    "Password": "__P@g3Password8819730#!@cmsPROJECT-",
                //    "RequestPayload": 
                //    { "Id": 2 }
                //}

                CheckPass(req.UserName, req.Password);

                var resultValue = await pageRepository.GetPageByIdAsync(req.RequestPayload.Id);
                var response = new PageResponseDTO
                {
                    pageText = resultValue.PageText,
                    pageTitle = resultValue.PageTitle,
                    shortDescription = resultValue.ShortDescription
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
                //return JsonConvert.SerializeObject(ex.Message);
            }
        }

        protected void CheckPass(string userName, string pass)
        {
            if (!(userName == Constant.Constants.PageUser && pass == Constant.Constants.PagePass))
            {
                //return BadRequest(JsonConvert.SerializeObject("نام کاربری یا رمز عبور اشتباه است"));
                throw new ArgumentException(JsonConvert.SerializeObject("نام کاربری یا رمز عبور اشتباه است"));
            }
        }

    }
}
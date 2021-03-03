using CmsProject.DataLayer.Context.Model;
using CmsProject.WebApi.Token.Entities;
using CmsProject.WebApi.Token.Helpers;
using CmsProject.WebApi.Token.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CmsProject.WebApi.Token.Services
{
    public interface IUserService
    {
        /// <summary>
        /// اعتبار سنجی کاربر
        /// </summary>
        /// <param name="model">مدلی برای دریافت نام کاربری و رمز عبور</param>
        /// <returns>اطلاعات کاربر به همراه توکن</returns>
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);

        /// <summary>
        /// بدست آوردن لیست همه کاربران
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAll();

        /// <summary>
        /// بدست آوردن کاربر براساس شناسه آن
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //User GetById(int id);
        User GetById(string id);
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User { Id = "51", FirstName = "fName1", LastName = "lName1", Username = "userName1", Password = "password1" },
            new User { Id = "52", FirstName = "fName2", LastName = "lName2", Username = "userName2", Password = "password2" },
            new User { Id = "53", FirstName = "fName3", LastName = "lName3", Username = "userName3", Password = "password3" }
        };

        private readonly AppSettings _appSettings;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(IOptions<AppSettings> appSettings,
            UserManager<ApplicationUser> _userManager)
        {
            _appSettings = appSettings.Value;
            userManager = _userManager;
        }

        [HttpPost]
        /// <summary>
        /// اعتبار سنجی کاربر
        /// </summary>
        /// <param name="model">مدلی برای دریافت نام کاربری و رمز عبور</param>
        /// <returns>اطلاعات کاربر به همراه توکن</returns>
        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            try
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    bool currentCheckPassword = await userManager.CheckPasswordAsync(user, model.Password);
                }

                // User_HardCode
                //var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

                // return null if user not found
                if (user == null) return null;

                User _user = new User
                {
                    Id = user.Id.ToString(),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Password = user.PasswordHash,
                    Username = user.UserName
                };

                // authentication successful so generate jwt token
                var token = generateJwtToken(_user);

                return new AuthenticateResponse(_user, token);

                #region User_HardCode

                /*
                //var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

                // return null if user not found
                if (user == null) return null;

                // authentication successful so generate jwt token
                var token = generateJwtToken(user);

                return new AuthenticateResponse(user, token);
                */

                #endregion

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        /// <summary>
        /// بدست آوردن لیست همه کاربران
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAll()
        {
            return userManager.Users.Select(u => new User()
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Username = u.UserName,
                Password = u.PasswordHash
            });

            // User_HardCode
            //return _users;
        }


        /// <summary>
        /// بدست آوردن کاربر براساس شناسه آن
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetById(string id)
        {
            var user = userManager.Users.FirstOrDefault(x => x.Id == id);
            return new User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.UserName,
                Password = user.PasswordHash
            };

            // User_HardCode
            //return _users.FirstOrDefault(x => x.Id == id);
        }


        // helper methods
        /// <summary>
        /// ایجاد توکن کاربر لاگین شده
        /// </summary>
        /// <param name="user">اطلاعات کاربر</param>
        /// <returns>توکن ایجاد شده برای کاربر</returns>
        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id) }),
                Expires = DateTime.UtcNow.AddDays(7), // تعیین اعتبار توکن وب سرویس
                //Expires = DateTime.UtcNow.AddSeconds(15), // مثال 15 ثانیه اعتبار توکن وب سرویس
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
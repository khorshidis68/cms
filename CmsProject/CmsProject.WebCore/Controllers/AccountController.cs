using System.Threading.Tasks;
using CmsProject.WebCore.Repositories.Email;
using CmsProject.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CmsProject.DataLayer.Context.Model;
using System.Linq;

namespace CmsProject.WebCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMessageSender _messageSender;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMessageSender messageSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _messageSender = messageSender;
        }

        #region Register

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDate = model.BirthDate.Replace("/", "")
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //// ارسال ایمیل جهت صحت ایمیل وارد شده
                    //var emailConfirmationToken =
                    //    await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var emailMessage =
                    //    Url.Action("ConfirmEmail", "Account",
                    //        new { username = user.UserName, token = emailConfirmationToken },
                    //        Request.Scheme);
                    //await _messageSender.SendEmailAsync(model.Email, "Email confirmation", emailMessage);

                    //ModelState.AddModelError("", "لینک فعال سازی حساب کاربری به ایمیلتان ارسال شد.\n جهت فعال سازی بر روی لینک کلیک کنید");
                    //ViewData["ErrorMessage"] = "لینک فعال سازی حساب کاربری به ایمیلتان ارسال شد.\n جهت فعال سازی بر روی لینک کلیک کنید";
                    //return RedirectToAction("Login", "Account");
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }

        #endregion

        #region Login / LogOut

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
                //,ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            ViewData["returnUrl"] = returnUrl;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            //if (User.Identity.Name != null)
            //{
            //    var recordUser = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            //    if (recordUser != null)
            //    {
            //        ViewData["FullNameUser"] = recordUser.FirstName + ' ' + recordUser.LastName;
            //    }
            //}

            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }

            model.ReturnUrl = returnUrl;
            //model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ViewData["returnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.UserName, model.Password, model.RememberMe, true);

                if (result.Succeeded)
                {
                    //// بررسی تایید ایمیل
                    //var user = await _userManager.FindByNameAsync(model.UserName);
                    //if (user != null)
                    //{
                    //    if (user.EmailConfirmed == false)
                    //    {
                    //        await _signInManager.SignOutAsync();

                    //        ViewData["ErrorMessage"] = "کاربری شما غیرفعال است. جهت فعال سازی آن بر روی لینک ارسال شده در ایمیل تان کلیک نمایید";
                    //        ModelState.AddModelError("", "کاربری شما غیرفعال است. جهت فعال سازی آن بر روی لینک ارسال شده در ایمیل تان کلیک نمایید.");
                    //        return View(model);
                    //    }
                    //}

                    // بررسی صحت آدرس ارجاع داده شده که خالی نباشد و از فرم های پروژه باشد
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }

                if (result.IsLockedOut)
                {
                    ViewData["ErrorMessage"] = "اکانت شما به دلیل پنج بار ورود ناموفق به مدت پنج دقیقه قفل شده است";
                    return View(model);
                }

                ModelState.AddModelError("", "نام کاربری یا رمزعبور اشتباه است");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            // HttpContext.Response.Cookies.Delete("RVG");
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region remoteValidation

        // مثلا:
        // بررسی وجود ایمیل/نام کاربری تکراری موجود در دیتابیس در هنگام ثبت نام قبل از زدن دکمه ثبت نام
        // و همزمان بعد از وارد کردن ایمیل/نام کاربری

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return Json(true);
            return Json("ایمیل وارد شده از قبل موجود است");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsUserNameInUse(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null) return Json(true);
            return Json("نام کاربری وارد شده از قبل موجود است");
        }

        #endregion

        #region ConfirmEmail

        // جهت تایید ایمیل ارسالی به کاربر برای تایید صحت ایمیل وارد شده در ثبت نام کاربر

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userName, string token)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(token))
                return NotFound();
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null) return NotFound();
            var result = await _userManager.ConfirmEmailAsync(user, token);

            return Content(result.Succeeded ? "Email Confirmed" : "Email Not Confirmed");
        }

        #endregion

        #region Password

        #region AccountPassword

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginVM = new LoginViewModel();
                //var loginViewModel = new LoginVM()
                //{
                //    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
                //};

                ViewData["ErrorMessage"] = "اگر ایمیل وارد معتبر باشد، لینک فراموشی رمزعبور به ایمیل شما ارسال شد";

                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null) return View("Login", loginVM);

                var resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var resetPasswordUrl = Url.Action("ResetPassword", "Account",
                    new { email = user.Email, token = resetPasswordToken }, Request.Scheme);

                await _messageSender.SendEmailAsync(user.Email, "بازیابی رمزعبور سایت خبری خورشید شرق", resetPasswordUrl);

                return View("Login", loginVM);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ResetPassword(string email, string token)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token))
                return RedirectToAction("Index", "Home");

            var model = new ResetPasswordViewModel()
            {
                Email = email,
                Token = token
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var LoginVM = new LoginViewModel();
                //var LoginVM = new LoginVM()
                //{
                //    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
                //};

                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null) return RedirectToAction("Login", LoginVM);
                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
                if (result.Succeeded)
                {
                    ViewData["ErrorMessage"] = "رمزعبور شما با موفقیت تغییر یافت";
                    return View("Login", LoginVM);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        #endregion

        #region ResetPasswordByAdmin

        [Authorize(Roles = "Admin,Owner")]
        [HttpGet]
        public IActionResult ResetPasswordByAdmin()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Owner")]
        [HttpPost]
        [ActionName("ResetPasswordByAdmin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPasswordByUserAdmin(ResetPasswordByAdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("","نام کاربری یافت نشد");
                    return View(model);
                }
                var resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, resetPasswordToken, model.NewPassword);
                if (result.Succeeded)
                {
                    ModelState.AddModelError("", "رمزعبور با موفقیت تغییر یافت");
                    return View(model);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        #endregion

        #region ResetPasswordByCurrentUser

        [Authorize]
        [HttpGet]
        public IActionResult ResetPasswordCurrentUser()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ActionName("ResetPasswordCurrentUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPasswordByCurrentUser(ResetPasswordCurrentUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                if (currentUser != null)
                {
                    bool currentCheckPassword = await _userManager.CheckPasswordAsync(currentUser, model.CurrentPassword);
                    if (currentCheckPassword)
                    {
                        var resultChangePassword = await _userManager.ChangePasswordAsync(currentUser, model.CurrentPassword, model.NewPassword);
                        if (resultChangePassword.Succeeded)
                        {
                            ModelState.AddModelError("", "رمزعبور شما با موفقیت تغییر یافت");
                            return View(model);
                        }
                        foreach (var error in resultChangePassword.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "کاربر نامعتبر است");
                    return View(model);
                }
            }
            ModelState.AddModelError("", "رمز جاری نامعتبر است");
            return View(model);
        }

        #endregion

        #endregion

    }
}
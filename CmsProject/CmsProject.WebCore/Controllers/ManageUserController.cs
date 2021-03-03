using System.Linq;
using System.Threading.Tasks;
using CmsProject.DataLayer.Context.Model;
using CmsProject.ViewModel.ManageUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CmsProject.WebCore.Controllers
{
    [Authorize(Roles = "Owner")]
    public class ManageUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ManageUserController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _userManager.Users
                .Select(u => new IndexViewModel()
                { Id = u.Id, UserName = u.UserName, Email = u.Email, FirstName = u.FirstName, LastName = u.LastName }).ToList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            IndexViewModel reternUser = new IndexViewModel()
            { Id = user.Id, UserName = user.UserName, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, BirthDate = user.BirthDate };
            ViewData["birthDate"] = user.BirthDate.Replace("/","").Replace("/", "");
            return View(reternUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(IndexViewModel _user)
        {
            if (ModelState.IsValid)
            {
                //if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(userName)) return NotFound();
                var user = await _userManager.FindByIdAsync(_user.Id);
                if (user == null) return NotFound();
                user.UserName = _user.UserName;
                user.Email = _user.Email;
                user.FirstName = _user.FirstName;
                user.LastName = _user.LastName;
                user.BirthDate = _user.BirthDate.Replace("/", "");
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded) return RedirectToAction("index");

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(user);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> AddUserToRole(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            var roles = _roleManager.Roles.ToList();
            var model = new AddUserToRoleViewModel() { UserId = id };

            foreach (var role in roles)
            {
                if (!await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.UserRoles.Add(new UserRolesViewModel()
                    {
                        RoleName = role.Name
                    });
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUserToRole(AddUserToRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model == null) return NotFound();
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null) return NotFound();
                var requestRoles = model.UserRoles.Where(r => r.IsSelected)
                    .Select(u => u.RoleName)
                    .ToList();
                var result = await _userManager.AddToRolesAsync(user, requestRoles);

                if (result.Succeeded) return RedirectToAction("index");

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveUserFromRole(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            var roles = _roleManager.Roles.ToList();
            var model = new AddUserToRoleViewModel() { UserId = id };

            foreach (var role in roles)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.UserRoles.Add(new UserRolesViewModel()
                    {
                        RoleName = role.Name
                    });
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveUserFromRole(AddUserToRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model == null) return NotFound();
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null) return NotFound();
                var requestRoles = model.UserRoles.Where(r => r.IsSelected)
                    .Select(u => u.RoleName)
                    .ToList();
                var result = await _userManager.RemoveFromRolesAsync(user, requestRoles);

                if (result.Succeeded) return RedirectToAction("index");

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var model = new IndexViewModel()
            { Id = user.Id, UserName = user.UserName, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, BirthDate = user.BirthDate };
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(id)) return NotFound();
                var user = await _userManager.FindByIdAsync(id);
                if (user == null) return NotFound();
                await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }


        // به روز رسانی اطلاعات کوکی کاربر
        [HttpGet]
        public async Task<IActionResult> UpdateSecurityStamp(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            await _userManager.UpdateSecurityStampAsync(user);
            return RedirectToAction("Index");
        }

    }
}
using System.Linq;
using System.Threading.Tasks;
using CmsProject.ViewModel.ManageRole;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CmsProject.WebCore.Controllers
{
    [Authorize(Roles = "Owner")]
    public class ManageRoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public ManageRoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            //var roles = _roleManager.Roles.ToList();
            var roles = _roleManager.Roles
                .Select(r => new IndexRoleViewModel() { Id = r.Id, RoleName = r.Name }).ToList();
            return View(roles);
        }

        #region Insert

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(IndexRoleViewModel roleInsert)
        {
            if (string.IsNullOrEmpty(roleInsert.RoleName)) return NotFound();
            var role = new IdentityRole(roleInsert.RoleName); // ایجاد نمونه جدید از آبجکت گروه
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded) return RedirectToAction("Index");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(role);
        }

        #endregion

        #region Edit

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            IndexRoleViewModel customRole = new IndexRoleViewModel()
            {
                Id = role.Id,
                RoleName = role.Name
            };
            return View(customRole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditRole(string id, string name)
        public async Task<IActionResult> EditRole(IndexRoleViewModel roleEdit)
        {
            if (string.IsNullOrEmpty(roleEdit.Id) || string.IsNullOrEmpty(roleEdit.RoleName)) return NotFound();

            var role = await _roleManager.FindByIdAsync(roleEdit.Id);
            if (role == null) return NotFound();
            role.Name = roleEdit.RoleName;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded) return RedirectToAction("Index");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(role);
        }
        #endregion

        #region Delete

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            var model = new IndexRoleViewModel() { RoleName = role.Name };
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            await _roleManager.DeleteAsync(role);

            return RedirectToAction("Index");
        }
        #endregion

    }
}
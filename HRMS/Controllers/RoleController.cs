using HRMS.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
  //  [Authorize(Roles = "Human Resource")]
    public class RoleController : Controller
    {
        public RoleManager<IdentityRole> _roleManager { get; }
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Create()
        {

            //_roleManager.Roles;
            //_roleManager.DeleteAsync();
            //_roleManager.UpdateAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole
                {
                    Name = roleViewModel.Name
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("List");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(roleViewModel);
        }

        [HttpGet]
        public IActionResult List()
        {
            return View(_roleManager.Roles.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Update(string roleId)
        {
            var oldTodo = await _roleManager.FindByIdAsync(roleId);
            return View(oldTodo);
        }
        [HttpPost]
        public async Task<IActionResult> Update(RoleViewModel role)
        {
            var oldRole = await _roleManager.FindByIdAsync(role.Id.ToString());
            oldRole.Name = role.Name;
            var result = await _roleManager.UpdateAsync(oldRole);
            if (result.Succeeded)
            {
                return RedirectToAction("List");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View();

        }

        public async Task<IActionResult> Delete(string roleId)
        {
            var oldRole = await _roleManager.FindByIdAsync(roleId);

            var todolist = _roleManager.DeleteAsync(oldRole);
            return RedirectToAction(controllerName: "Role", actionName: "List"); // reload the getall page it self
        }
    }
}

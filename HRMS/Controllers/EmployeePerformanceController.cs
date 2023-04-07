using HRMS.Data;
using HRMS.Models;
using HRMS.Repository;
using HRMS.Repository.SqlRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Controllers
{
    public class EmployeePerformanceController : Controller
    {

        IEmployeePerformanceDBRepository _repo;
        private UserManager<ApplicationUser> _userManager { get; }
        public RoleManager<IdentityRole> _roleManager { get; }
        private SignInManager<ApplicationUser> _signInManager { get; }
        public EmployeePerformanceController(IEmployeePerformanceDBRepository repo, UserManager<ApplicationUser> userManager)
        {
            _repo = repo;
            _userManager = userManager;

        }

        public IActionResult List(string searchValue)
        {
            var list = _repo.ListEmployeePerformance(searchValue);
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var listEmployee = new List<SelectListItem>();
            List<ApplicationUser> departments = _userManager.Users.Include(d => d.Department).Where(status => status.ActiveStatus == true).Include(p => p.Position).ToList();
            listEmployee = departments.Select(emp => new SelectListItem
            {
                Value = emp.FullName,
                Text = emp.FullName
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "Select Position"
            };
            listEmployee.Insert(0, defItem);
            ViewBag.EmpId = listEmployee;
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeePerformance newEmp)
        {
            if (ModelState.IsValid)
            {
                var emp = _repo.AddEmployeePerformance(newEmp);
                return RedirectToAction("List");
            }
            ViewData["Message"] = "Data is not valid to create the EmployeePerformance";
            return View();
        }

        [HttpGet]
        public IActionResult Update(int EmpPerformanceId)
        {
            EmployeePerformance EmployeePerformance = _repo.GetEmployeePerformanceById(EmpPerformanceId); ;
            ViewBag.EmpId = _repo.GetEmployeeList();
            return View(EmployeePerformance);
        }
        [HttpPost]
        public IActionResult Update(int EmpPerformanceId, EmployeePerformance EmployeePerformance)
        {
            _repo.UpdateEmployeePerformance(EmpPerformanceId, EmployeePerformance);
            return RedirectToAction("List");
        }

        public IActionResult Details(int EmpPerformanceId)
        {
            var emp = _repo.GetEmployeePerformanceById(EmpPerformanceId);
            return View(emp);
        }
        public IActionResult Delete(int EmpPerformanceId)
        {
            _repo.DeleteEmployeePerformance(EmpPerformanceId);
            return RedirectToAction("List");
        }
    }
}

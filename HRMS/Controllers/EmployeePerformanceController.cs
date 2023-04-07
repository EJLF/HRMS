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
        //private SignInManager<ApplicationUser> _signInManager { get; }
        public EmployeePerformanceController(IEmployeePerformanceDBRepository repo, UserManager<ApplicationUser> userManager)
        {
            _repo = repo;
            _userManager = userManager;

        }

        public IActionResult List()
        {
            return View(_repo.ListOfEmployeePerformance());
        }
        
        [HttpGet]
        public async Task<IActionResult> CreateAsync(string employeeName, string reviewerName)
        {
            var email = User.Identity.Name;
            var employee = _userManager.Users.FirstOrDefault(e => e.Email == email);
            EmployeePerformance employeePerformance = new EmployeePerformance();
            {
                reviewerName = employee.FirstName + " " + employee.MiddleName + " " + employee.LastName;

                employeePerformance.EmployeeName = employeeName;
                employeePerformance.ReviewBy = reviewerName;
                return View(employeePerformance);
            }
        }
        [HttpPost]
        public IActionResult Create(EmployeePerformance newEmployeePerformance)
        {
            if (ModelState.IsValid)
            {
                var Dept = _repo.AddEmployeePerformance(newEmployeePerformance);
                return RedirectToAction("List");
            }
            ViewData["Message"] = "Data is not valid to create the Department";
            return View();

        }
    }
}

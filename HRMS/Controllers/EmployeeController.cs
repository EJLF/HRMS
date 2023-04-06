using HRMS.Data;
using HRMS.Models;
using HRMS.Repository;
using HRMS.Repository.SqlRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Controllers
{
  //  [Authorize (Roles = "Human Resource,Employee")]
    public class EmployeeController : Controller
    {

        IEmployeeRepository _repo;

        public EmployeeController(IEmployeeRepository repo)
        {
            this._repo = repo;
        }

        public IActionResult List(string searchValue, string searchOption)
        {
            ViewBag.DepartmentId = _repo.GetDepartmentList();
            var filter = _repo.GetFilter(searchOption, searchValue);
            return View(filter);

        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DepartmentId = _repo.GetDepartmentList();
            ViewBag.PositionId = _repo.GetPositionList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee newEmp)
        {
            if (ModelState.IsValid)
            {

                newEmp.ActiveStatus = true;
                var emp = _repo.AddEmployee(newEmp);
                return RedirectToAction("List");
            }
            ViewData["Message"] = "Data is not valid to create the Employee";
            return View();
        }

        [HttpGet]
        public IActionResult Update(int empId) 
        {
            Employee employee = _repo.GetEmployeeById(empId); 
            ViewBag.DepartmentId = _repo.GetDepartmentList();
            ViewBag.PositionId = _repo.GetPositionList();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Update(int empId, Employee employee)
        {

            _repo.UpdateEmployee(empId,employee);
            return RedirectToAction("List");
        }

        public IActionResult Details(int empId)
        {
            
            var emp = _repo.GetEmployeeById(empId);
            return View(emp);
        }
        public IActionResult Delete(int empId)
        {
            //_dbcontext.Employees.Include(d => d.Department).AsNoTracking().ToList().FirstOrDefault(x => x.EmpId == Id);
            _repo.DeleteEmployee(empId);
            return RedirectToAction("List");
        }
    }
}

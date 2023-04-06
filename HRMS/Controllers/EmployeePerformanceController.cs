using HRMS.Data;
using HRMS.Models;
using HRMS.Repository;
using HRMS.Repository.SqlRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Controllers
{
    public class EmployeePerformanceController : Controller
    {

        IEmployeePerformanceDBRepository _repo;
        //MSDBContext _dbcontext;
        public EmployeePerformanceController(IEmployeePerformanceDBRepository repo)
        {
            this._repo = repo;
        }

        public IActionResult List(string searchValue)
        {
            var list = _repo.ListEmployeePerformance(searchValue);
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.EmpId = _repo.GetEmployeeList();
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

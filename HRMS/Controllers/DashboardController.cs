﻿using HRMS.Models;
using HRMS.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    public class DashboardController : Controller
    {
        IDepartmentRepository _department;
        IPositionRepository _position;
        private UserManager<ApplicationUser> _userManager { get; }
        public RoleManager<IdentityRole> _roleManager { get; }
        private SignInManager<ApplicationUser> _signInManager { get; }
        public DashboardController(UserManager<ApplicationUser> userManager,  
                                  RoleManager<IdentityRole> roleManager, 
                                  SignInManager<ApplicationUser> signInManager,
                                  IDepartmentRepository repo,
                                  IPositionRepository position)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _position = position;
            _department = repo;
        }
        public IActionResult Index()
        {
            var employees = _userManager.Users.Where(status => status.ActiveStatus == false).ToList();
            ViewBag.Employees = _userManager.Users.Where(status => status.ActiveStatus == true).Count();
            ViewBag.Departments = _department.ListOfDepartment().Count();
            ViewBag.Positions = _position.ListOfPosition().Count();
            ViewBag.EmployeeInActive = employees;
            return View();
        }
    }
}

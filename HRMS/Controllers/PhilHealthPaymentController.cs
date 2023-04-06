using HRMS.Models;
using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    public class PhilHealthPaymentController : Controller
    {
        IPhilHealthPaymentDBRepository _repo;

        public PhilHealthPaymentController(IPhilHealthPaymentDBRepository repo)
        {
            _repo = repo;
        }

        public IActionResult List()
        {
            var list = _repo.ListOfPhilHealthPayment();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PhilHealthPayment philHealthPayment)
        {
            if(ModelState.IsValid)
            {
                _repo.AddPhilHealthPayment(philHealthPayment);
                return RedirectToAction("List");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int No)
        {
            PhilHealthPayment philHealthPayment = _repo.GetPhilHealthPaymentById(No);
            return View(philHealthPayment);
        }

        [HttpPost]
        public IActionResult Edit(PhilHealthPayment philHealthPayment)
        {
            _repo.UpdatePhilHealthPayment(philHealthPayment);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int No)
        {
            _repo.DeletePhilHealthPayment(No);
            return RedirectToAction("List");
        }
    }
}

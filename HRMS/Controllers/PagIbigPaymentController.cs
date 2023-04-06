using HRMS.Models;
using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    public class PagIbigPaymentController : Controller
    {
        IPagIbigPaymentRepository _repo;
        public PagIbigPaymentController(IPagIbigPaymentRepository repo)
        {
            _repo = repo;
        }

        public IActionResult List()
        {
            var list = _repo.ListOfPagIbigPayment();
            return View(list);
        }
        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PagIbigPayment pagIbigPayment)
        {
            if (ModelState.IsValid)
            {
                _repo.AddPagIbigPayment(pagIbigPayment);
                return RedirectToAction("List");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int No)
        {
            PagIbigPayment pagIbigPayment = _repo.GetPagIbigPaymentById(No);
            return View(pagIbigPayment);
        }
        [HttpPost]

        public IActionResult Edit(PagIbigPayment pagIbigPayment)
        {
            _repo.UpdatePagIbigPayment(pagIbigPayment);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int No)
        {
            _repo.DeletePagIbigPayment(No);
            return RedirectToAction("List");
        }
    }
}

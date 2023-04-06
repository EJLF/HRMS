using HRMS.Data;
using HRMS.Models;
using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace HRMS.Controllers
{

        public class SSSPaymentController : Controller
        {
            ISSSPaymentRepository _repo;
            public SSSPaymentController(ISSSPaymentRepository repo)
            {
                this._repo = repo;
            }

        public IActionResult List()
            {
                var list = _repo.ListOfSSSPayment();
                return View(list);
            }
        [HttpGet]
        public IActionResult Create() 
            {
                return View();
            }
        [HttpPost]
        public IActionResult Create(SSSPayment sssPayment)
            { 
                if (ModelState.IsValid)
                {
                    _repo.AddSSSPayment(sssPayment);
                    return RedirectToAction("List");
                }
                return View();
            }
        [HttpGet]
        public IActionResult Edit(int No)
        {
            SSSPayment ssspayment = _repo.GetSSSPaymentById(No);
            return View(ssspayment);
        }

        [HttpPost]
        public IActionResult Edit(SSSPayment newSSSPayment)
        {
            _repo.UpdateSSSPayment(newSSSPayment);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int No)
        {
            _repo.DeleteSSSPayment(No);
            return RedirectToAction("List");
        }

        }
    }

using ApplicationCore.Models;
using ApplicationCore.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QixinLiu.MVC.HotelManagementSystem.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IActionResult> AllServices()
        {
            var lists = await _serviceService.ListAllServices();

            if (!lists.Any()) return View();

            return View(lists);
        }

        [HttpGet]
        [Route("Service/Details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var service = await _serviceService.GetServiceById(id);

            if (service == null) return View();

            return View(service);
        }


        [HttpGet]
        public async Task<IActionResult> Change(int id)
        {
            ServiceResponseModel model;
            if (id != -1)
            {
                model = await _serviceService.GetServiceById(id);
            }
            else
            {

 
                model = new ServiceResponseModel
                {
                    Id = -1,
                    RoomNO = 1,
                    SDESC = "House Keeping",
                    Amount = 100,
                    ServiceDate = DateTime.Now
                };
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Change(int id, int? roomNo,  string? sdesc, decimal? amount, DateTime? serviceDate)
        {
            var model = new ServiceRequestModel
            {
                RoomNO = roomNo,
                SDESC = sdesc,
                Amount = amount,
                ServiceDate = serviceDate
            };

            if (id != -1)
            {
                model.Id = id;

                var sucess = await _serviceService.EditService(model);

                if (sucess) return RedirectToAction("SuccessPage",
                    "Home", new { viewName = "Edit Service" });

                return RedirectToAction("FailedPage",
                    "Home", new { viewName = "Edit Service" });
            }
            else
            {
                var sucess = await _serviceService.AddService(model);

                if (sucess) return RedirectToAction("SuccessPage",
                    "Home", new { viewName = "Add Service" });

                return RedirectToAction("FailedPage",
                    "Home", new { viewName = "Add Service" });
            }

        }


        [HttpPost]
        [Route("Service/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sucess = await _serviceService.DeleteService(id);

            if (sucess) return RedirectToAction("SuccessPage",
                "Home", new { viewName = "Delete Service" });

            return RedirectToAction("FailedPage",
                    "Home", new { viewName = "Delete Service" });
        }
    }
}

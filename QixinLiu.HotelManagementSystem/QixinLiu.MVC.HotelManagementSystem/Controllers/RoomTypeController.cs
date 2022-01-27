using ApplicationCore.Models;
using ApplicationCore.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QixinLiu.MVC.HotelManagementSystem.Controllers
{
    public class RoomTypeController : Controller
    {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> AllRoomTypes()
        {
            var lists = await _roomTypeService.ListRoomTypes();

            if (!lists.Any()) return View();

            return View(lists);
        }

        [HttpGet]
        [Route("RoomType/Details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _roomTypeService.GetRoomTypeById(id);

            if (model == null) return View();

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Change(int id)
        {
            RoomTypeResponseModel model;
            if (id != -1)
            {
                model = await _roomTypeService.GetRoomTypeById(id);
            }
            else
            {
                model = new RoomTypeResponseModel
                {
                    Id = -1,
                    RTDESC = "Deluxe",
                    Rent = 100
                };
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Change(int id, string? rtdesc, decimal? rent)
        {
            var model = new RoomTypeRequestModel
            {
                RTDESC = rtdesc,
                Rent = rent
            };

            if (id != -1)
            {
                model.Id = id;

                var sucess = await _roomTypeService.EditRoomType(model);

                if (sucess) return RedirectToAction("SuccessPage",
                    "Home", new { viewName = "Edit Room Type" });
            }
            else
            {
                var sucess = await _roomTypeService.AddRoomType(model);

                if (sucess) return RedirectToAction("SuccessPage",
                    "Home", new { viewName = "Add Room Type" });
            }

            return View();

        }


        [HttpPost]
        [Route("RoomType/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sucess = await _roomTypeService.DeleteRoomType(id);

            if (sucess) return RedirectToAction("SuccessPage",
                "Home", new { viewName = "Delete Room Type" });

            return View();
        }
    }
}

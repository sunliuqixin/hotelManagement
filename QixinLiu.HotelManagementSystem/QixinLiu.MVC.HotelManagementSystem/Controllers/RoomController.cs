using ApplicationCore.Models;
using ApplicationCore.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QixinLiu.MVC.HotelManagementSystem.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> AllRooms()
        {
            var lists = await _roomService.ListRooms();

            if (!lists.Any()) return View();

            return View(lists);
        }

        [HttpGet]
        [Route("Room/Details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _roomService.GetRoomDetails(id);

            if (model == null) return View();

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Change(int id)
        {
            RoomResponseModel model;
            if (id != -1)
            {
                model = await _roomService.GetRoomById(id);
            }
            else
            {
                model = new RoomResponseModel
                {
                    Id = -1,
                    RTCode = 1,
                    Status = true
                };
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Change(int id, int? rtcode, bool status)
        {
            var model = new RoomRequestModel
            {
                RTCode = rtcode,
                Status = status
            };

            if (id != -1)
            {
                model.Id = id;

                var sucess = await _roomService.EditRoom(model);

                if (sucess) return RedirectToAction("SuccessPage",
                    "Home", new { viewName = "Edit Room" });
            }
            else
            {
                var sucess = await _roomService.AddRoom(model);
                
                if (sucess) return RedirectToAction("SuccessPage",
                    "Home", new { viewName = "Add Room" });
            }

            return View();

        }


        [HttpPost]
        [Route("Room/Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sucess = await _roomService.DeleteRoom(id);

            if (sucess) return RedirectToAction("SuccessPage",
                "Home", new { viewName = "Delete Room" });

            return View();
        }
    }
}

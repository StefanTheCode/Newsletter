using System;
using System.Threading.Tasks;
using HotelService.Application.Services.BookingService.Command;
using HotelService.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace HotelService.Controllers
{
    public class BookingController : BaseController
    {
        [HttpPost]
        public async Task Post()
        {
            await Mediator.Send(new Create
            {
                AdultsNumber = 1,
                CheckIn = DateTime.Now,
                CheckOut = DateTime.Now.AddDays(5),
                ChildrenNumber = 1,
                HotelName = "Hotel Neki",
                Place = "Nis",
                RoomNumber = 2
            });
        }
    }
}
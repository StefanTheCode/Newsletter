using System;
using HotelService.Domain.Common;
using HotelService.Domain.Enums;

namespace HotelService.Domain.Entities
{
    public class Hotel : AuditableEntity
    {
        public int Id { get; set; }
        public string Place { get; set; }
        public string HotelName { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int AdultsNumber { get; set; }
        public int ChildrenNumber { get; set; }
        public int RoomNumber { get; set; }
        public BookingStatus Status { get; set; }
    }
}

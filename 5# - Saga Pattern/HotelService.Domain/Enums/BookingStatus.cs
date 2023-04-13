using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Domain.Enums
{
    public enum BookingStatus
    {
        WaitingForFlight = 1,
        WaitingForCar = 2,
        Failed = 3,
        Success = 4
    }
}

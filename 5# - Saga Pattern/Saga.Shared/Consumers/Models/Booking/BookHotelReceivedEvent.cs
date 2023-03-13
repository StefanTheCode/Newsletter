using System;
using Saga.Shared.Consumers.Abstract;
using Saga.Shared.Consumers.Models.Sagas;

namespace Saga.Shared.Consumers.Models.Booking
{
    public class BookHotelReceivedEvent : IBookHotelReceivedEvent
    {
        private readonly BookingState bookingSagaState;

        public BookHotelReceivedEvent(BookingState bookingSagaState)
        {
            this.bookingSagaState = bookingSagaState;
        }

        public Guid CorrelationId => bookingSagaState.CorrelationId;
        public string HotelName => bookingSagaState.HotelName;
    }
}

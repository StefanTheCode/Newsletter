using System;
using Saga.Shared.Consumers.Abstract;
using Saga.Shared.Consumers.Models.Sagas;

namespace Saga.Shared.Consumers.Models.Booking
{
    public class HotelBookedEvent : IHotelBookedEvent
    {
        private readonly BookingState _bookingSagaModel;

        public HotelBookedEvent(BookingState bookingSagaModel)
        {
            _bookingSagaModel = bookingSagaModel;
            CreatedDate = DateTime.Now;
        }

        public Guid CorrelationId => _bookingSagaModel.CorrelationId;
        public DateTime CreatedDate { get; set; }
    }
}
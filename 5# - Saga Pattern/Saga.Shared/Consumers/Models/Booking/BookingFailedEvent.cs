using System;
using Saga.Shared.Consumers.Abstract;
using Saga.Shared.Consumers.Models.Sagas;

namespace Saga.Shared.Consumers.Models.Booking
{
    public class BookingFailedEvent : IBookingFailedEvent
    {
        private readonly BookingState _bookingSagaModel;

        public BookingFailedEvent(BookingState bookingSagaModel)
        {
            _bookingSagaModel = bookingSagaModel;
            CreatedDate = DateTime.Now;
        }

        public Guid CorrelationId => _bookingSagaModel.CorrelationId;
        public DateTime CreatedDate { get; set; }
    }
}
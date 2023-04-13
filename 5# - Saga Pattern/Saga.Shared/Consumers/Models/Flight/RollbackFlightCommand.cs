using System;
using Saga.Shared.Consumers.Abstract;
using Saga.Shared.Consumers.Models.Sagas;

namespace Saga.Shared.Consumers.Models.Flight
{
    public class RollbackFlightCommand : IRollbackFlightCommand
    {
        private readonly BookingState _bookingSagaModel;

        public RollbackFlightCommand(BookingState bookingSagaModel)
        {
            _bookingSagaModel = bookingSagaModel;
            CreatedDate = DateTime.Now;
        }

        public Guid CorrelationId => _bookingSagaModel.CorrelationId;
        public int BookingId => _bookingSagaModel.BookingId;
        public int FlightId => _bookingSagaModel.FlightId;
        public DateTime CreatedDate { get; set; }

        public string FlightName => _bookingSagaModel.HotelName;
    }
}
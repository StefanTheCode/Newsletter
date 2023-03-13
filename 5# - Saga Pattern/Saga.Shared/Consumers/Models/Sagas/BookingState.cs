using System;
using MassTransit;

namespace Saga.Shared.Consumers.Models.Sagas
{
    public class BookingState : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }

        public State CurrentState { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime BookHotelReceivedDateTime { get; set; }
        public DateTime HotelBookedDateTime { get; set; }
        public string HotelName { get; set; }
        public int BookingId { get; set; }
        public int FlightId { get; set; }
        public int CarId { get; set; }
    }
}
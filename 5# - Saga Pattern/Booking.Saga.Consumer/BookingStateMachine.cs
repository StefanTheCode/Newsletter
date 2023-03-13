using System;
using MassTransit;
using Saga.Shared.Consumers.Abstract;
using Saga.Shared.Consumers.Models.Booking;
using Saga.Shared.Consumers.Models.Sagas;

namespace Booking.Saga.Consumer
{
    public class BookingStateMachine : MassTransitStateMachine<BookingState>
    {
        public State HotelBookingReceived { get; set; }
        public State HotelBooked { get; set; }
        public State FlightReservationReceived { get; set; }
        public State FlightReserved { get; set; }

        public Event<IBookHotelCommand> BookHotelCommand { get; private set; }
        public Event<IHotelBookedEvent> HotelBookedEvent { get; private set; }
        public Event<IReserveFlightCommand> ReserveFlightCommand { get; private set; }

        public BookingStateMachine()
        {
            InstanceState(x => x.CurrentState);

            Event(() => BookHotelCommand, cc => cc.CorrelateBy(state => state.HotelName, context => context.Message.HotelName).SelectId(context => Guid.NewGuid()));

            Event(() => HotelBookedEvent, x => x.CorrelateById(context => context.Message.CorrelationId));

            Event(() => ReserveFlightCommand, x => x.CorrelateById(context => context.Message.CorrelationId));

            Initially(
                When(BookHotelCommand)
                .Then(context =>
                {
                    context.Saga.BookHotelReceivedDateTime = DateTime.Now;
                    context.Saga.HotelName = context.Message.HotelName;
                })
                .ThenAsync(context => Console.Out.WriteLineAsync($"Booking for Hotel {context.Message.HotelName} received."))
                .TransitionTo(HotelBookingReceived)
                .Publish(context => new BookHotelReceivedEvent(context.Saga))
                );

            During(HotelBookingReceived,
                When(HotelBookedEvent)
                .Then(context => context.Saga.HotelBookedDateTime = DateTime.Now)
                .ThenAsync(context => Console.Out.WriteLineAsync($"Hotel {context.Saga.HotelName} booked."))
                .TransitionTo(HotelBooked)
                );

            During(HotelBooked,
               When(ReserveFlightCommand)
               .Then(context => context.Saga.HotelBookedDateTime = DateTime.Now)
               .ThenAsync(context => Console.Out.WriteLineAsync($"FLight {context.Saga.HotelName} reserved."))
               .Finalize()
               );

            SetCompletedWhenFinalized();
        }
    }
}
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotelService.Application.Common.Models;
using MassTransit;
using MediatR;
using Saga.Core.Concrete.Brokers;
using Saga.Core.Constants;
using Saga.Core.MessageBrokers.Concrete;
using Saga.Shared.Consumers.Abstract;

namespace HotelService.Application.Services.BookingService.Command
{
    public class Create : IRequest<Result>
    {
        public string Place { get; set; }
        public string HotelName { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int AdultsNumber { get; set; }
        public int ChildrenNumber { get; set; }
        public int RoomNumber { get; set; }
    }

    public class CreateHandler : IRequestHandler<Create, Result>
    {
        private readonly ISendEndpoint _sendEndpoint;
        private readonly MassTransitSettings _massTransitSettings;

        public CreateHandler(MassTransitSettings massTransitSettings)
        {
            _massTransitSettings = massTransitSettings;

            var busInstance = BusConfiguration.Instance.ConfigureBus(_massTransitSettings);
            _sendEndpoint = busInstance.GetSendEndpoint(new Uri($"{_massTransitSettings.Uri}/{SagaConstants.SAGAQUEUENAME}")).Result;
        }

        public async Task<Result> Handle(Create request, CancellationToken cancellationToken)
        {
            await _sendEndpoint.Send<IBookHotelCommand>(new
            {
                HotelName = "Hotel Serbia"
            });

            return new Result(true, Enumerable.Empty<string>());
        }
    }
}
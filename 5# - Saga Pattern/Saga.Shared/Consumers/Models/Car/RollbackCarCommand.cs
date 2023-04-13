﻿using System;
using Saga.Shared.Consumers.Abstract;
using Saga.Shared.Consumers.Models.Sagas;

namespace Saga.Shared.Consumers.Models.Car
{
    public class RollbackCarCommand : IRollbackCarCommand
    {
        private readonly BookingState _bookingSagaModel;

        public RollbackCarCommand(BookingState bookingSagaModel)
        {
            _bookingSagaModel = bookingSagaModel;
            CreatedDate = DateTime.Now;
        }

        public Guid CorrelationId => _bookingSagaModel.CorrelationId;
        public int BookingId => _bookingSagaModel.BookingId;
        public int FlightId => _bookingSagaModel.FlightId;
        public DateTime CreatedDate { get; set; }
    }
}
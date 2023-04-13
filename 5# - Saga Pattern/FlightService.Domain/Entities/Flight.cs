using FlightService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightService.Domain.Entities
{
    public class Flight : AuditableEntity
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
    }
}
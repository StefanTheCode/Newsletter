using FlightService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FlightService.Application.Common
{
    public interface IFlightDbContext
    {
        DbSet<Flight> Flights { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
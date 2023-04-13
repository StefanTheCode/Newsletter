using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HotelService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelService.Application.Common
{
    public interface IHotelDbContext
    {
        DbSet<Hotel> Hotel { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
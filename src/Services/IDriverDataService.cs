using System;
using Domain.Models;

namespace Services
{
	public interface IDriverDataService
	{
        Task<IEnumerable<Driver>>? GetDriversForLocation(string location, CancellationToken ct);
    }
}


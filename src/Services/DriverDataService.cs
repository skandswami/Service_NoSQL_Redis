using System;
using Domain.Models;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.AspNetCore.Http;
using Services.Extensions;

namespace Services
{
	public class DriverDataService : IDriverDataService
    {
        private readonly IDistributedCache _cache;
		private const string redisId = "drivers";
		private readonly List<Driver> drivers = new List<Driver>
		{
			new ("Driver1", "Surname1", "Loc1"),
			new ("Driver2", "Surname2", "Loc2"),
			new ("Driver3", "Surname3", "Loc3"),
			new ("Driver4", "Surname4", "Loc4"),
			new ("Driver5", "Surname5", "Loc4"),
			new ("Driver6", "Surname6", "Loc6"),
			new ("Driver7", "Surname7", "Loc7"),
			new ("Driver8", "Surname8", "Loc4"),
			new ("Driver9", "Surname9", "Loc9"),
			new ("Driver10", "Surname10", "Loc10"),
        };

        public DriverDataService(IDistributedCache cache)
		{
			_cache = cache;
		}

		public async Task<IEnumerable<Driver>?> GetDriversForLocation(string location, CancellationToken ct)
		{
            await RedisExtension.SetRecordAsync(_cache, redisId, drivers, ct);

            var allDrivers = await RedisExtension.GetRecordAsync<List<Driver>>(_cache, redisId);

			if(allDrivers is null)
			{
				return default(List<Driver>); 
			}

			return allDrivers.Where(drivers => drivers.Location == location);
			
		}
    }
}


using System;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace Services.Extensions
{
	public static class RedisExtension
	{
		public static async Task SetRecordAsync<T>(this IDistributedCache cache,
			string recordId,
			T data,
			CancellationToken ct,
			TimeSpan? absoluteExpireTime = null)
		{

            DistributedCacheEntryOptions options = new();
			options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromHours(1);

			var jsonData = JsonSerializer.Serialize(data);
			try
			{
				await cache.SetStringAsync(recordId, jsonData, options, ct);
			}
			catch(Exception ex)
			{

			}
		}

        public static async Task<T?> GetRecordAsync<T>(this IDistributedCache cache,
            string recordId)
        {
			try
			{
				var jsonData = await cache.GetStringAsync(recordId);

                if (jsonData is null)
                {
                    return default(T);
                }

                return JsonSerializer.Deserialize<T>(jsonData);
            }
			catch(Exception ex)
			{
				throw ex;
			}

			
        }
    }
}


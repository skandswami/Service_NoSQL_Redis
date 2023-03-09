using FakeItEasy;
using Microsoft.Extensions.Caching.Distributed;
using Services;
using Services.Extensions;

namespace NoSqlService.Tests;

public class DriverTests
{
    [Fact]
    public async Task GetDrivers_NoErrorAsync()
    {
        //await RedisExtension.GetRecordAsync<IEnumerable<string>>(A<IDistributedCache>.Ignored, A<string>.Ignored);
        //driverService.GetDriversForLocation(A<string>.Ignored,A<CancellationToken>.Ignored).Returns()
    }
}

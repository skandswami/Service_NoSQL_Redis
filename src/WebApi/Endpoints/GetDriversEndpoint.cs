using System;
using Domain.Models;
using FastEndpoints;
using Services;
using WebApi.Endpoints.Requests;

namespace WebApi.Endpoints
{
	public class GetDriversEndpoint : Endpoint<GetDriversRequest>
	{
        private readonly IDriverDataService _driverService;

        public GetDriversEndpoint(IDriverDataService driverService)
        {
            _driverService = driverService;
        }
        public override void Configure()
        {
            Post("/api/getdrivers");
            //AllowAnonymous();
        }

        public override async Task HandleAsync(GetDriversRequest req, CancellationToken ct)
        {
            try
            {
                var response = await _driverService.GetDriversForLocation(req.Location, ct)!;

                if (response is null || !response.Any())
                {
                    await SendNotFoundAsync(ct);
                    return;
                }
                await SendAsync(response!);
            }
            catch
            {
                await SendErrorsAsync();
            }

        }
    }
}


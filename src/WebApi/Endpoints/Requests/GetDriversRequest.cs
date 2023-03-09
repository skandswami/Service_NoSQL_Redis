using System;
namespace WebApi.Endpoints.Requests;

/// <summary>
/// Request model for the <see cref="WebApi.Endpoints.GetDriversEndpoint"/>.
/// </summary>
public class GetDriversRequest
{
    /// <summary>
    /// Location of the drivers.
    /// </summary>
    public string Location { get; set; } = default!;
}


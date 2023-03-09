using System;
using FastEndpoints;
using FastEndpoints.Security;
using WebApi.Endpoints.Requests;

namespace WebApi.Endpoints
{
    public class UserLoginEndpoint : Endpoint<LoginRequest>
    {
        public override void Configure()
        {
            Post("/api/login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
        {
            if (true) // Check credentials are valid
            {
                try
                {
                    var jwtToken = JWTBearer.CreateToken(
                        signingKey: "TokenSigningKeyTokenSigningKey", // Ideally from the vault
                        expireAt: DateTime.UtcNow.AddDays(1)
                        );

                    await SendAsync(new
                    {
                        Username = req.Username,
                        Token = jwtToken
                    });
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
            else
            {
                ThrowError("The supplied credentials are invalid!");
            }
        }
    }
}


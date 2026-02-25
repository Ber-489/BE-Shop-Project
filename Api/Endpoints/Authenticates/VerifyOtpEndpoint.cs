namespace Api.Endpoints.Authenticates;

public class VerifyOtpEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/auth/verify-otp",
            async (
                VerifyOtpCommand command,
                IMediator mediator,
                HttpContext ctx) =>
            {
                var result = await mediator.Send(command);

                var response = ApiResponse<VerifyOtpResponse>
                    .Success(result, "OTP verified successfully");

                response.TraceId = ctx.TraceIdentifier;

                return Results.Ok(response);
            })
        .WithName("VerifyOtp")
        .WithTags("Authenticates")
        .Produces<ApiResponse<VerifyOtpResponse>>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest);
    }
}
namespace Api.Endpoints.Authenticates;

public class SendRegisterOtpEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/authenticates/send-register-otp",
            async (
                SendRegisterOtpCommand command,
                IMediator mediator,
                HttpContext ctx) =>
            {
                var result = await mediator.Send(command);

                var response = ApiResponse<SendRegisterOtpResponse>
                    .Success(result, "OTP sent successfully");

                response.TraceId = ctx.TraceIdentifier;

                return Results.Ok(response);
            })
            .WithTags("Authenticates")
            .WithName("SendRegisterOtp")
            .ProducesValidationProblem()
            .Produces<ApiResponse<SendRegisterOtpResponse>>(StatusCodes.Status200OK);
    }
}
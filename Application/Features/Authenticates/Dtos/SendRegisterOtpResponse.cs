namespace Application.Features.Authenticates.Dtos;

public record SendRegisterOtpResponse(
    Guid SessionId,
    string Phone,
    int OtpValidityMinutes
);
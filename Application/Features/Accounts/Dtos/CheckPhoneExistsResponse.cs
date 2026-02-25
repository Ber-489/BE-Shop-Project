namespace Application.Features.Accounts.Dtos;

public class CheckPhoneExistsResponse
{
    public bool Exists { get; set; }
    public bool IsFirstLogin { get; set; }
}
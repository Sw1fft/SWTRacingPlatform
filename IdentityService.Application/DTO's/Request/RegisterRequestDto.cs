namespace IdentityService.Application.DTO_s.Request
{
    public record RegisterRequestDto(
        string FirstName,
        string LastName,
        string Username,
        string Email,
        string Phone,
        string Password,
        string ConfirmPassword);
}

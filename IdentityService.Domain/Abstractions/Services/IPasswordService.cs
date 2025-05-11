namespace IdentityService.Domain.Abstractions.Services
{
    public interface IPasswordService
    {
        Task<string> GeneratePassword(string password);
        Task<bool> VerifyPassword(string password, string hasedPassword);
        Task<bool> CompairPassword(string password, string passwordConf);
    }
}

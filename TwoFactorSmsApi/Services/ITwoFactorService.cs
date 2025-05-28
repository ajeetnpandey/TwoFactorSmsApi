namespace TwoFactorSmsApi.Services
{
    public interface ITwoFactorService
    {
        Task SendOtpSmsAsync(string phoneNumber);
    }
}

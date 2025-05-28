namespace TwoFactorSmsApi.Services
{
    public interface ISmsSender
    {
        Task<string> SendSmsAsync(string phoneNumber, string message);
    }
}

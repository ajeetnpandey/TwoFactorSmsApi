namespace TwoFactorSmsApi.Services
{
    public class TwoFactorService : ITwoFactorService
    {
        private readonly ISmsSender _smsSender;

        public TwoFactorService(ISmsSender smsSender)
        {
            _smsSender = smsSender;
        }

        public async Task SendOtpSmsAsync(string phoneNumber)
        {
            var otp = new Random().Next(100000, 999999).ToString(); // Generate 6-digit OTP

            // You would ideally store OTP in cache (like Redis) with expiration for validation
            await _smsSender.SendSmsAsync(phoneNumber, otp);
        }

        public Task<string> GenerateOtpAsync(string userId) => Task.FromResult("Not Used Anymore");

        public Task<bool> ValidateOtpAsync(string userId, string token) => Task.FromResult(true); // Implement validation logic
    }
}

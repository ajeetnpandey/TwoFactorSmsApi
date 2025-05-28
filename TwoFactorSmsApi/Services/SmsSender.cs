using Microsoft.Extensions.Options;
using TwoFactorSmsApi.Models;

namespace TwoFactorSmsApi.Services
{
    public class SmsSender : ISmsSender
    {
        private readonly HttpClient _httpClient;
        private readonly SmsSettings _settings;

        public SmsSender(IOptions<SmsSettings> options)
        {
            _httpClient = new HttpClient();
            _settings = options.Value;
        }

        public async Task<string> SendSmsAsync(string phoneNumber, string message)
        {
            var url = string.Format(_settings.AjeetUrl, _settings.AjeetKey, phoneNumber, message);

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to send SMS");
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
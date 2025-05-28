using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwoFactorSmsApi.Services;

namespace TwoFactorSmsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITwoFactorService _twoFactorService;

        public AuthController(ITwoFactorService twoFactorService)
        {
            _twoFactorService = twoFactorService;
        }

        [HttpPost("send-sms-otp")]
        public async Task<IActionResult> SendSmsOtp([FromBody] PhoneNumberDto dto)
        {
            await _twoFactorService.SendOtpSmsAsync(dto.PhoneNumber);
            return Ok("OTP sent");
        }

        public class PhoneNumberDto
        {
            public string PhoneNumber { get; set; }
        }
    }
}

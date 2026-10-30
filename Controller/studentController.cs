    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto request)
        {
            // TODO: yahan DB check aayega
            var email = _configuration["AdminLogin:Email"];
            var password = _configuration["AdminLogin:Password"];
            bool isValid = !string.IsNullOrEmpty(email) &&
                           !string.IsNullOrEmpty(password) &&
                           request.Email == email &&
                           request.Password == password;

            if (isValid)
                return Ok(true);

            return Unauthorized(false);
        }
    }
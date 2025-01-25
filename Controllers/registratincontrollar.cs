using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using registration_M1_.DTOs;
using registration_M1_.Models;
using registration_M1_.repos;

namespace registration_M1_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class registrationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public registrationController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO userDTO)
        {
            var user = await _userRepository.Authenticate(userDTO.Username, userDTO.Password);
            if (user == null) return Unauthorized("Invalid credentials");

            return Ok(user);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserDTO userDTO)
        {
            var user = new User { Username = userDTO.Username, Password = userDTO.Password };
            await _userRepository.Register(user);

            return Ok("User registered successfully");
        }

        [HttpPost("forgetpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] Forgetpassworddto forgotPasswordDTO)
        {
            var result = await _userRepository.ForgotPassword(forgotPasswordDTO.Email);
            if (!result) return BadRequest("Email not found");

            return Ok("Password reset instructions sent");
        }
    }

}

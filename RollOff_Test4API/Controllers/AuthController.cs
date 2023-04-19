using Microsoft.AspNetCore.Mvc;
using RollOff_Test4API.Models.DTO;
using RollOff_Test4API.Repository;
using System.Threading.Tasks;

namespace RollOff_Test4API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUser userRepository;
        private readonly ITokenHandler handler;

        public AuthController(IUser userRepository, ITokenHandler handler)
        {
            this.userRepository = userRepository;
            this.handler = handler;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(Userlogin loginRequestDTO)
        {

            if (loginRequestDTO.Email == null && loginRequestDTO.Password == null && loginRequestDTO.Department==null)
            {
                return NotFound("email or password is null");
            }
            
            var user = await userRepository.AuthenticateUserAsync(loginRequestDTO.Email, loginRequestDTO.Password,loginRequestDTO.Department);
            if (user != null)
            {
                //generate jwt token
                var token = handler.CreateTokenAsync(user);
                return Ok(token);
            }
            return BadRequest("Username or password is incorrect or role is incorrect");
        }
    }
}

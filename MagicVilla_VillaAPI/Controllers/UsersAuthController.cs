using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto.Authentication;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        protected APIResponse _APIResponse;
        public UsersAuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            this._APIResponse = new();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var loginResponse = await _userRepository.Login(model);
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _APIResponse.StatusCode = HttpStatusCode.BadRequest;
                _APIResponse.IsSuccess = false;
                _APIResponse.ErrorMessage.Add("username or password is not correct");
                return BadRequest(_APIResponse);
            }
            _APIResponse.StatusCode = HttpStatusCode.OK;
            _APIResponse.IsSuccess = true;
            _APIResponse.Result = loginResponse;
            return Ok(_APIResponse);
        }
        [HttpPost("registration")]
        public async Task<IActionResult> registration([FromBody] RegistrationRequestDTO model)
        {
            bool ifUserNameUnique = _userRepository.IsUniqueUser(model.UserName);
            if (!ifUserNameUnique)
            {
                _APIResponse.StatusCode = HttpStatusCode.BadRequest;
                _APIResponse.IsSuccess = false;
                _APIResponse.ErrorMessage.Add("username already exists");
                return BadRequest(_APIResponse);
            }
            var user = await _userRepository.Register(model);
            if (user == null)
            {
                _APIResponse.StatusCode = HttpStatusCode.BadRequest;
                _APIResponse.IsSuccess = false;
                _APIResponse.ErrorMessage.Add("Error while registration");
                return BadRequest(_APIResponse);
            }
            _APIResponse.StatusCode = HttpStatusCode.OK;
            _APIResponse.IsSuccess = true;
            return Ok(_APIResponse);
        }
    }
}

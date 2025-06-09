using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService addressService)
        {
            _userService = addressService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, _userService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var user = _userService.GetById(id);

            if (user == null)
                return StatusCode(404);

            return StatusCode(200, user);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Add([FromBody] CreateOrUpdateUserDTO createUserDTO)
        {
            if (!ModelState.IsValid)
                return StatusCode(400, ModelState);

            _userService.Add(createUserDTO);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] CreateOrUpdateUserDTO updateUserDTO, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return StatusCode(400, ModelState);

            var user = _userService.GetById(id);

            if (user == null)
                return StatusCode(404);

            _userService.Update(id, updateUserDTO);

            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userToDelete = _userService.GetById(id);

            if (userToDelete == null)
                return StatusCode(404);

            _userService.Delete(id);

            return StatusCode(204);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {
            var token = _userService.GenerateToken(loginDTO);

            if (token == null)
                StatusCode(500);

            return StatusCode(200, token);
        }
    }
}

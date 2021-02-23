using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Test.EventScheduler.Data.DTOs;
using Test.EventScheduler.Services.Interfaces;

namespace Test.UserScheduler.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _service.GetUsers());
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            return Ok(await _service.GetUser(userId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto userDto)
        {
            return Ok(await _service.CreateUser(userDto));
        }

        [HttpPut]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, UpdateUserDto userDto)
        {
            userDto.UserId = userId;

            await _service.UpdateUser(userDto);

            return NoContent();
        }

        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            await _service.DeleteUser(userId);

            return NoContent();
        }
    }
}

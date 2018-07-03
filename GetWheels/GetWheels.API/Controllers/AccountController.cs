using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetWheels.Data.Contracts;
using GetWheels.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace GetWheels.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        public readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }      

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userRepository.GetUsersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            if(user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id,[FromBody] User user)
        {
            if(id != user.Id)
            {
                return BadRequest();
            }

            var updatedUser = await _userRepository.UpdateAsync(user);

            return Ok(updatedUser);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userRepository.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdUser = await _userRepository.CreateUser(user);
            return Ok(createdUser);
        }


    }
}
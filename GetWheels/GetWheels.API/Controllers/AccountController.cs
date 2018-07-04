using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetWheels.Data.Models;
using GetWheels.Data.Models.ViewModels;
using GetWheels.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GetWheels.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public readonly IJwtService _jwtService;

        public AccountController(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IJwtService jwtService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtService = jwtService;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userManager.Users
                .SingleOrDefaultAsync(u => u.Id == id);
            if(user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var result = await _signInManager
                .PasswordSignInAsync(model.UserName, model.Password, model.IsPersistent, false);

            if (result.Succeeded)
            {
                var user = _userManager.Users.SingleOrDefault(r => r.Email == model.UserName);
                string token = await _jwtService.GenerateJwtToken(user.Email, user.Id, user);
                return Ok(new { token });
            }
            return BadRequest("Supplied values are invalid!");
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var registrationResult = await _userManager.CreateAsync(user, model.Password);

            if(registrationResult.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                string token = await _jwtService.GenerateJwtToken(user.Email, user.Id, user);
                return Ok(new { token });
            }
            return BadRequest(registrationResult.Errors);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Splitwise.DomainModel;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using Splitwise.Repository.UserRepository;

namespace Splitwise.Core.Controller
{
        [Route("api/[controller]")]
        [ApiController]
        public class UserController : ControllerBase
        {
            private readonly UserManager<User> _userManager;
            private readonly IUserRepository _userRepository;

            public UserController(UserManager<User> userManager, IUserRepository userRepository)
            {
               this._userManager = userManager;
               this._userRepository = userRepository;
            }
            [HttpPost]
            [Route("register")]
            public async Task<IActionResult> Register(RegisterUserAC user)
            {
                if (ModelState.IsValid)
                {
                    //if (!_userRepository.UserExists(user.UserEmail))
                    //{
                        await _userRepository.RegisterUser(user);
                        return Ok(user);
                    //}
                    //return BadRequest(new { message = "Email already in use..." });
                }
                return BadRequest();
            }
        // GET: api/user
        [HttpGet]
            public async Task<IEnumerable<UserAC>> GetUsers()
            {
                return this._userRepository.GetUsers();
            }
            // GET: api/user/5
            [HttpGet("{id}")]
            public async Task<IActionResult> GetUser([FromRoute] string id)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var users = await this._userRepository.GetUser(id);

                if (users == null)
                {
                    return NotFound();
                }

                return Ok(users);
            }
            // GET: api/Users/byEmail/abc@gmail.com
            [HttpGet("byEmail/{email}")]
            public async Task<IActionResult> GetUserByEmail([FromRoute] string email)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var users =await this._userRepository.GetUserByEmailAsync(email);

                if (users == null)
                {
                    return NotFound();
                }

                return Ok(users);
            }
    }
}

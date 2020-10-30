using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            //POST: api/user/register
            [HttpPost]
            [Route("register")]
            public async Task<IActionResult> Register(RegisterUserAC user)
            {
                if (ModelState.IsValid)
                {
                    if (!this.UserExistsByEmail(user.UserEmail))
                    {
                        await _userRepository.RegisterUser(user);
                        return Ok(user);
                    }
                    return BadRequest(new { message = "Email already in use..." });
                }
                return BadRequest();
            }
        //POST: api/user/login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginUserAC model)
        {
            if (ModelState.IsValid)
            {
                var token = await this._userRepository.LoginUser(model);
                if (token!=null)
                {
                    return Ok(token);
                }
                return Unauthorized();
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
                
                var users =await this._userRepository.GetUserByEmailAsync(email);

                if (users == null)
                {
                    return NotFound();
                }

                return Ok(users);
            }
        //DELETE: api/user/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserAC>> DeleteEmployee(string id)
        {
            if (this.UserExistsById(id))
            {
                await this._userRepository.DeleteUser(id);
                return Ok();
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(string id, UserAC user)
        {
            if (ModelState.IsValid)
            {
                if (this._userRepository.UserExistsById(id))
                {
                    user.Id = id;
                    await this._userRepository.UpdateUser(user);
                    return Ok(user);
                }
                return NotFound();
            }
            return BadRequest();
        }
        private bool UserExistsById(string id)
        {
            return _userRepository.UserExistsById(id);
        }
        private bool UserExistsByEmail(string email)
        {
            return _userRepository.UserExistsByEmail(email);
        }
    }
}

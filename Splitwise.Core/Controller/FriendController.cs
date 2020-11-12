using Microsoft.AspNetCore.Mvc;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.Repository.FriendRepository;
using Splitwise.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Core.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        #region Private Variables
        private readonly IFriendRepository _friendRepository;
        private readonly IUserRepository _userRepository;
        #endregion

        #region Constructors
        public FriendController(IFriendRepository friendRepository, IUserRepository userRepository)
        {
            this._friendRepository = friendRepository;
            this._userRepository = userRepository;
        }
        #endregion
        #region Private methods
        private bool FriendExistsById(string userId, string userFriendId)
        {
            return _friendRepository.FriendExistsById(userId, userFriendId);
        }
        private bool FriendExistsByEmail(string userId, string userFriendEmail)
        {
            return _friendRepository.FriendExistsByEmail(userId, userFriendEmail);
        }
        #endregion
        #region Public methods
        // GET: api/payee/payeebyexpenseid/2
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<UserAC>>> GetFriends([FromRoute] string userId)
        {
            return Ok(await this._friendRepository.GetFriends(userId));
        }

        // POST: api/payee
        [HttpPost]
        public async Task<ActionResult<UserAC>> AddFriend(AddFriendAC friend)
        {
            if (ModelState.IsValid)
            {
                if (this._userRepository.UserExistsByEmail(friend.UserFriendEmail))
                {
                    if (this.FriendExistsByEmail(friend.UserId, friend.UserFriendEmail) == false)
                    {
                        var userFriend = await this._friendRepository.AddFriend(friend.UserId, friend.UserFriendEmail);
                        return Ok(userFriend);
                    }
                    return BadRequest(new { message = "Already a friend" });
                }
                return NotFound(new { message = "Friend User is not registered" });
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<ActionResult<UserAC>> RemoveFriend(RemoveFriendAC friend)
        {
            if (ModelState.IsValid)
            {
                if (this._userRepository.UserExistsById(friend.UserFriendId))
                {
                    if (this.FriendExistsById(friend.UserId, friend.UserFriendId))
                    {
                        var removedFriend = await this._friendRepository.RemoveFriend(friend.UserId, friend.UserFriendId);
                        return Ok(removedFriend);
                    }
                    return BadRequest(new { message = "Not a friend" });
                }
                return NotFound(new { message = "Friend User is not registered" });
            }
            return BadRequest();
        }
        #endregion
    }
}

using Microsoft.AspNetCore.Mvc;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.Repository.GroupRepository;
using Splitwise.Repository.UserGroupRepository;
using Splitwise.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Core.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IUserGroupRepository _usergroupRepository;

        public UserGroupController(IUserGroupRepository usergroupRepository, IGroupRepository groupRepository, IUserRepository userRepository)
        {
            this._userRepository = userRepository;
            this._groupRepository = groupRepository;
            this._usergroupRepository = usergroupRepository;
        }

        // GET: api/usergroup/groupbyuserid/id
        [HttpGet("groupbyuserid/{userid}")]
        public async Task<IEnumerable<GroupAC>> Getusergroups(string userid)
        {
            if (this.UserExistsById(userid))
            {
                return await this._usergroupRepository.GetUserGroupsByUserId(userid);
            }
            return null;
        }
        // GET: api/usergroup/userbygroupid/2
        [HttpGet("userbygroupid/{groupid}")]
        public async Task<IEnumerable<UserAC>> Getuseringroups(int groupid)
        {
            if (this.GroupExists(groupid))
            {
                return await this._usergroupRepository.GetGroupMembersByGroupId(groupid);
            }
            return null;
        }
        //POST: api/usergroup
        [HttpPost]
        [Route("addusertogroup")]
        public async Task<ActionResult> PostUserGroup(UserGroupMapping ugmapping)
        {
            if (ModelState.IsValid)
            {
                if (this.GroupExists(ugmapping.GroupId))
                {
                    if (this.UserExistsById(ugmapping.UserId))
                    {
                        if (!this.GroupMemberExists(ugmapping.UserId, ugmapping.GroupId))
                        {
                            await this._usergroupRepository.AddUserToGroup(ugmapping.UserId, ugmapping.GroupId);
                            return Ok(new { message = "user was added to the group" });
                        }
                        return BadRequest(new { message = "this user is already a member of this group"});
                    }
                    return BadRequest(new { message = "user doesnot exist"});
                }
                return BadRequest(new { message = "group doesnot exist"});
            }
            return BadRequest();
        }
        // POST: api/usergroup
        [HttpPost]
        [Route("removeuserfromgroup")]
        public async Task<ActionResult<GroupAC>> DeleteUserGroup(UserGroupMapping ugmapping)
        {
            if (ModelState.IsValid)
            {
                if (this.GroupExists(ugmapping.GroupId))
                {
                    if (this.UserExistsById(ugmapping.UserId))
                    {
                        if (this.GroupMemberExists(ugmapping.UserId, ugmapping.GroupId))
                        {
                            await this._usergroupRepository.RemoveUserFromGroup(ugmapping.UserId, ugmapping.GroupId);
                            return Ok(new { message = "user was removed the group" });
                        }
                        return BadRequest(new { message = "user is not a memebr of this group" });
                    }
                    return BadRequest(new { message = "user doesnot exist" });
                }
                return BadRequest(new { message = "group doesnot exist" });
            }
            return BadRequest();
        }

        private bool GroupExists(int id)
        {
            return _groupRepository.GroupExists(id);
        }
        private bool UserExistsById(string id)
        {
            return _userRepository.UserExistsById(id);
        }
        private bool GroupMemberExists(string userId, int groupId)
        {
            return _usergroupRepository.GroupMemberExists(userId, groupId);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.Repository.GroupRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Splitwise.Core.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        #region Private Variables
        private readonly IGroupRepository _groupRepository;
        #endregion

        #region Constructors
        public GroupController(IGroupRepository groupRepository)
        {
            this._groupRepository = groupRepository;
        }
        #endregion
        #region Private methods
        private bool GroupExists(int id)
        {
            return _groupRepository.GroupExists(id);
        }
        #endregion
        #region Public methods
        // GET: api/group
        [HttpGet]
        [Route("/api/Groups")]
            public async Task<ActionResult<GroupAC>> GetGroups()
            {
            return Ok(await this._groupRepository.GetGroups());
            }
        // GET: api/group/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupAC>> GetGroup([FromRoute] int id)
        {
            var group = await this._groupRepository.GetGroup(id);

            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        // PUT: api/GroupsApi/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GroupAC>> PutGroup(int id, GroupAC group)
        {
            try
            {
                group.GroupId = id;
                await this._groupRepository.UpdateGroup(group);
                
            }
            catch (Exception)
            {
                if (!GroupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(group);
        }

        // POST: api/group
        [HttpPost]
        public async Task<ActionResult<GroupAC>> PostGroup(GroupAC group)
        {
            if (ModelState.IsValid)
            {
                var addedGroup = await this._groupRepository.CreateGroup(group);
                return Ok(addedGroup);
            }
            return BadRequest();
        }

        // DELETE: api/GroupsApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupAC>> DeleteGroup(int id)
        {
            //var Group = await _context.depatments.FindAsync(id);
            if (this.GroupExists(id))
            {
                await _groupRepository.DeleteGroup(id);
                return Ok(id);
            }
            return NotFound();
        }
        #endregion
    }
}

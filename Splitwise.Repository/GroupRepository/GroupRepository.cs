﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Splitwise.DomainModel;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using Splitwise.Repository.UserGroupRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.GroupRepository
{
    public class GroupRepository : IGroupRepository
    {
        #region Private Variables
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly SplitwiseDbContext _context;
        private readonly IUserGroupRepository _userGroupRepository;
        #endregion

        #region Constructors
        public GroupRepository(SplitwiseDbContext _context, UserManager<User> _userManager, IMapper _mapper, IUserGroupRepository userGroupRepository)
        {
            this._context = _context;
            this._userManager = _userManager;
            this._mapper = _mapper;
            this._userGroupRepository = userGroupRepository;
        }
        #endregion
        #region Public methods
        public async Task<GroupAC> CreateGroup(GroupAC group)
        {
            var groupName = group.GroupName;
            var groupCreatorId = group.GroupCreatorId;
            this._context.Groups.Add(this._mapper.Map<Group>(group));
            await _context.SaveChangesAsync();
            var newGroup = this._context.Groups.Where(g => g.GroupName == groupName).Select(g => g).FirstOrDefault();
            var groupId = newGroup.GroupId;
            await this._userGroupRepository.AddUserToGroup(groupCreatorId,groupId);
            await _context.SaveChangesAsync();
            return this._mapper.Map<GroupAC>(newGroup);
        }

        public async Task DeleteGroup(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
        }

        public async Task<GroupAC> GetGroup(int groupId)
        {
            return _mapper.Map<GroupAC>(await this._context.Groups.Where(g=>g.GroupId==groupId).SingleOrDefaultAsync());
        }

        public async Task<IEnumerable<GroupAC>> GetGroups()
        {
            return this._mapper.Map<IEnumerable<GroupAC>>( await this._context.Groups.Include(e=>e.GroupCreator).Select(e=>e).ToListAsync());
        }

        public bool GroupExists(int groupId)
        {
            return _context.Groups.Any(e => e.GroupId == groupId);
        }

        public async Task UpdateGroup(GroupAC groupAC)
        {
            var groupToUpdate = this._context.Groups.Where(e => e.GroupId == groupAC.GroupId).FirstOrDefault();
            groupToUpdate.GroupName = groupAC.GroupName;
            this._context.Groups.Update(groupToUpdate);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}

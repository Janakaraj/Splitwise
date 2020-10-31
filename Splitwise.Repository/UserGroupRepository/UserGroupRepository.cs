﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Splitwise.DomainModel;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.UserGroupRepository
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly SplitwiseDbContext _context;


        public UserGroupRepository(SplitwiseDbContext _context, UserManager<User> _userManager, IMapper _mapper)
        {
            this._context = _context;
            this._userManager = _userManager;
            this._mapper = _mapper;
        }
        public async Task AddUserToGroup(string userId, int groupId)
        {
            if(!this.GroupMemberExists(userId, groupId))
            {
                UserGroup userGroup = new UserGroup();
                userGroup.UserId = userId;
                userGroup.GroupId = groupId;
                this._context.UserGroups.Add(userGroup);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserAC>> GetGroupMembersByGroupId(int groupId)
        {
            return _mapper.Map<IEnumerable<UserAC>>(
                this._context.UserGroups
                .Where(ug => ug.GroupId == groupId)
                .Include(u => u.User)
                .Select(u => u.User));
        }

        public async Task<IEnumerable<GroupAC>> GetUserGroupsByUserId(string userId)
        {
            return _mapper.Map<IEnumerable<GroupAC>>(
                this._context.UserGroups
                .Where(ug=>ug.UserId == userId)
                .Include(g=>g.Group)
                .Select(g=>g.Group));
        }

        public bool GroupMemberExists(string userId, int groupId)
        {
            return _context.UserGroups.Any(e => (e.UserId == userId) && (e.GroupId == groupId));
        }

        public async Task RemoveUserFromGroup(string userId, int groupId)
        {
            if (this.GroupMemberExists(userId, groupId))
            {
                UserGroup usergroup = this._context.UserGroups.Where(e => (e.UserId == userId) && (e.GroupId == groupId)).FirstOrDefault();
                _context.UserGroups.Remove(usergroup);
                await _context.SaveChangesAsync();
            }
        }
            
    }
}

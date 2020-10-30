using AutoMapper;
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

namespace Splitwise.Repository.GroupRepository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly SplitwiseDbContext _context;


        public GroupRepository(SplitwiseDbContext _context, UserManager<User> _userManager, IMapper _mapper)
        {
            this._context = _context;
            this._userManager = _userManager;
            this._mapper = _mapper;
        }
        public async Task CreateGroup(GroupAC group)
        {
            this._context.Groups.Add(this._mapper.Map<Group>(group));
            await _context.SaveChangesAsync();
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

        public IEnumerable<GroupAC> GetGroups()
        {
            return this._mapper.Map<IEnumerable<GroupAC>>(this._context.Groups);
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
    }
}

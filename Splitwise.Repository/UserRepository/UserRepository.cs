using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Splitwise.DomainModel;
using Splitwise.DomainModel.ApplicationClasses;
using Splitwise.DomainModel.Models;
using Splitwise.Repository.GroupRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise.Repository.UserRepository
{
    public class UserRepository:IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly SplitwiseDbContext _context;
        private readonly IGroupRepository _groupRepository;


        public UserRepository(SplitwiseDbContext _context, UserManager<User> _userManager, IConfiguration _configuration, IMapper _mapper, IGroupRepository groupRepository)
        {
            this._context = _context;
            this._userManager = _userManager;
            this._configuration = _configuration;
            this._mapper = _mapper;
            this._groupRepository = groupRepository;
        }
        public async Task<IEnumerable<UserAC>> GetUsers() {
            var users = await this._userManager.Users.ToListAsync();
            return this._mapper.Map<IEnumerable<UserAC>>(users);
        }
        public async Task<UserAC> GetUser(string userId) {
            return _mapper.Map<UserAC>(await _userManager.Users.Where(u => u.Id == userId).SingleOrDefaultAsync());
        }
        public async Task<UserAC> GetUserByEmailAsync(string userEmail) {
            return _mapper.Map<UserAC>(await _userManager.Users.Where(u => u.Email == userEmail).SingleOrDefaultAsync());
        }
        public async Task<IdentityResult> RegisterUser(RegisterUserAC user) {
            var newUser = new User
            {
                UserFullName = user.UserFullName,
                Email = user.UserEmail,
                UserName = user.UserName,
            };
            var checkUser = await this._userManager.FindByEmailAsync(user.UserEmail);
            if (checkUser == null)
            {
                var result = await this._userManager.CreateAsync(newUser, user.UserPassword);
                if (result.Succeeded)
                {
                    await _context.SaveChangesAsync();
                    return result;
                }
                return result;
            }
            return null;
        }
        public async Task<IdentityResult> UpdateUser(UserAC userAC) {
            var user = await this._userManager.FindByIdAsync(userAC.Id);
            user.UserFullName = userAC.UserFullName;
            user.UserName = userAC.UserName;
            IdentityResult result = await this._userManager.UpdateAsync(user);
            return result;
        }
        public async Task DeleteUser(string userId) {
            var user = await _userManager.Users.Where(u => u.Id == userId).SingleOrDefaultAsync();
            var groupIds = _context.Groups.Where(e => e.GroupCreatorId == userId).Select(g=>g.GroupId);
            foreach(int groupId in groupIds)
            {
                await this._groupRepository.DeleteGroup(groupId);
            }
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
        }
        public bool UserExistsById(string userId) {
            return this._userManager.Users.Any(e => e.Id == userId);
        }
        public bool UserExistsByEmail(string userEmail)
        {
            return this._userManager.Users.Any(e => e.Email == userEmail);
        }

        public async Task<TokenAC> LoginUser(LoginUserAC user)
        {
            User loginuser = await _userManager.FindByEmailAsync(user.UserEmail);
            if (loginuser != null && await _userManager.CheckPasswordAsync(loginuser, user.UserPassword))
            {
                var userRoles = await _userManager.GetRolesAsync(loginuser);

                var authClaims = new List<Claim>
                {
                    new Claim("name", loginuser.UserName),
                    new Claim("userid", loginuser.Id),
                    new Claim("userFullname", loginuser.UserFullName),
                    new Claim(ClaimTypes.Name, loginuser.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim("role", userRole));
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                var tokenObject = new TokenAC();
                    tokenObject.Token = new JwtSecurityTokenHandler().WriteToken(token);
                    tokenObject.Expiration = token.ValidTo;
                return tokenObject;
            }
            return null;
        }
    }
}

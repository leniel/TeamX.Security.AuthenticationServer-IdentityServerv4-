using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using LenielMaccaferri.Security.AuthServer.Models;

namespace LenielMaccaferri.Security.AuthServer
{
    public class AuthRepository : IDisposable
    {
        private AuthContext _ctx;

        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx), null, null, null, null, null, null, null, null);
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return user;
            }

            return null;
        }

        public async Task<IList<string>> FindRoles(string user)
        {
            var u = await _userManager.FindByNameAsync(user);

            var roles = await _userManager.GetRolesAsync(u);

            return roles;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }
    }
}
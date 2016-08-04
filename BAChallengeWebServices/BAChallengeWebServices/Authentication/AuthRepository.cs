using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BAChallengeWebServices.Authentication
{
    public class AuthRepository : IDisposable
    {
        private AuthContext _authContext;
        private UserManager<IdentityUser> _userManager;
        private UserStore<IdentityUser> _userStore;

        public AuthRepository()
        {
            _authContext = new AuthContext();
            _userStore = new UserStore<IdentityUser>(_authContext);
            _userManager = new UserManager<IdentityUser>(_userStore);
        }
        public async Task<IdentityResult> RegisterUser(AdminRegistrationModel admin)
        {
            IdentityUser user = new IdentityUser()
            {
                UserName = admin.Username
            };

            var result = await _userManager.CreateAsync(user, admin.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string username, string password )
        {
            IdentityUser user = await _userManager.FindAsync(username, password);

            return user;
        }

        public async Task<bool> ChangeUserPassword(string Username, string oldPassword, string newPassword)
        {
            try
            {
                IdentityUser user = _userManager.Find(Username, oldPassword);
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(newPassword);

                await _userManager.UpdateAsync(user);

                _userStore.Context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {
            _authContext.Dispose();
        }

    }
}
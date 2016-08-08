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
    /// <summary>
    /// Class, responsible for accessing data, inside the database, setup in identity framework. 
    /// </summary>
    public class AuthRepository : IDisposable
    {
        private readonly AuthContext _authContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly UserStore<IdentityUser> _userStore;

        public AuthRepository()
        {
            _authContext = new AuthContext();
            _userStore = new UserStore<IdentityUser>(_authContext);
            _userManager = new UserManager<IdentityUser>(_userStore);
        }
        /// <summary>
        /// Register user, according to the set AdminRegistrationModel.
        /// </summary>
        /// <param name="admin">AdminRegistrationModel, which has to have username, password and confirmed passaword</param>
        /// <returns>Task of type IdentityResult</returns>
        public async Task<IdentityResult> RegisterUser(AdminRegistrationModel admin)
        {
            if (admin.Password != admin.ConfirmPassword)
                return null;

            var user = new IdentityUser()
            {
                UserName = admin.Username
            };

            var result = await _userManager.CreateAsync(user, admin.Password);

            return result;
        }

        public async Task<IdentityResult> DeleteUser(string username)
        {
            var user = await FindUser(username);

            var result = await _userManager.DeleteAsync(user);

            return result;
        }

        /// <summary>
        /// Find an registered user, with given username
        /// </summary>
        /// <param name="username">Users name</param>
        /// <returns>Identity user, that matches username</returns>
        public async Task<IdentityUser> FindUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            return user;
        }

        /// <summary>
        /// Find an registered user, with given username and password
        /// </summary>
        /// <param name="username">Users name</param>
        /// <param name="password">Users password</param>
        /// <returns>Identity user, that matches username and password</returns>
        public async Task<IdentityUser> FindUser(string username, string password )
        {
            var user = await _userManager.FindAsync(username, password);

            return user;
        }
        /// <summary>
        /// Finds an registered user by it's old password and username, then changes it's password.
        /// </summary>
        /// <param name="username">Users name</param>
        /// <param name="oldPassword">Users old password</param>
        /// <param name="newPassword">Users new password</param>
        /// <returns>True if it succeeded</returns>
        public async Task<bool> ChangeUserPassword(string username, string oldPassword, string newPassword)
        {
            try
            {
                var user = await FindUser(username, oldPassword);
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(newPassword);

                await _userManager.UpdateAsync(user);

                _userStore.Context.SaveChanges();

                return true;
            }
            catch
            { 
            }
            return false;
        }

        public void Dispose()
        {
            _authContext.Dispose();
            _userStore.Dispose();
            _userManager.Dispose();
        }

    }
}
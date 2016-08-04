using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAChallengeWebServices.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace BAChallengeWebServices.Controllers
{
    /// <summary>
    /// Controller for working with admin related information.
    /// </summary>
    public class AdminController : ApiController
    {
        private AuthRepository _authRepo;

        public AdminController()
        {
            _authRepo = new AuthRepository();
        }
        /// <summary>
        /// Creates a new admin via .../admin (POST)
        /// </summary>
        /// <param name="admin">AdminRegistrationModel, gotten from http request body.</param>
        /// <returns>IHttpActionResult</returns>
        [Authorize]
        public async Task<IHttpActionResult> Post([FromBody] AdminRegistrationModel admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            IdentityResult result = await _authRepo.RegisterUser(admin);
            IHttpActionResult errorResult = ResolveErrorMessage(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }
        /// <summary>
        /// Modifies designated admin, which is gotten from Username and oldPassword, and changes the password to newPassword. Accessed via .../admin (PUT)
        /// </summary>
        /// <param name="apcm">AdminPasswordChangeModel object, gotten from request body</param>
        /// <returns>IHttpActionResult</returns>
        [Authorize]
        public async Task<IHttpActionResult> Put([FromBody] AdminPasswordChangeModel apcm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            if (await _authRepo.ChangeUserPassword(apcm.Username, apcm.OldPassword, apcm.NewPassword))
            {
                return Ok("Password change is successful");
            }

            return BadRequest("Information does not match");  
        }
        
        [Authorize]
        public async Task<IHttpActionResult> Delete([FromBody] string username)
        {
            IHttpActionResult errorResult = ResolveErrorMessage(await _authRepo.DeleteUser(username));

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        /// <summary>
        /// Method to resolve error messages from IdentityResult
        /// </summary>
        /// <param name="result">IdentityResult object</param>
        /// <returnsIHttpActionResult></returns>
        private IHttpActionResult ResolveErrorMessage(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }
            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
                if (ModelState.IsValid)
                {
                    return BadRequest();
                }
                return BadRequest(ModelState);
            }
            return null;
        }
    }
}
using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text.RegularExpressions;
using BAChallengeWebServices.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace BAChallengeWebServices.Controllers
{
    public class AdminController : ApiController
    {
        private AuthRepository _authRepo;

        public AdminController()
        {
            _authRepo = new AuthRepository();
        }
        [Authorize]
        public async Task<IHttpActionResult> Post([FromBody] AdminModel admin)
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
        [Authorize]
        public async Task<IHttpActionResult> Put([FromBody] AdminPasswordChangeModel apcm)
        {
            if (apcm.Password == apcm.ConfirmPassword)
            {
                if (await _authRepo.ChangeUserPassword(apcm.Username, apcm.Password, apcm.NewPassword))
                {
                    return Ok("Password change is successful");
                }
            }
            return BadRequest("Passwords do not match");  
        }

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
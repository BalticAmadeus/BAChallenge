using BAChallengeWebServices.DataTransferModels;
using System.Web.Http;
using BAChallengeWebServices.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace BAChallengeWebServices.Controllers
{
    /// <summary>
    /// Controller for working with admin related information.
    /// </summary>
    [ValidateModel]
    public class AdminController : ApiController
    {
        private readonly AuthRepository _authRepo;

        public AdminController()
        {
            _authRepo = new AuthRepository();
        }
        /// <summary>
        /// Creates a new admin via .../admin (POST)
        /// </summary>
        /// <param name="admin">AdminRegistrationModel, gotten from http request body.</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [HttpPost]
        [Route("api/Admin")]
        [Authorize]
        public async Task<IHttpActionResult> Post([FromBody] AdminRegistrationModel admin)
        {
            var result = await _authRepo.RegisterUser(admin);
            var errorResult = ResolveErrorMessage(result);

            return errorResult ?? Ok();
        }
        /// <summary>
        /// Modifies designated admin, which is gotten from Username and oldPassword, and changes the password to newPassword. Accessed via .../admin (PUT)
        /// </summary>
        /// <param name="apcm">AdminPasswordChangeModel object, gotten from request body</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [HttpPut]
        [Route("api/Admin")]
        [Authorize]
        public async Task<IHttpActionResult> Put([FromBody] AdminPasswordChangeModel apcm)
        {
            if (await _authRepo.ChangeUserPassword(apcm.Username, apcm.OldPassword, apcm.NewPassword))
            {
                return Ok("Password change is successful");
            }

            return BadRequest("Information does not match");  
        }
        /// <summary>
        /// Delete request for removing admin account by username. Accessed via .../admin (DELETE)
        /// </summary>
        /// <param name="username">Username, of the account to delete</param>
        /// <returns>IHttpActionResult of OK (200) or error</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [HttpDelete]
        [Route("api/Admin")]
        [Authorize]
        public async Task<IHttpActionResult> Delete([FromBody] string username)
        {
            var errorResult = ResolveErrorMessage(await _authRepo.DeleteUser(username));

            return errorResult ?? Ok();
        }

            return Ok();
        }

        /// <summary>
        /// Method to resolve error messages from IdentityResult
        /// </summary>
        /// <param name="result">IdentityResult object</param>
        /// <returns>IHttpActionResult</returns>
        private IHttpActionResult ResolveErrorMessage(IdentityResult result)
        {
            if (result == null)
            {
                return BadRequest();
            }
            if (result.Succeeded) return null;
            if (result.Errors != null)
            {
                foreach (var error in result.Errors)
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

        protected override void Dispose(bool disposing)
        {
            _authRepo.Dispose();

            base.Dispose(disposing);
        }
    }
}
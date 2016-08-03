using BAChallengeWebServices.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BAChallengeWebServices.Controllers
{
    public class ParticipantController : ApiController
    {
        private ApplicationDBContext _dbContext;

        public ParticipantController()
        {
            _dbContext = new ApplicationDBContext();
        }
        public IHttpActionResult Get()
        {
            if (_dbContext.Participants.Count != 0)
            {
                return Ok(_dbContext.Participants);
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize]
        public IHttpActionResult Put()
        {

        }
    }
}

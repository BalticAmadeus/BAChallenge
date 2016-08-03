using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.Utility;
using BAChallengeWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BAChallengeWebServices.Controllers
{
    [AllowCrossSiteJson]
    public class ParticipantController : ApiController
    {
        private ApplicationDBContext _dbContext;

        public ParticipantController()
        {
            _dbContext = new ApplicationDBContext();
        }
        public IHttpActionResult Get()
        {
            if (_dbContext.Participants.Count() != 0)
            {
                return Ok(_dbContext.Participants);
            }
            else
            {
                return NotFound();
            }
        }

        //[Authorize]
        public IHttpActionResult Post([FromBody] Participant participant)
        {

            if (_dbContext.Participants.Where(x => x.ParticipantId == participant.ParticipantId).Count() > 0)
            {
                return BadRequest();
            }
            _dbContext.Participants.Add(participant);
            _dbContext.SaveChanges();

            return Ok();
        }

        //[Authorize]
        public IHttpActionResult Delete(int id)
        {
            var participant = _dbContext.Participants.FirstOrDefault(u => u.ParticipantId == id);
            if (participant != null)
            {
                _dbContext.Participants.Remove(participant);
                _dbContext.SaveChanges();

                return Ok();
            }

            return NotFound();
        }

        public IHttpActionResult Put(int id, [FromBody]Participant participant)
        {
            var selectedParticipant = _dbContext.Participants.FirstOrDefault(u => u.ParticipantId == id);
            if (selectedParticipant != null)
            {
                selectedParticipant.Name = participant.Name;
                selectedParticipant.Surname = participant.Surname;
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}

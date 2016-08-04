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
        /// <summary>
        /// Function retrieves all Participants and all information about them via .../participant (GET)
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Get()
        {
            if (_dbContext.Participants.Count() != 0)
            {
                var participants = new List<Participant>(_dbContext.Participants);
                return Ok(participants);
            }
            else
            {
                return NotFound();
            }
        }
        /// <summary>
        /// Function retrieves One Participant selected by id and all information about the participant. via .../participant/1 (GET)
        /// </summary>
        /// <param name="id">int gotten from http request as a integer</param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Get(int id)
        {
            if (_dbContext.Participants.Where(x => x.ParticipantId == id).Count() > 0)
            {
                return Ok(_dbContext.Participants.FirstOrDefault(x => x.ParticipantId == id));
            }

            return NotFound();
        }
        /// <summary>
        /// Function creates one participant via .../participant (POST)
        /// </summary>
        /// <param name="participant">Participant object, gotten from http request body</param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Post([FromBody] Participant participant)
        {
            if (participant != null)
            {
                if (_dbContext.Participants.Where(x => x.ParticipantId == participant.ParticipantId).Count() > 0)
                {
                    return BadRequest();
                }
                _dbContext.Participants.Add(participant);
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        /// <summary>
        /// Function creates Result and adds the result to participant using selected id via .../participant/1 (POST)
        /// </summary>
        /// <param name="id"> int, gotten from http request as a integer</param>
        /// <param name="result">Result object, gotten from http request body</param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Post(int id, [FromBody] Result result)
        {
            var selectedParticipant = _dbContext.Participants.FirstOrDefault(u => u.ParticipantId == id);
            if(selectedParticipant != null || result == null)
            {
                return BadRequest();
            }
            selectedParticipant.Results.Add(result);
            _dbContext.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Function deletes one Participants using selected Id via .../participant/1 (DELETE)
        /// </summary>
        /// <param name="id">int, gotten from http request int</param>
        /// <returns>IHttpActionResult</returns>
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
        /// <summary>
        /// Function modify one Participant and all information about him using selected Id via .../participant/1 (PUT)
        /// </summary>
        /// <param name="id">int, gotten from http integer request</param>
        /// <param name="participant">Participant object, gotten from http request body</param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Put(int id, [FromBody]Participant participant)
        {
            var selectedParticipant = _dbContext.Participants.FirstOrDefault(u => u.ParticipantId == id);
            if (selectedParticipant != null)
            {
                selectedParticipant.Firstname = participant.Firstname;
                selectedParticipant.Lastname = participant.Lastname;
                _dbContext.SaveChanges();
                return Ok();
            }             
            return BadRequest();
        }
    }
}

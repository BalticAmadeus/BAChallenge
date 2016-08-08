﻿using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.Utility;
using BAChallengeWebServices.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BAChallengeWebServices.Controllers
{
    [AllowCrossSiteJson]
    [ValidateModel]
    public class ParticipantController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public ParticipantController()
        {
            _dbContext = new ApplicationDbContext();
        }
        /// <summary>
        /// Function retrieves all Participants and all information about them via .../participant (GET)
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Get()
        {
            if (!_dbContext.Participants.Any())
            {
                return NotFound();
            }
            var participants = new List<Participant>(_dbContext.Participants);
            return Ok(participants);
        }

        /// <summary>
        /// Function retrieves One Participant selected by id and all information about the participant. via .../participant/1 (GET)
        /// </summary>
        /// <param name="id">int gotten from http request as a integer</param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Get(int id)
        {
            return _dbContext.Participants.Any(x => x.ParticipantId == id)
                ? (IHttpActionResult) Ok(_dbContext.Participants.Find(id))
                : NotFound();
        }

        /// <summary>
        /// Function creates one according to parameters set in ParticipantPostModel via .../participant (POST)
        /// </summary>
        /// <param name="participant">Participant object, gotten from http request body</param>
        /// <returns>IHttpActionResult</returns>
        [Authorize]
        public IHttpActionResult Post([FromBody] Participant participant)
        {
            if (participant == null)
            {
                return NotFound();
            }
            participant.ParticipantId = 0;
            participant.Results = new List<Result>();

            _dbContext.Participants.Add(participant);
            _dbContext.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Function deletes one Participants using selected Id via .../participant/1 (DELETE)
        /// </summary>
        /// <param name="id">int, gotten from http request int</param>
        /// <returns>IHttpActionResult</returns>
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var participant = _dbContext.Participants.Find(id);
            if (participant == null)
            {
                return NotFound();
            }
            _dbContext.Participants.Remove(participant);
            _dbContext.SaveChanges();

            return Ok();

        }

        /// <summary>
        /// Function modify participants firstname and lastname. via .../participant/1 (PUT)
        /// </summary>
        /// <param name="id">int, gotten from http integer request</param>
        /// <param name="participant">Participant object, gotten from http request body</param>
        /// <returns>IHttpActionResult</returns>
        [Authorize]
        public IHttpActionResult Put(int id, [FromBody] Participant participant)
        {
            var selectedParticipant = _dbContext.Participants.Find(id);
            if (selectedParticipant == null)
            {
                return NotFound();
            }
            selectedParticipant.FirstName = participant.FirstName;
            selectedParticipant.LastName = participant.LastName;
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
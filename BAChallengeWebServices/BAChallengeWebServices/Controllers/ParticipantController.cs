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
        //Get function retrieves all Participants and all information about them.
        //You can access this function using Url: http://localhost:5721/api/participant/
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
        //Get function retrieves One Participant selected by id and all information about the participant.
        //You can access this function using Url: http://localhost:5721/api/participant/1
        public IHttpActionResult Get(int id)
        {
            if (_dbContext.Participants.Where(x => x.ParticipantId == id).Count() > 0)
            {
                return Ok(_dbContext.Participants.FirstOrDefault(x => x.ParticipantId == id));
            }

            return NotFound();
        }

        //Post function creates one participant using Json.
        //You can access this function using Url: http://localhost:5721/api/participant/ as a Post
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
        //Post function creates Result and adds the result to participant using selected id .
        //You can access this function using Url: http://localhost:5721/api/participant/1 as a Post
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

        //Delete function deletes one Participants using selected Id.
        //You can access this function using Url: http://localhost:5721/api/participant/1 as a Delete.
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
        //Put function modify one Participant and all information about him using selected Id.
        //You can access this function using Url: http://localhost:5721/api/participant/1 as a Put.
        public IHttpActionResult Put(int id, [FromBody]Participant participant)
        {
            var selectedParticipant = _dbContext.Participants.FirstOrDefault(u => u.ParticipantId == id);
            if (selectedParticipant != null)
            {
                selectedParticipant.Name = participant.Name;
                selectedParticipant.Surname = participant.Surname;
                selectedParticipant.Results = participant.Results;
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        //public IHttpActionResult Put(int id, [FromBody]Result result)
        //{
        //    if(_dbContext.Participants.Where(u => u.ParticipantId == id).Count() > 0)
        //    {
        //        _dbContext.Participants.FirstOrDefault(u => u.ParticipantId == id).Results.Add(result);
        //        return Ok();
        //    }
        //    return BadRequest();
        //}
    }
}

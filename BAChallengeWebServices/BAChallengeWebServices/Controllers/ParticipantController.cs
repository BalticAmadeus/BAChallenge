using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.Utility;
using BAChallengeWebServices.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using BAChallengeWebServices.Repository;

namespace BAChallengeWebServices.Controllers
{
    [AllowCrossSiteJson]
    [ValidateModel]
    public class ParticipantController : ApiController
    {
        private readonly IRepository<Participant> _participantRepository;

        public ParticipantController(IRepository<Participant> participantRepository)
        {
            _participantRepository = participantRepository;
        }
        /// <summary>
        /// Function retrieves all Participants and all information about them via .../participant (GET)
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(Participant))]
        [HttpGet]
        [Route("api/Participant")]
        public IHttpActionResult Get()
        {
            var participants = _participantRepository.GetAll();
            return participants.Any()? (IHttpActionResult) Ok(participants) : NotFound();
        }

        /// <summary>
        /// Function retrieves One Participant selected by id and all information about the participant. via .../participant/1 (GET)
        /// </summary>
        /// <param name="id">int gotten from http request as a integer</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(Participant))]
        [HttpGet]
        [Route("api/Participant/{id}")]
        public IHttpActionResult Get(int id)
        {
            var participants = _participantRepository.GetById(id);
            return participants != null ? (IHttpActionResult) Ok(participants) : NotFound();
        }

        /// <summary>
        /// Function creates one according to parameters set in ParticipantPostModel via .../participant (POST)
        /// </summary>
        /// <param name="participant">Participant object, gotten from http request body</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [HttpPost]
        [Route("api/Participant")]
        [Authorize]
        public IHttpActionResult Post([FromBody] Participant participant)
        {
            bool participants = _participantRepository.Insert(participant);
            return participants ?(IHttpActionResult)Ok() : NotFound();
        }

        /// <summary>
        /// Function deletes one Participants using selected Id via .../participant/1 (DELETE)
        /// </summary>
        /// <param name="id">int, gotten from http request int</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [HttpDelete]
        [Route("api/Participant/{id}")]
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            bool participants = _participantRepository.Delete(id);
            return participants ? (IHttpActionResult) Ok() : NotFound();

        }

        /// <summary>
        /// Function modify participants firstname and lastname. via .../participant/1 (PUT)
        /// </summary>
        /// <param name="id">int, gotten from http integer request</param>
        /// <param name="participant">Participant object, gotten from http request body</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [HttpPut]
        [Route("api/Participant/{id}")]
        [Authorize]
        public IHttpActionResult Put(int id, [FromBody] Participant participant)
        {
            bool participants = _participantRepository.Modify(id, participant);
            return participants ? (IHttpActionResult) Ok() : NotFound();
        }
    }
}
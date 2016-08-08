using BAChallengeWebServices.Utility;
using BAChallengeWebServices.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using BAChallengeWebServices.DataAccess;

namespace BAChallengeWebServices.Controllers
{
    [AllowCrossSiteJson]
    [ValidateModel]
    public class ResultController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public ResultController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Function retrieves all results and all information about them via .../result (GET)
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(Result))]
        [HttpGet]
        [Route("api/Result")]
        public IHttpActionResult Get()
        {
            if (!_dbContext.Results.Any())
            {
                return NotFound();
            }
            var result = new List<Result>(_dbContext.Results);
            return Ok(result);
        }

        /// <summary>
        /// Function retrieves one result and all information about that result specified by id via .../result/1 (GET)
        /// </summary>
        /// <param name="id">int, gotten from http integer request</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(Result))]
        [HttpGet]
        [Route("api/Result/{id}")]
        public IHttpActionResult Get(int id)
        {
            if(_dbContext.Results.Any(x=>x.ResultId == id))
            {
                return NotFound();
            }
            return Ok(_dbContext.Results.Find(id));
        }

        /// <summary>
        /// Function creates one result via .../result  (POST)
        /// </summary>
        /// <param name="result">Result object, gotten from http request body</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [HttpPost]
        [Route("api/Result")]
        [Authorize]
        public IHttpActionResult Post([FromBody] Result result)
        {
            var results = new Result()
            {
                ActivityId = result.ActivityId,
                ParticipantId = result.ParticipantId,
                Points = result.Points,
                Description = result.Description,

            };

            _dbContext.Results.Add(results);
            _dbContext.SaveChanges();
            return Ok();
        }

        /// <summary>
        ///  Function deletes selected result via .../result/1 (DELETE)
        /// </summary>
        /// <param name="id">int, gotten from http integer request</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [HttpDelete]
        [Route("api/Result")]
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var result = _dbContext.Results.Find(id);
            if (result == null)
            {
                return NotFound();
            }

            _dbContext.Results.Remove(result);
            _dbContext.SaveChanges();

            return Ok();
        }

        /// <summary>
        /// Function modify one result and all information about him using selected Id via .../result/1 (PUT)
        /// </summary>
        /// <param name="id">int, gotten from http integer request</param>
        /// <param name="result">Result object, gotten from http request body</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [HttpPut]
        [Route("api/Result")]
        [Authorize]
        public IHttpActionResult Put(int id, [FromBody] Result result)
        {
            var selectedResult = _dbContext.Results.Find(id);
            if (selectedResult == null)
            {
                return NotFound();
            }
            selectedResult.ParticipantId = result.ParticipantId;
            selectedResult.Points = result.Points;
            selectedResult.Description = result.Description;
            selectedResult.ActivityId = result.ActivityId;
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}

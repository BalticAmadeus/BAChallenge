using BAChallengeWebServices.Utility;
using BAChallengeWebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAChallengeWebServices.DataAccess;

namespace BAChallengeWebServices.Controllers
{
    [AllowCrossSiteJson]
    public class ResultController : ApiController
    {
        private ApplicationDBContext _dbContext;

        public ResultController()
        {
            _dbContext = new ApplicationDBContext();
        }
        /// <summary>
        /// Function retrieves all results and all information about them via .../result (GET)
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Get()
        {
            if (_dbContext.Results.Count() != 0)
            {
                var result = new List<Result> (_dbContext.Results);
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        /// <summary>
        /// Function retrieves one result and all information about that result specified by id via .../result/1 (GET)
        /// </summary>
        /// <param name="id">int, gotten from http integer request</param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Get(int id)
        {
            if(_dbContext.Results.Where(x=>x.ResultId == id).Count() > 0)
            {
                return Ok(_dbContext.Results.Find(id));
            }
            return NotFound();
        }
        /// <summary>
        /// Function creates one result via .../result  (POST)
        /// </summary>
        /// <param name="result">Result object, gotten from http request body</param>
        /// <returns>IHttpActionResult</returns>
        [Authorize]
        public IHttpActionResult Post([FromBody] Result result)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (result != null)
            {
                Result results = new Result();
                results.ActivityId = result.ActivityId;
                results.ParticipantId = result.ParticipantId;
                results.Points = result.Points;
                results.Description = result.Description;
            
                _dbContext.Results.Add(results);
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        /// <summary>
        ///  Function deletes selected result via .../result/1 (DELETE)
        /// </summary>
        /// <param name="id">int, gotten from http integer request</param>
        /// <returns>IHttpActionResult</returns>
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var result = _dbContext.Results.Find(id);
            if (result != null)
            {
                _dbContext.Results.Remove(result);
                _dbContext.SaveChanges();

                return Ok();
            }

            return NotFound();
        }
        /// <summary>
        /// Function modify one result and all information about him using selected Id via .../result/1 (PUT)
        /// </summary>
        /// <param name="id">int, gotten from http integer request</param>
        /// <param name="result">Result object, gotten from http request body</param>
        /// <returns>IHttpActionResult</returns>
        [Authorize]
        public IHttpActionResult Put(int id,[FromBody] Result result)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var selectedResult = _dbContext.Results.Find(id);
            if (selectedResult != null)
            {
                selectedResult.ParticipantId = result.ParticipantId;
                selectedResult.Points = result.Points;
                selectedResult.Description = result.Description;
                selectedResult.ActivityId = result.ActivityId;
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}

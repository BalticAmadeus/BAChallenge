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
        //Get function retrieves one result and all information about that result specified by id.
        //You can access this function using Url: http://localhost:5721/api/result/1
        public IHttpActionResult Get(int id)
        {
            if(_dbContext.Results.Where(x=>x.ResultId == id).Count() > 0)
            {
                return Ok(_dbContext.Results.FirstOrDefault(x => x.ResultId == id));
            }
            return NotFound();
        }
        /// <summary>
        ///  Function deletes selected result via .../result/1 (DELETE)
        /// </summary>
        /// <param name="id">int, gotten from http integer request</param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Delete(int id)
        {
            var result = _dbContext.Results.FirstOrDefault(u => u.ResultId == id);
            if (result != null)
            {
                _dbContext.Results.Remove(result);
                _dbContext.SaveChanges();

                return Ok();
            }

            return NotFound();
        }
        /// <summary>
        /// Function modify selected result via .../result/1 (PUT)
        /// </summary>
        /// <param name="id">int, gotten from http requested integer</param>
        /// <param name="result">Result object, gotten from http requested body</param>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Put(int id,[FromBody]Result result)
        {
            var selectedResult = _dbContext.Results.FirstOrDefault(u => u.ResultId == id);
            if (selectedResult != null)
            {
                selectedResult.Points = result.Points;
                selectedResult.Description = result.Description;
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}

using BAChallengeWebServices.Utility;
using BAChallengeWebServices.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using BAChallengeWebServices.DataAccess;
using System.ComponentModel;
using System;
using BAChallengeWebServices.Repository;

namespace BAChallengeWebServices.Controllers
{
    [AllowCrossSiteJson]
    [ValidateModel]
    public class ResultController : ApiController
    {
        private readonly IRepository<Result> _resultRepository;

        public ResultController(IRepository<Result> resultRepository)
        {
            _resultRepository = resultRepository;
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
            var results = _resultRepository.GetAll();
            return results.Any() ? (IHttpActionResult) Ok(results) : NotFound();
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
            var results = _resultRepository.GetById(id);
            return results != null ? (IHttpActionResult) Ok(results) : NotFound();
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
            return _resultRepository.Insert(result) ? (IHttpActionResult) Ok() : BadRequest();
        }

        /// <summary>
        ///  Function deletes selected result via .../result/1 (DELETE)
        /// </summary>
        /// <param name="id">int, gotten from http integer request</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [HttpDelete]
        [Route("api/Result/{id}")]
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            return _resultRepository.Delete(id) ? (IHttpActionResult) Ok() : NotFound();
        }

        /// <summary>
        /// Function modify one result and all information about him using selected Id via .../result/1 (PUT)
        /// </summary>
        /// <param name="id">int, gotten from http integer request</param>
        /// <param name="result">Result object, gotten from http request body</param>
        /// <returns>IHttpActionResult</returns>
        [ResponseType(typeof(IHttpActionResult))]
        [HttpPut]
        [Route("api/Result/{id}")]
        [Authorize]
        public IHttpActionResult Put(int id, [FromBody] Result result)
        {
            return _resultRepository.Modify(id, result) ? (IHttpActionResult) Ok() : NotFound();
        }

        protected override void Dispose(bool disposing)
        {
            _resultRepository.Dispose();

            base.Dispose(disposing);
        }
    }
}

using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.Models;
using BAChallengeWebServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BAChallengeWebServices.Controllers
{
    public class ExceptionModelController : ApiController
    {
        private readonly IExceptionRepository<ExceptionModel> _exceptionRepository;

        public ExceptionModelController(IExceptionRepository<ExceptionModel> exceptionRepository)
        {
            _exceptionRepository = exceptionRepository;
        }
        /// <summary>
        /// Fuction retrieves all Exceptions via ../ExceptionModel (GET)
        /// </summary>
        /// <returns>IHttpActionResult</returns>
        public IHttpActionResult Get()
        {
            var exception = _exceptionRepository.GetAll();
            return exception != null ? (IHttpActionResult) Ok(exception) : NotFound();
        }
    }
}

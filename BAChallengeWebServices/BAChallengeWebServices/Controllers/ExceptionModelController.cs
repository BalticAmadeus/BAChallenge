using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.Models;
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
        private readonly ApplicationDbContext _dbContext;

        public ExceptionModelController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public IHttpActionResult Get()
        {
            if (!_dbContext.Exceptions.Any())
            {
                return NotFound();
            }
            var result = new List<ExceptionModel>(_dbContext.Exceptions);
            return Ok(result);
        }
    }
}

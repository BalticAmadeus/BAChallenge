using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BAChallengeWebServices.DataAccess;
using BAChallengeWebServices.Models;

namespace BAChallengeWebServices.Repository
{
    public class ExceptionRepository : IExceptionRepository<ExceptionModel>
    {
        private readonly ApplicationDbContext _dbContext;
        public ExceptionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<ExceptionModel> GetAll()
        {
            return _dbContext.Exceptions.ToList();
        }
    }
}
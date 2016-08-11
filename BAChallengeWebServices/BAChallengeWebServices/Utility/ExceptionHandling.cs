using BAChallengeWebServices.DataAccess;
using System;
using BAChallengeWebServices.Models;
using System.Web.Http.ExceptionHandling;

namespace BAChallengeWebServices.Utility
{
    public class ExceptionHandling : ExceptionHandler
    {
        private readonly ApplicationDbContext _dbContext;

        public ExceptionHandling()
        {
            _dbContext = new ApplicationDbContext();
        }
        /// <summary>
        /// Handles caught errors, may be used to send custom error response.
        /// </summary>
        /// <param name="context">ExceptionHandlerContext object, used to get caught Exception</param>
        public override void Handle(ExceptionHandlerContext context)
        {
            LogErrorSaveToDb(context.Exception);
            base.Handle(context);
        }
        /// <summary>
        /// Logs errors to database
        /// </summary>
        /// <param name="exception">Exception type object</param>
        public void LogErrorSaveToDb(Exception exception)
        {
            ExceptionModel exceptions = new ExceptionModel();
            exceptions.ExceptionMessage = exception.Message.ToString();
            exceptions.LogDate = DateTime.Now;
            exceptions.Source = exception.Source.ToString();
            exceptions.Trace = exception.StackTrace.ToString();
            _dbContext.Exceptions.Add(exceptions);
            _dbContext.SaveChanges();
        }
    }
}
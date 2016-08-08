using BAChallengeWebServices.DataAccess;
using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using BAChallengeWebServices.Models;

namespace BAChallengeWebServices.Utility
{
    public class ExceptionHandling
    {
        private readonly ApplicationDbContext _dbContext;

        public ExceptionHandling()
        {
            _dbContext = new ApplicationDbContext();
        }
        public void LogError(Exception exception)
        {
            ExceptionModel exceptions = new ExceptionModel();
            exceptions.ExceptionMessage = exception.Message.ToString();
            exceptions.LogDate = DateTime.Now;
            exceptions.Source = exception.Source.ToString();
            exceptions.Trace = exception.StackTrace.ToString();
            SaveErrorToDb(exceptions);
        }
        public void SaveErrorToDb (ExceptionModel exception)
        {
            _dbContext.Exceptions.Add(exception);
            _dbContext.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAChallengeWebServices.Repository
{
    public interface IExceptionRepository<T>
    {
        IList<T> GetAll();
    }
}
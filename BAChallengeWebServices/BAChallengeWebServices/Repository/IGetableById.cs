using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAChallengeWebServices.Repository
{
    public interface IGetableById<out T>
    {
        T GetById(int id);
    }
}
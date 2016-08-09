using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAChallengeWebServices.Repository
{

    public interface IActivityParticipantRepository<T>
    {
        IList<T> GetAll();
        T GetById(int id);
    }
}
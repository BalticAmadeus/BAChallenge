using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BAChallengeWebServices.Models;

namespace BAChallengeWebServices.DataTransferModels
{
    /// <summary>
    /// Model used, to generate excel file 
    /// </summary>
    public class ResultlessActivityParticipantModel
    {
        public virtual Activity Activity { get; set; }

        public virtual IList<ResultlessParticipantModel> Participants { get; set; }
    }
}
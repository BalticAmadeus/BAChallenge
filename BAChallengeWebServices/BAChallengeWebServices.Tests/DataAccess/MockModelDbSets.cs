using BAChallengeWebServices.Models;
using System.Linq;

namespace BAChallengeWebServices.Tests.DataAccess
{
    public class MockActivityDbSet : MockDbSet<Activity>
    {
        public override Activity Find(params object[] keyValues)
        {
            var id = (int)keyValues.Single();
            return this.SingleOrDefault(b => b.ActivityId == id);
        }
    }

    public class MockResultDbSet : MockDbSet<Result>
    {
        public override Result Find(params object[] keyValues)
        {
            var id = (int)keyValues.Single();
            return this.SingleOrDefault(b => b.ResultId == id);
        }
    }

    public class MockParticipantDbSet : MockDbSet<Participant>
    {
        public override Participant Find(params object[] keyValues)
        {
            var id = (int)keyValues.Single();
            return this.SingleOrDefault(b => b.ParticipantId == id);
        }
    }
    public class MockActivityParticipationDbSet : MockDbSet<ActivityParticipation>
    {
        public override ActivityParticipation Find(params object[] keyValues)
        {
            var id = (int)keyValues.Single();
            return this.SingleOrDefault(b => b.ParticipantId == id);
        }
    }
}

using BAChallengeWebServices.Models;

namespace BAChallengeWebServices.Tests.DataAccess
{
    public class MockDbContext
    {
        public MockDbContext()
        {
            ActivityParticipations = new MockActivityParticipationDbSet();
            Activities = new MockActivityDbSet();
            Participants = new MockParticipantDbSet();
            Results = new MockResultDbSet();
        }
        public MockDbSet<ActivityParticipation> ActivityParticipations;
        public MockDbSet<Activity> Activities;
        public MockDbSet<Participant> Participants;
        public MockDbSet<Result> Results;

        public int SaveChangesCounter { set; private get; }

        public int SaveChanges()
        {
            SaveChangesCounter++;
            return 1;
        }
    }
}

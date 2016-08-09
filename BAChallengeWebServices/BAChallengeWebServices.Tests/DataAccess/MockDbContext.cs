using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAChallengeWebServices.Models;

namespace BAChallengeWebServices.Tests.DataAccess
{
    public class MockDbContext
    {
        public MockDbContext()
        {
            Activities = new MockActivityDbSet();
        }

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

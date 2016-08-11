using BAChallengeWebServices.Controllers;
using BAChallengeWebServices.Models;
using BAChallengeWebServices.Tests.DataAccess;
using BAChallengeWebServices.Tests.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Http.Results;

namespace BAChallengeWebServices.Tests.Tests
{
    [TestClass]
    public class ActivityParticipantTest
    {
        [TestMethod]
        public void PostTest_MustReturnOk()
        {
            var controller = GetTestActivityParticipantController();
            ActivityParticipation postActivityParticipation = new ActivityParticipation()
            {
                ActivityParticipationId = 3,
                ActivityId = 2,
                ParticipantId = 1
            };
            var result = controller.Post(postActivityParticipation);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
        public ActivityParticipantController GetTestActivityParticipantController()
        {
            var activityParticipantRepository = new MockActivityParticipantRepository(new MockDbContext());
            activityParticipantRepository.Insert(new ActivityParticipation
            {
                ActivityParticipationId = 1,
                ActivityId = 1,
                ParticipantId = 1
            });
            activityParticipantRepository.Insert(new ActivityParticipation
            {
                ActivityParticipationId = 2,
                ActivityId = 12,
                ParticipantId = 1
            });
            var controller = new ActivityParticipantController(activityParticipantRepository);
            return controller;
        }
    }
}

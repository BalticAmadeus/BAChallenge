using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BAChallengeWebServices.Controllers;
using BAChallengeWebServices.Models;
using System.Web.Http.Results;
using BAChallengeWebServices.Tests.DataAccess;
using BAChallengeWebServices.Tests.Repository;

namespace BAChallengeWebServices.Tests
{
    [TestClass]
    public class ActivityTest
    {
        [TestMethod]
        public void GetAllTest_MustReturnAllActivities()
        {

            var controller = GetTestActivityController();

            var result = controller.Get();

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IList<Activity>>));

        }

        public ActivityController GetTestActivityController()
        {
            var activityRepository = new MockActivityRepository(new MockDbContext());
            activityRepository.Insert(new Activity
            {
                ActivityId = 1,
                Name = "We Run",
                Date = DateTime.ParseExact("2016-03-12 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-03-09 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Sports,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });

            activityRepository.Insert(new Activity
            {
                ActivityId = 2,
                Name = "Vilnius Challenge",
                Date = DateTime.ParseExact("2016-03-14 15:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-03-11 15:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Sports,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });

            var controller = new ActivityController(activityRepository);

            return controller;
        }
    }
}

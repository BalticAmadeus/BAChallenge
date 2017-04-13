using BAChallengeWebServices.Controllers;
using BAChallengeWebServices.Models;
using BAChallengeWebServices.Tests.DataAccess;
using BAChallengeWebServices.Tests.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Http.Results;

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
        [TestMethod]
        public void GetByIdTest_MustReturnOneActivity()
        {
            var controller = GetTestActivityController();

            var result = controller.Get(1);

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Activity>));
        }
        [TestMethod]
        public void GetByDateTimeTest_MustReturnAllActivitiesWithSameDate()
        {
            var controller = GetTestActivityController();

            DateTime date = DateTime.ParseExact("2016-03-12 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            var result = controller.Get(date);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IList<Activity>>));
        }
        [TestMethod]
        public void GetByLocationTest_MustReturnAllActivitiesWithSameLocation()
        {
            var controller = GetTestActivityController();
            var result = controller.Get("Vilnius");
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IList<Activity>>));
        }
        [TestMethod]
        public void GetByBranchTest_MustReturnAllActivitiesWithSameBranch()
        {
            var controller = GetTestActivityController();
            var result = controller.Get(ActivityBranch.Melyno);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IList<Activity>>));
        }
        [TestMethod]
        public void PostTest_MustReturnOk()
        {
            var controller = GetTestActivityController();
            Activity postActivity = new Activity()
            {
                ActivityId = 3,
                Name = "We Run fast",
                Date = DateTime.ParseExact("2016-03-12 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-03-09 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Melyno,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            };
            var result = controller.Post(postActivity);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
        [TestMethod]
        public void PutTest_MustReturnOk()
        {
            var controller = GetTestActivityController();
            Activity putActivity = new Activity()
            {
                ActivityId = 1,
                Name = "We Run Fast",
                Date = DateTime.ParseExact("2016-03-12 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-03-09 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Melyno,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            };
            var result = controller.Put(1,putActivity);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
        [TestMethod]
        public void DeleteTest_MustReturnOk()
        {
            var controller = GetTestActivityController();
            var result = controller.Delete(1);

            Assert.IsInstanceOfType(result, typeof(OkResult));
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
                Branch = ActivityBranch.Melyno,
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
                Branch = ActivityBranch.Melyno,
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

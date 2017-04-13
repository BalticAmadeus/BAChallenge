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
    public class ResultTest
    {
        [TestMethod]
        public void GetAllTest_MustReturnAllResults()
        {
            var controller = GetTestResultController();

            var result = controller.Get();

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IList<Result>>));
        }
        [TestMethod]
        public void GetByIdTest_MustReturnOneResult()
        {
            var controller = GetTestResultController();

            var result = controller.Get(2);

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Result>));
        }
        [TestMethod]
        public void PostTest_MustReturnOk()
        {
            var controller = GetTestResultController();
            Result postResult = new Result
            {
                ResultId = 3,
                ActivityId = 1,
                ParticipantId = 1,
                Activity = new Activity { ActivityId = 1, Name = "We Run", Date = DateTime.ParseExact("2016-03-12 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-03-09 22:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Melyno, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" },
                Points = 26,
                Description = "Gerai padirbejai super"
            };
            var result = controller.Post(postResult);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
        [TestMethod]
        public void PutTest_MustReturnOk()
        {
            var controller = GetTestResultController();
            Result putParticipant = new Result
            {
                ResultId = 1,
                ActivityId = 1,
                ParticipantId = 1,
                Activity = new Activity { ActivityId = 1, Name = "We Run", Date = DateTime.ParseExact("2016-03-12 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-03-09 22:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Melyno, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" },
                Points = 6,
                Description = "Gerai padirbejai"
            };
            var result = controller.Put(1, putParticipant);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
        [TestMethod]
        public void DeleteTest_MustReturnOk()
        {
            var controller = GetTestResultController();
            var result = controller.Delete(1);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
        public ResultController GetTestResultController()
        {
            var resultRepository = new MockResultRepository(new MockDbContext());
            resultRepository.Insert(new Result
            {
                ResultId = 1,
                ActivityId = 1,
                ParticipantId = 1,
                Activity = new Activity { ActivityId = 1, Name = "We Run", Date = DateTime.ParseExact("2016-03-12 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-03-09 22:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Melyno, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" },
                Points = 6,
                Description = "Gerai padirbejai"
            });

            resultRepository.Insert(new Result
            {
                ResultId = 2,
                ActivityId = 12,
                ParticipantId = 1,
                Activity = new Activity { ActivityId = 12, Name = "Mortal Kombat turnyras", Date = DateTime.ParseExact("2016-05-20 14:40", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-05-16 10:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Melyno, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" },
                Points = 2,
                Description = "Galėjai ir geriau"
            });
            var controller = new ResultController(resultRepository);

            return controller;
        }
    }
}

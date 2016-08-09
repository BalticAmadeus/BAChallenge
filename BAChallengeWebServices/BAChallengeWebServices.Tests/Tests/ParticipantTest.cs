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
using System.Web.Http;

namespace BAChallengeWebServices.Tests
{
    [TestClass]
    public class ParticipantTest
    {
        [TestMethod]
        public void GetAllTest_MustReturnAllParticipants()
        {

            var controller = GetTestParticipantController();

            var result = controller.Get();

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IList<Participant>>));

        }
        [TestMethod]
        public void GetByIdTest_MustReturnOneParticipant()
        {
            var controller = GetTestParticipantController();

            var result = controller.Get(1);

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<Participant>));
        }
        [TestMethod]
        public void PostTest_MustReturnOk()
        {
            var controller = GetTestParticipantController();
            Participant postParticipant = new Participant()
            {
                ParticipantId = 3,
                FirstName = "Nikolaj",
                LastName = "Anikejev",
                Results = new List<Result>
                {
                    new Result { ResultId = 1, ActivityId = 1, ParticipantId = 1, Activity = new Activity { ActivityId = 1, Name = "We Run", Date = DateTime.ParseExact("2016-03-12 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-03-09 22:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" }, Points = 6, Description = "Gerai padirbejai"},
                    new Result { ResultId = 2, ActivityId = 12, ParticipantId = 1, Activity = new Activity { ActivityId = 12, Name = "Mortal Kombat turnyras", Date = DateTime.ParseExact("2016-05-20 14:40", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-05-16 10:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Games, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" }, Points = 2, Description = "Galėjai ir geriau"}
                }
            };
            var result = controller.Post(postParticipant);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
        [TestMethod]
        public void PutTest_MustReturnOk()
        {
            var controller = GetTestParticipantController();
            Participant putParticipant = new Participant
            {
                ParticipantId = 1,
                FirstName = "Nikolajus",
                LastName = "Anikejevijus",
            };
            var result = controller.Put(1, putParticipant);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
        [TestMethod]
        public void DeleteTest_MustReturnOk()
        {
            var controller = GetTestParticipantController();
            var result = controller.Delete(1);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
        public ParticipantController GetTestParticipantController()
        {
            var participantRepository = new MockParticipantRepository(new MockDbContext());
            participantRepository.Insert(new Participant
            {
                ParticipantId = 1,
                FirstName = "Nikolaj",
                LastName = "Anikejev"
                /*Results = new List<Result>
                {
                    new Result { ResultId = 1, ActivityId = 1, ParticipantId = 1, Activity = new Activity { ActivityId = 1, Name = "We Run", Date = DateTime.ParseExact("2016-03-12 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-03-09 22:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" }, Points = 6, Description = "Gerai padirbejai"},
                    new Result { ResultId = 2, ActivityId = 12, ParticipantId = 1, Activity = new Activity { ActivityId = 12, Name = "Mortal Kombat turnyras", Date = DateTime.ParseExact("2016-05-20 14:40", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-05-16 10:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Games, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" }, Points = 2, Description = "Galėjai ir geriau"}
                }*/
            });


            participantRepository.Insert(new Participant
            {
                ParticipantId = 2,
                FirstName = "Rimvydas",
                LastName = "Aniulis"
                /*Results = new List<Result>
                {
                    new Result { ResultId = 3, ActivityId = 5, ParticipantId = 2, Activity = new Activity { ActivityId = 5, Name = "Orientacinis", Date = DateTime.ParseExact("2016-04-22 11:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-08-15 22:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" }, Points = 6, Description = "Visai neblogai"},
                    new Result { ResultId = 4, ActivityId = 6, ParticipantId = 2, Activity = new Activity { ActivityId = 6, Name = "Vilniaus Maratonas", Date = DateTime.ParseExact("2016-05-21 09:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-08-26 22:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" }, Points = 8, Description = "Nustebinai mane"}

                }*/
            });

            var controller = new ParticipantController(participantRepository);

            return controller;
        }
    }
}

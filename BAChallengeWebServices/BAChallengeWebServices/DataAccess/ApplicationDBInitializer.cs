using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BAChallengeWebServices.Models;
using System.Globalization;
using System.Threading.Tasks;
using BAChallengeWebServices.Repository;
using BAChallengeWebServices.DataTransferModels;
using System.ComponentModel;
using BAChallengeWebServices.Utility;

namespace BAChallengeWebServices.DataAccess
{
    public class ApplicationDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //Creating Identity seed

            var repository = new AuthorizationRepository();

            var task = Task.Run(async () =>
            {
                await repository.RegisterUser(new AdminRegistrationModel()
                {
                    Username = "test",
                    Password = "testPassword",
                    ConfirmPassword = "testPassword"
                });
            });

            task.Wait();


            //Activities Database
            //Sports activities
            context.Activities.Add(new Activity
            {
                ActivityId = 1,
                Name = "We Run",
                Date = DateTime.ParseExact("2016-05-22 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-05-09 22:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Sports,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });
            context.Activities.Add(new Activity
            {
                ActivityId = 2,
                Name = "Vilnius Challenge",
                Date = DateTime.ParseExact("2016-06-04 15:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-06-01 22:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Sports,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });
            context.Activities.Add(new Activity
            {
                ActivityId = 3,
                Name = "Bebro kelias",
                Date = DateTime.ParseExact("2016-08-06 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-08-01 22:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Sports,
                Description = "Blank",
                Location = "Širvintų raj.",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });
            context.Activities.Add(new Activity
            {
                ActivityId = 4,
                Name = "Velomaratonas",
                Date = DateTime.ParseExact("2016-09-11 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-08-26 22:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Sports,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });
            context.Activities.Add(new Activity
            {
                ActivityId = 5,
                Name = "Orientacinis",
                Date = DateTime.ParseExact("2016-08-22 11:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-08-15 22:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Sports,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });
            context.Activities.Add(new Activity
            {
                ActivityId = 6,
                Name = "Vilniaus Maratonas",
                Date = DateTime.ParseExact("2016-08-30 09:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-08-15 22:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Sports,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });
            //Brain activities
            context.Activities.Add(new Activity
            {
                ActivityId = 7,
                Name = "Vidinės iniciatyvos",
                Date = DateTime.ParseExact("2016-09-19 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-04-16 22:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Brain,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });
            context.Activities.Add(new Activity
            {
                ActivityId = 8,
                Name = "Švietimas",
                Date = DateTime.ParseExact("2016-08-02 10:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-03-10 12:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Brain,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });
            context.Activities.Add(new Activity
            {
                ActivityId = 9,
                Name = "Išorinis pranešimas",
                Date = DateTime.ParseExact("2016-11-21 10:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-03-15 12:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Brain,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });
            context.Activities.Add(new Activity
            {
                ActivityId = 10,
                Name = "Rašymas",
                RegistrationDate =
                    DateTime.ParseExact("2016-12-10 12:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Brain,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });
            context.Activities.Add(new Activity
            {
                ActivityId = 11,
                Name = "TechCity iniciatyvos",
                Date = DateTime.ParseExact("2016-08-02 10:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-03-10 12:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Brain,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });
            context.Activities.Add(new Activity
            {
                ActivityId = 12,
                Name = "2xBRAIN veikloje",
                Date = DateTime.ParseExact("2016-08-02 10:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-03-10 12:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Brain,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });
            //Games activities
            context.Activities.Add(new Activity
            {
                ActivityId = 13,
                Name = "Programavimo varžybos",
                Date = DateTime.ParseExact("2016-12-10 17:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-03-07 09:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Games,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });
            context.Activities.Add(new Activity
            {
                ActivityId = 14,
                Name = "Stalo žaidimų turnyras",
                Date = DateTime.ParseExact("2016-11-12 13:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-05-09 12:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Games,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });
            context.Activities.Add(new Activity
            {
                ActivityId = 15,
                Name = "Mortal Kombat turnyras",
                Date = DateTime.ParseExact("2016-09-20 14:40", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-05-16 10:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Games,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });
            context.Activities.Add(new Activity
            {
                ActivityId = 16,
                Name = "Šachmatų turnyras",
                Date = DateTime.ParseExact("2016-09-12 14:40", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-07-07 17:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Games,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });
            context.Activities.Add(new Activity
            {
                ActivityId = 17,
                Name = "Totalizatorius",
                Date = DateTime.ParseExact("2016-08-18 15:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-06-14 15:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Games,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });
            //Team activities
            context.Activities.Add(new Activity
            {
                ActivityId = 18,
                Name = "Infobalt Sąskrydis",
                Date = DateTime.ParseExact("2016-06-17 17:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-06-13 10:50", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Team,
                Description = "Blank",
                Location = "Trakų raj.",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });
            context.Activities.Add(new Activity
            {
                ActivityId = 19,
                Name = "Vandensvydis",
                Date = DateTime.ParseExact("2016-09-10 14:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-07-06 10:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Team,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });
            context.Activities.Add(new Activity
            {
                ActivityId = 20,
                Name = "Tinklinis",
                Date = DateTime.ParseExact("2016-10-02 11:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-06-28 10:50", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Team,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });
            context.Activities.Add(new Activity
            {
                ActivityId = 21,
                Name = "Dažasvydis",
                Date = DateTime.ParseExact("2016-10-11 15:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-07-08 10:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Team,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });
            context.Activities.Add(new Activity
            {
                ActivityId = 22,
                Name = "Krepšinio/futbolo turnyras",
                Date = DateTime.ParseExact("2016-10-25 14:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                RegistrationDate =
                    DateTime.ParseExact("2016-07-20 10:50", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                Branch = ActivityBranch.Team,
                Description = "Blank",
                Location = "Vilnius",
                RegistrationUrl =
                    @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing"
            });

            context.SaveChanges();

            //ActivityParticipation entries

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 1,
                ParticipantId = 1
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 12,
                ParticipantId = 1
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 5,
                ParticipantId = 2
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 6,
                ParticipantId = 2
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 17,
                ParticipantId = 3
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 16,
                ParticipantId = 3
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 10,
                ParticipantId = 3
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 2,
                ParticipantId = 4
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 3,
                ParticipantId = 4,
                Information = "Kopsiu į bebrų kalną"
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 2,
                ParticipantId = 5
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 3,
                ParticipantId = 5,
                Information = "Nekopsiu į bebrų kalną"
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 4,
                ParticipantId = 6
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 5,
                ParticipantId = 6
            });
            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 4,
                ParticipantId = 7
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 5,
                ParticipantId = 7
            });
            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 3,
                ParticipantId = 7,
                Information = "Kopsiu į bebrų kalną"
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 6,
                ParticipantId = 8
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 7,
                ParticipantId = 8
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 6,
                ParticipantId = 9
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 7,
                ParticipantId = 9
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 8,
                ParticipantId = 10
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 9,
                ParticipantId = 10
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 8,
                ParticipantId = 11
            });


            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 9,
                ParticipantId = 11
            });


            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 9,
                ParticipantId = 11
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 10,
                ParticipantId = 12
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 11,
                ParticipantId = 12
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 10,
                ParticipantId = 13
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 11,
                ParticipantId = 13
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 12,
                ParticipantId = 14
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 13,
                ParticipantId = 14
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 12,
                ParticipantId = 15
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 13,
                ParticipantId = 15
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 14,
                ParticipantId = 16
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 15,
                ParticipantId = 16
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 14,
                ParticipantId = 17
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 15,
                ParticipantId = 17
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 16,
                ParticipantId = 18
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 17,
                ParticipantId = 18
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 16,
                ParticipantId = 19
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 17,
                ParticipantId = 19
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 18,
                ParticipantId = 20
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 19,
                ParticipantId = 20
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 18,
                ParticipantId = 21
            });

            context.ActivityParticipations.Add(new ActivityParticipation()
            {
                ActivityId = 19,
                ParticipantId = 21
            });

            //Participant Database table
            context.Participants.Add(new Participant
            {
                ParticipantId = 1,
                FirstName = "Nikolaj",
                LastName = "Anikejev",
                Results = new List<Result>
                {
                    new Result { ResultId = 1, ActivityId = 1, ParticipantId = 1, Activity = context.Activities.FirstOrDefault(x => x.ActivityId ==1), Points = 8, Description = "Gerai padirbejai"},
                    new Result { ResultId = 2, ActivityId = 12, ParticipantId = 1, Activity = context.Activities.FirstOrDefault(x => x.ActivityId ==12), Points = 2, Description = "Galėjai ir geriau"},
                    new Result { ResultId = 3, ActivityId = 18, ParticipantId = 1, Activity = context.Activities.FirstOrDefault(x => x.ActivityId ==18), Points = 4, Description = "Galėjai ir geriau"}

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 2,
                FirstName = "Rimvydas",
                LastName = "Aniulis",
                Results = new List<Result>
                {
                    new Result { ResultId = 4, ActivityId = 18, ParticipantId = 2, Activity = context.Activities.FirstOrDefault(x => x.ActivityId ==18), Points = 4, Description = "Visai neblogai"},
                    new Result { ResultId = 5, ActivityId = 20, ParticipantId = 2, Activity = context.Activities.FirstOrDefault(x => x.ActivityId ==20), Points = 2, Description = "Nustebinai mane"}

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 3,
                FirstName = "Mindaugas",
                LastName = "Ardaravičius",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 4,
                FirstName = "Sandra",
                LastName = "Auzacalitaitė",
                Results = new List<Result>
                {
                    new Result { ResultId = 6, ActivityId = 1, ParticipantId = 4, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1), Points = 4, Description = "Oho?!"},
                    new Result { ResultId = 7, ActivityId = 2, ParticipantId = 4, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 2), Points = 6, Description = "Už dalyvavima"},
                    new Result { ResultId = 8, ActivityId = 3, ParticipantId = 4, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 3), Points = 6, Description = "Kodel dalyvavai?!"},
                    new Result { ResultId = 9, ActivityId = 15, ParticipantId = 4, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15), Points = 2, Description = "Kodel dalyvavai?!"},
                    new Result { ResultId = 10,ActivityId = 20, ParticipantId = 4, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 20), Points = 2, Description = "Oho?!"},

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 5,
                FirstName = "Ignas",
                LastName = "Bagdonas",
                Results = new List<Result>
                {
                    new Result { ResultId = 11, ActivityId = 8, ParticipantId = 5, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 8), Points = 6, Description = "Sveikinu pirma vieta!"},
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 6,
                FirstName = "Vitalij",
                LastName = "Bakula",
                Results = new List<Result>
                {
                    new Result { ResultId = 12, ActivityId = 1, ParticipantId = 6, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1), Points = 6, Description = "Čia pavariai"},
                    new Result { ResultId = 13, ActivityId = 2, ParticipantId = 6, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 2), Points = 8, Description = "Oho?!"},
                    new Result { ResultId = 14, ActivityId = 15, ParticipantId = 6, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15), Points = 2, Description = "Oho?!"},
                    new Result { ResultId = 15, ActivityId = 17, ParticipantId = 6, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17), Points = 2, Description = "Oho?!"},
                    new Result { ResultId = 16, ActivityId = 18, ParticipantId = 6, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18), Points = 4, Description = "Oho?!"},
                    new Result { ResultId = 17, ActivityId = 20, ParticipantId = 6, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 20), Points = 2, Description = "Oho?!"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 7,
                FirstName = "Laura",
                LastName = "Balkiūtė",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 8,
                FirstName = "Irmantas",
                LastName = "Bankauskas",
                Results = new List<Result>
                {
                    new Result { ResultId = 18, ActivityId = 1, ParticipantId = 8, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1), Points = 6, Description = "Greitai bėgai"},
                    new Result { ResultId = 19, ActivityId = 17, ParticipantId = 8, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17), Points = 2, Description = "Beast!"},
                    new Result { ResultId = 20, ActivityId = 18, ParticipantId = 8, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18), Points = 4, Description = "Beast!"},
                    new Result { ResultId = 21, ActivityId = 20, ParticipantId = 8, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 20), Points = 2, Description = "Beast!"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 9,
                FirstName = "Edvinas",
                LastName = "Baranauskas",
                Results = new List<Result>
                {
                    new Result { ResultId = 22, ActivityId = 15, ParticipantId = 9, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15), Points = 2, Description = "Visai toli nubėgai"},
                    new Result { ResultId = 23, ActivityId = 18, ParticipantId = 9, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18), Points = 4, Description = "Net nesistengei"},
                    new Result { ResultId = 24, ActivityId = 20, ParticipantId = 9, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 20), Points = 2, Description = "Net nesistengei"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 10,
                FirstName = "Vaidotas",
                LastName = "Baužys",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 11,
                FirstName = "Jaunius",
                LastName = "Belickas",
                Results = new List<Result>
                {
                    new Result { ResultId = 25, ActivityId = 1, ParticipantId = 11, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1), Points = 6, Description = "Lygiasios su pirma vieta!"},
                    new Result { ResultId = 26, ActivityId = 2, ParticipantId = 11, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 2), Points = 8, Description = "Už tai, kad nusileidai vaidotui"},
                    new Result { ResultId = 27, ActivityId = 7, ParticipantId = 11, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 7), Points = 6, Description = "Lygiasios su pirma vieta!"},
                    new Result { ResultId = 28, ActivityId = 15, ParticipantId = 11, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15), Points = 2, Description = "Lygiasios su pirma vieta!"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 12,
                FirstName = "Audrius",
                LastName = "Beniušis",
                Results = new List<Result>
                {
                    new Result { ResultId = 29, ActivityId = 17, ParticipantId = 12, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17), Points = 2, Description = "Už dalyvavimą"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 13,
                FirstName = "Nijolė",
                LastName = "Beriozovaitė-Sengupta",
                Results = new List<Result>
                {
                    new Result { ResultId = 30, ActivityId = 1, ParticipantId = 13, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1), Points = 4, Description = "Visai neblogai pavariai"},
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 14,
                FirstName = "Viktorija",
                LastName = "Bikulčiūtė",
                Results = new List<Result>
                {
                    new Result { ResultId = 31, ActivityId = 8, ParticipantId = 14, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 8), Points = 6, Description = "Buvo gražu žiūrėti"},
                    new Result { ResultId = 32, ActivityId = 17, ParticipantId = 14, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17), Points = 2, Description = "Už gražias akis"},
                    new Result { ResultId = 33, ActivityId = 18, ParticipantId = 14, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18), Points = 4, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 15,
                FirstName = "Mindaugas",
                LastName = "Bilevičius",
                Results = new List<Result>
                {
                    new Result { ResultId = 34, ActivityId = 1, ParticipantId = 15, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1), Points = 4, Description = "One man army!"},
                    new Result { ResultId = 35, ActivityId = 2, ParticipantId = 15, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 2), Points = 6, Description = "Antra vieta šešių žmonių komandoje?"},
                    new Result { ResultId = 36, ActivityId = 18, ParticipantId = 15, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18), Points = 4, Description = "One man army!"},
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 16,
                FirstName = "Justinas",
                LastName = "Bimbiris",
                Results = new List<Result>
                {
                    new Result { ResultId = 37, ActivityId = 15, ParticipantId = 16, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15), Points = 2, Description = "Už dalyvavimą"},
                    new Result { ResultId = 38, ActivityId = 17, ParticipantId = 16, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17), Points = 2, Description = "Už pastangas"},
                    new Result { ResultId = 39, ActivityId = 18, ParticipantId = 16, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18), Points = 4, Description = "Už pastangas"},
                    new Result { ResultId = 40, ActivityId = 20, ParticipantId = 16, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 20), Points = 2, Description = "Už pastangas"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 17,
                FirstName = "Artūras",
                LastName = "Birbalas",
                Results = new List<Result>
                {
                    new Result { ResultId = 41, ActivityId = 1, ParticipantId = 17, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1), Points = 6, Description = "Tik antra vienta?"},
                    new Result { ResultId = 42, ActivityId = 8, ParticipantId = 17, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 8), Points = 6, Description = "Galėjai ir geriau"},
                    new Result { ResultId = 43, ActivityId = 15, ParticipantId = 17, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15), Points = 2, Description = "Galėjai ir geriau"},
                    new Result { ResultId = 44, ActivityId = 20, ParticipantId = 17, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 20), Points = 2, Description = "Galėjai ir geriau"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 18,
                FirstName = "Agnė",
                LastName = "Buožienė",
                Results = new List<Result>
                {
                    new Result { ResultId = 45, ActivityId = 1, ParticipantId = 18, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1), Points = 4, Description = "Visai neblogai pavariai"},
                    new Result { ResultId = 46, ActivityId = 18, ParticipantId = 18, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18), Points = 4, Description = "Galėjai ir geriau"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 19,
                FirstName = "Dariuš",
                LastName = "Butkevičius",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 20,
                FirstName = "Giedrius",
                LastName = "Butkus",
                Results = new List<Result>
                {
                    new Result { ResultId = 47, ActivityId = 1, ParticipantId = 20, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1), Points = 8, Description = "Visai neblogai pavariai"},
                    new Result { ResultId = 48, ActivityId = 15, ParticipantId = 20, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15), Points = 2, Description = "Galėjai truputį geriau"},
                    new Result { ResultId = 49, ActivityId = 17, ParticipantId = 20, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17), Points = 4, Description = "Galėjai truputį geriau"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 21,
                FirstName = "Jurij",
                LastName = "Čiževskij",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 22,
                FirstName = "Oksana",
                LastName = "Cybulskaja",
                Results = new List<Result>
                {
                    new Result { ResultId = 50, ActivityId = 7, ParticipantId = 22, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 7), Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 51, ActivityId = 11, ParticipantId = 22, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 11), Points = 8, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 23,
                FirstName = "Vita",
                LastName = "Čyžiūtė",
                Results = new List<Result>
                {
                    new Result { ResultId = 52, ActivityId = 18, ParticipantId = 23, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18), Points = 2, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 24,
                FirstName = "Tomas",
                LastName = "Danilevičius",
                Results = new List<Result>
                {
                    new Result { ResultId = 53, ActivityId = 24, ParticipantId = 24, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 24), Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 54, ActivityId = 7, ParticipantId = 24, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 7), Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 55, ActivityId = 8, ParticipantId = 24, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 8), Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 56, ActivityId = 15, ParticipantId = 24, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15), Points = 2, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 25,
                FirstName = "Saulius",
                LastName = "Daraška",
                Results = new List<Result>
                {
                    new Result { ResultId = 57, ActivityId = 7, ParticipantId = 25, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 7), Points = 6, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 26,
                FirstName = "Darius",
                LastName = "Dužinskas",
                Results = new List<Result>
                {
                    new Result { ResultId = 58, ActivityId = 9, ParticipantId = 26, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 9), Points = 10, Description = "Už gražias akis"},
                    new Result { ResultId = 59, ActivityId = 12, ParticipantId = 26, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 12), Points = 10, Description = "Už gražias akis"},
                    new Result { ResultId = 60, ActivityId = 17, ParticipantId = 26, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17), Points = 2, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 27,
                FirstName = "Pior",
                LastName = "Filipovič",
                Results = new List<Result>
                {
                    new Result { ResultId = 61, ActivityId = 15, ParticipantId = 27, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15), Points = 2, Description = "Už gražias akis"},
                    new Result { ResultId = 62, ActivityId = 18, ParticipantId = 27, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18), Points = 4, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 28,
                FirstName = "Rasa",
                LastName = "Fokaitė",
                Results = new List<Result>
                {
                    new Result { ResultId = 63, ActivityId = 7, ParticipantId = 28, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 7), Points = 6, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 29,
                FirstName = "Edgaras",
                LastName = "Gajauskas",
                Results = new List<Result>
                {
                    new Result { ResultId = 64, ActivityId = 2, ParticipantId = 29, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 2), Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 65, ActivityId = 7, ParticipantId = 29, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 7), Points = 6, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 30,
                FirstName = "Mantas",
                LastName = "Galeckas",
                Results = new List<Result>
                {
                    new Result { ResultId = 66, ActivityId = 8, ParticipantId = 30, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 8), Points = 6, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 31,
                FirstName = "Mikalojus",
                LastName = "Galminas",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 32,
                FirstName = "Rimas",
                LastName = "Gataveckas",
                Results = new List<Result>
                {
                    new Result { ResultId = 67, ActivityId = 7, ParticipantId = 32, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 7), Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 68, ActivityId = 11, ParticipantId = 32, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 11), Points = 8, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 33,
                FirstName = "Mindaugas",
                LastName = "Gaurys",
                Results = new List<Result>
                {
                    new Result { ResultId = 69, ActivityId = 1, ParticipantId = 33, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1), Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 70, ActivityId = 20, ParticipantId = 33, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 20), Points = 2, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 34,
                FirstName = "Gediminas",
                LastName = "Geigalas",
                Results = new List<Result>
                {
                    new Result { ResultId = 71, ActivityId = 10, ParticipantId = 34, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 10), Points = 10, Description = "Už gražias akis"},
                    new Result { ResultId = 72, ActivityId = 15, ParticipantId = 34, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15), Points = 2, Description = "Už gražias akis"},
                    new Result { ResultId = 73, ActivityId = 17, ParticipantId = 34, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17), Points = 2, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 35,
                FirstName = "Ruslan",
                LastName = "Grumbianin",
                Results = new List<Result>
                {
                    new Result { ResultId = 74, ActivityId = 7, ParticipantId = 35, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 7), Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 75, ActivityId = 18, ParticipantId = 35, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18), Points = 2, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 36,
                FirstName = "Tomas",
                LastName = "Jakovlevas",
                Results = new List<Result>
                {
                    new Result { ResultId = 76, ActivityId = 1, ParticipantId = 36, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1), Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 77, ActivityId = 2, ParticipantId = 36, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 2), Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 78, ActivityId = 15, ParticipantId = 36, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15), Points = 4, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 37,
                FirstName = "Ignas",
                LastName = "Janickas",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 38,
                FirstName = "Agnė",
                LastName = "Juknaitė",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 39,
                FirstName = "Džiugas",
                LastName = "Juozapaitis",
                Results = new List<Result>
                {
                    new Result { ResultId = 79, ActivityId = 1, ParticipantId = 39, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1), Points = 10, Description = "Už gražias akis"},
                    new Result { ResultId = 80, ActivityId = 3, ParticipantId = 39, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 3), Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 81, ActivityId = 18, ParticipantId = 39, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18), Points = 2, Description = "Už gražias akis"},
                    new Result { ResultId = 82, ActivityId = 20, ParticipantId = 39, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 20), Points = 2, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 40,
                FirstName = "Justinas",
                LastName = "Kameneckas",
                Results = new List<Result>
                {
                    new Result { ResultId = 83, ActivityId = 1, ParticipantId = 40, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1), Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 84, ActivityId = 2, ParticipantId = 40, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 2), Points = 8, Description = "Už gražias akis"},
                    new Result { ResultId = 85, ActivityId = 7, ParticipantId = 40, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 7), Points = 6, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 41,
                FirstName = "Vytautas",
                LastName = "Kaminskas",
                Results = new List<Result>
                {
                    new Result { ResultId = 86, ActivityId = 1, ParticipantId = 41, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1), Points = 8, Description = "Už gražias akis"},
                    new Result { ResultId = 87, ActivityId = 2, ParticipantId = 41, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 2), Points = 8, Description = "Už gražias akis"},
                    new Result { ResultId = 88, ActivityId = 3, ParticipantId = 41, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 3), Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 89, ActivityId = 7, ParticipantId = 41, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 7), Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 90, ActivityId = 9, ParticipantId = 41, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 9), Points = 10, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 42,
                FirstName = "Brigita",
                LastName = "Karpenkaitė",
                Results = new List<Result>
                {
                    new Result { ResultId = 91, ActivityId = 17, ParticipantId = 42, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17), Points = 2, Description = "Už gražias akis"},
                    new Result { ResultId = 92, ActivityId = 18, ParticipantId = 42, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18), Points = 2, Description = "Už gražias akis"},
                    new Result { ResultId = 93, ActivityId = 20, ParticipantId = 42, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 20), Points = 2, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 43,
                FirstName = "Regina",
                LastName = "Kartanaitė",
                Results = new List<Result>
                {
                    new Result { ResultId = 94, ActivityId = 1, ParticipantId = 43, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1), Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 95, ActivityId = 2, ParticipantId = 43, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 2), Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 96, ActivityId = 18, ParticipantId = 43, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18), Points = 4, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 44,
                FirstName = "Diana",
                LastName = "Kasinskaja",
                Results = new List<Result>
                {
                    new Result { ResultId = 97, ActivityId = 17, ParticipantId = 44, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17), Points = 2, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 45,
                FirstName = "Šarūnas",
                LastName = "Kasnauskas",
                Results = new List<Result>
                {
                    new Result { ResultId = 98, ActivityId = 17, ParticipantId = 45, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17), Points = 2, Description = "Už gražias akis"},
                    new Result { ResultId = 99, ActivityId = 18, ParticipantId = 45, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18), Points = 4, Description = "Už gražias akis"},
                    new Result { ResultId = 100, ActivityId = 20, ParticipantId = 45, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 20), Points = 4, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 46,
                FirstName = "Linas Antanas",
                LastName = "Kavaliauskas",
                Results = new List<Result>
                {
                    new Result { ResultId = 101, ActivityId = 1, ParticipantId = 46, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1), Points = 4, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 47,
                FirstName = "Vitalis",
                LastName = "Kavaliauskas",
                Results = new List<Result>
                {
                    new Result { ResultId = 102, ActivityId = 7, ParticipantId = 47, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 7), Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 103, ActivityId = 15, ParticipantId = 47, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15), Points = 2, Description = "Už gražias akis"}
                }
            });

            context.Participants.Add(new Participant
            {
                ParticipantId = 48,
                FirstName = "Antanas",
                LastName = "Kompanas",
                Results = new List<Result>()
                {
                    new Result
                    {
                        ActivityId = 7,
                        ParticipantId = 48,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 7),
                        Points = 6,
                        Description = "neblogai"
                    }
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 49,
                FirstName = "Aleksandr",
                LastName = "Korabliov",
                Results = new List<Result>()
                {
                    new Result
                    {
                        ActivityId = 7,
                        ParticipantId = 49,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 7),
                        Points = 6,
                        Description = "neblogai"
                    },
                    new Result
                    {
                        ActivityId = 15,
                        ParticipantId = 49,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15),
                        Points = 2,
                        Description = "neblogai"
                    },

                }
            });

            context.Participants.Add(new Participant
            {
                ParticipantId = 50,
                FirstName = "Sergejus",
                LastName = "Kornejevas",
                Results = new List<Result>()
                {

                    new Result
                    {
                        ActivityId = 17,
                        ParticipantId = 50,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17),
                        Points = 2,
                        Description = "neblogai"
                    },
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 51,
                FirstName = "Mindaugas",
                LastName = "Kruopis",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 52,
                FirstName = "Andžej",
                LastName = "Kulakovski",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 53,
                FirstName = "Donatas",
                LastName = "Kurapkis",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 54,
                FirstName = "Alius",
                LastName = "Kveinys",
                Results = new List<Result>()
                {
                    new Result
                    {
                        ActivityId = 7,
                        ParticipantId = 54,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 7),
                        Points = 6,
                        Description = "neblogai"
                    },
                    new Result
                    {
                        ActivityId = 11,
                        ParticipantId = 54,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 11),
                        Points = 8,
                        Description = "neblogai"
                    },
                    new Result
                    {
                        ActivityId = 12,
                        ParticipantId = 54,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 12),
                        Points = 6,
                        Description = "neblogai"
                    },
                    new Result
                    {
                        ActivityId = 15,
                        ParticipantId = 54,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15),
                        Points = 4,
                        Description = "neblogai"
                    },
                    new Result
                    {
                        ActivityId = 17,
                        ParticipantId = 54,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17),
                        Points = 2,
                        Description = "neblogai"
                    },
                    new Result
                    {
                        ActivityId = 18,
                        ParticipantId = 54,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18),
                        Points = 4,
                        Description = "neblogai"
                    },
                    new Result
                    {
                        ActivityId = 20,
                        ParticipantId = 54,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 20),
                        Points = 4,
                        Description = "neblogai"
                    },
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 55,
                FirstName = "Gvidas",
                LastName = "Labanauskas",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 56,
                FirstName = "Titas",
                LastName = "Lapinskas",
                Results = new List<Result>()
                {
                    new Result()
                    {
                        ActivityId = 1,
                        ParticipantId = 56,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1),
                        Points = 6,
                        Description = "neblogai"
                    }
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 57,
                FirstName = "Andžej",
                LastName = "Leonovič",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 58,
                FirstName = "Pavel",
                LastName = "Liminovič",
                Results = new List<Result>()
                { 
                    new Result()
                    {
                        ActivityId = 15,
                        ParticipantId = 58,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15),
                        Points = 2,
                        Description = "neblogai"
                    },
                    new Result()
                    {
                        ActivityId = 17,
                        ParticipantId = 58,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17),
                        Points = 2,
                        Description = "neblogai"
                    }
}
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 59,
                FirstName = "Donatas",
                LastName = "Lomsargis",
                Results = new List<Result>()
                {
                    new Result
                    {
                        ActivityId = 1,
                        ParticipantId = 59,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1),
                        Points = 8,
                        Description = "neblogai"
                    },
                    new Result
                    {
                        ActivityId = 2,
                        ParticipantId = 59,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 2),
                        Points = 6,
                        Description = "neblogai"
                    },
                    new Result
                    {
                        ActivityId = 3,
                        ParticipantId = 59,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 3),
                        Points = 8,
                        Description = "neblogai"
                    },
                    new Result
                    {
                        ActivityId = 20,
                        ParticipantId = 59,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 20),
                        Points = 2,
                        Description = "neblogai"
                    },
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 60,
                FirstName = "Mantas",
                LastName = "Lunys",
                Results = new List<Result>()
                {
                    new Result
                    {
                        ActivityId = 17,
                        ParticipantId = 60,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17),
                        Points = 2,
                        Description = "neblogai"
                    },

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 61,
                FirstName = "Gediminas",
                LastName = "Markevičius",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 62,
                FirstName = "Vaida",
                LastName = "Medvedevienė",
                Results = new List<Result>()
                {
                     new Result
                    {
                        ActivityId = 1,
                        ParticipantId = 62,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1),
                        Points = 4,
                        Description = "neblogai"
                    },
                }
            });

            context.Participants.Add(new Participant
            {
                ParticipantId = 63,
                FirstName = "Vytautas",
                LastName = "Meškuotis",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 64,
                FirstName = "Danutė",
                LastName = "Miskivė",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 65,
                FirstName = "Kęstas",
                LastName = "Narkūnas",
                Results = new List<Result>()
                {
                     new Result
                    {
                        ActivityId = 15,
                        ParticipantId = 65,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15),
                        Points = 2,
                        Description = "neblogai"
                    },
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 66,
                FirstName = "Justina",
                LastName = "Narkutė",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 67,
                FirstName = "Dainius",
                LastName = "Neverbickas",
                Results = new List<Result>()
                {
                     new Result
                    {
                        ActivityId = 1,
                        ParticipantId = 67,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1),
                        Points = 8,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 3,
                        ParticipantId = 67,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 3),
                        Points = 8,
                        Description = "neblogai"
                    },
                       new Result
                    {
                        ActivityId = 15,
                        ParticipantId = 67,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15),
                        Points = 2,
                        Description = "neblogai"
                    },
                        new Result
                    {
                        ActivityId = 18,
                        ParticipantId = 67,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18),
                        Points = 4,
                        Description = "neblogai"
                    },
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 68,
                FirstName = "Mantvydas",
                LastName = "Ozerenskis",
                Results = new List<Result>()
                {
                     new Result
                    {
                        ActivityId = 2,
                        ParticipantId = 68,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 2),
                        Points = 6,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 15,
                        ParticipantId = 68,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15),
                        Points = 2,
                        Description = "neblogai"
                    },
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 69,
                FirstName = "Artūras",
                LastName = "Pečeliūnas",
                Results = new List<Result>()
                {
                     new Result
                    {
                        ActivityId = 7,
                        ParticipantId = 69,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 7),
                        Points = 6,
                        Description = "neblogai"
                    },
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 70,
                FirstName = "Karolis",
                LastName = "Pikelis",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 71,
                FirstName = "Šarūnas",
                LastName = "Pikelis",
                Results = new List<Result>()
                {
                     new Result
                    {
                        ActivityId = 15,
                        ParticipantId = 70,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15),
                        Points = 2,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 18,
                        ParticipantId = 70,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18),
                        Points = 2,
                        Description = "neblogai"
                    },
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 72,
                FirstName = "Indrė",
                LastName = "Pinkevičiūtė",
                Results = new List<Result>()
                {
                      new Result
                    {
                        ActivityId = 1,
                        ParticipantId = 72,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1),
                        Points = 8,
                        Description = "neblogai"
                    },

                      new Result
                    {
                        ActivityId = 2,
                        ParticipantId = 72,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 2),
                        Points = 6,
                        Description = "neblogai"
                    },

                      new Result
                    {
                        ActivityId = 3,
                        ParticipantId = 72,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 3),
                        Points = 6,
                        Description = "neblogai"
                    },

                      new Result
                    {
                        ActivityId = 15,
                        ParticipantId = 72,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15),
                        Points = 2,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 17,
                        ParticipantId = 72,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17),
                        Points = 2,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 18,
                        ParticipantId = 72,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18),
                        Points = 4,
                        Description = "neblogai"
                    },

                      new Result
                    {
                        ActivityId = 20,
                        ParticipantId = 72,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 20),
                        Points = 2,
                        Description = "neblogai"
                    },
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 73,
                FirstName = "Jevgenij",
                LastName = "Pletniov",
                Results = new List<Result>()
                {

                      new Result
                    {
                        ActivityId = 1,
                        ParticipantId = 73,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1),
                        Points = 4,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 17,
                        ParticipantId = 73,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17),
                        Points = 2,
                        Description = "neblogai"
                    },
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 74,
                FirstName = "Justas",
                LastName = "Poliakas",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 75,
                FirstName = "Robert",
                LastName = "Požarickij",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 76,
                FirstName = "Anton",
                LastName = "Rodevič",
                Results = new List<Result>()
                {

                      new Result
                    {
                        ActivityId = 15,
                        ParticipantId = 76,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15),
                        Points = 2,
                        Description = "neblogai"
                    },
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 77,
                FirstName = "Marius",
                LastName = "Šaučiūnas",
                Results = new List<Result>()
                {

                      new Result
                    {
                        ActivityId = 1,
                        ParticipantId = 77,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1),
                        Points = 4,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 7,
                        ParticipantId = 77,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 7),
                        Points = 6,
                        Description = "neblogai"
                    },
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 78,
                FirstName = "Tadas",
                LastName = "Ščerbickas",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 79,
                FirstName = "Armandas",
                LastName = "Šiušė",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 80,
                FirstName = "Artūras",
                LastName = "Šliažas",
                Results = new List<Result>()
                {
                      new Result
                    {
                        ActivityId = 1,
                        ParticipantId = 80,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1),
                        Points = 8,
                        Description = "neblogai"
                    },

                      new Result
                    {
                        ActivityId = 17,
                        ParticipantId = 80,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17),
                        Points = 2,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 20,
                        ParticipantId = 80,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 20),
                        Points = 2,
                        Description = "neblogai"
                    },
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 81,
                FirstName = "Saulius",
                LastName = "Soltonis",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 82,
                FirstName = "Mantas",
                LastName = "Stasytis",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 83,
                FirstName = "Laisvis",
                LastName = "Stonys",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 84,
                FirstName = "Regimantas",
                LastName = "Strielčiūnas",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 85,
                FirstName = "Aleksandr",
                LastName = "Suchovarov",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 86,
                FirstName = "Lina",
                LastName = "Šukevičiūtė",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 87,
                FirstName = "Edvinas",
                LastName = "Šulcas",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 88,
                FirstName =  "Tamara",
                LastName = "Surudo",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 89,
                FirstName = "Anželika",
                LastName = "Survilienė",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 90,
                FirstName = "Andžej",
                LastName = "Šuškevič",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 91,
                FirstName = "Liubov",
                LastName = "Sverdan",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 92,
                FirstName = "Jūratė",
                LastName = "Talmontienė",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 93,
                FirstName = "Alvydas",
                LastName = "Tamašauskas",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 94,
                FirstName = "Kristijonas",
                LastName = "Telksnys",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 95,
                FirstName = "Paulius",
                LastName = "Tuzikas",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 96,
                FirstName = "Angelė",
                LastName = "Urbonavičiūtė",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 97,
                FirstName = "Arnas",
                LastName = "Vaičekauskas",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 98,
                FirstName = "Aurelija",
                LastName = "Valentinavičiūtė",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 99,
                FirstName = "Andrej",
                LastName = "Verchovych",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 100,
                FirstName = "Kazimežas",
                LastName = "Verobejus",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 101,
                FirstName = "Jurga",
                LastName = "Vestertė",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 102,
                FirstName = "Daiva",
                LastName = "Vikmonienė",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 103,
                FirstName = "Nerijus",
                LastName = "Vilūnas",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 104,
                FirstName = "Aleksandras",
                LastName = "Voitechovskis",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 105,
                FirstName = "Raimundas",
                LastName = "Voveris",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 106,
                FirstName = "Justinas",
                LastName = "Zableckis",
                Results = new List<Result>()
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 107,
                FirstName = "Vidmantas",
                LastName = "Žilius",
                Results = new List<Result>()
            });
            
            base.Seed(context);
        }
    }
}
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
                    new Result { ResultId = 6, ActivityId = 1, ParticipantId = 4,   Points = 4, Description = "Oho?!"},
                    new Result { ResultId = 7, ActivityId = 2, ParticipantId = 4,   Points = 6, Description = "Už dalyvavima"},
                    new Result { ResultId = 8, ActivityId = 3, ParticipantId = 4,   Points = 6, Description = "Kodel dalyvavai?!"},
                    new Result { ResultId = 9, ActivityId = 15, ParticipantId = 4,   Points = 2, Description = "Kodel dalyvavai?!"},
                    new Result { ResultId = 10,ActivityId = 20, ParticipantId = 4,   Points = 2, Description = "Oho?!"},

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 5,
                FirstName = "Ignas",
                LastName = "Bagdonas",
                Results = new List<Result>
                {
                    new Result { ResultId = 11, ActivityId = 8, ParticipantId = 5,   Points = 6, Description = "Sveikinu pirma vieta!"},
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 6,
                FirstName = "Vitalij",
                LastName = "Bakula",
                Results = new List<Result>
                {
                    new Result { ResultId = 12, ActivityId = 1, ParticipantId = 6,   Points = 6, Description = "Čia pavariai"},
                    new Result { ResultId = 13, ActivityId = 2, ParticipantId = 6,   Points = 8, Description = "Oho?!"},
                    new Result { ResultId = 14, ActivityId = 15, ParticipantId = 6,   Points = 2, Description = "Oho?!"},
                    new Result { ResultId = 15, ActivityId = 17, ParticipantId = 6,   Points = 2, Description = "Oho?!"},
                    new Result { ResultId = 16, ActivityId = 18, ParticipantId = 6,   Points = 4, Description = "Oho?!"},
                    new Result { ResultId = 17, ActivityId = 20, ParticipantId = 6,   Points = 2, Description = "Oho?!"}
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
                    new Result { ResultId = 18, ActivityId = 1, ParticipantId = 8,   Points = 6, Description = "Greitai bėgai"},
                    new Result { ResultId = 19, ActivityId = 17, ParticipantId = 8,   Points = 2, Description = "Beast!"},
                    new Result { ResultId = 20, ActivityId = 18, ParticipantId = 8,   Points = 4, Description = "Beast!"},
                    new Result { ResultId = 21, ActivityId = 20, ParticipantId = 8,   Points = 2, Description = "Beast!"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 9,
                FirstName = "Edvinas",
                LastName = "Baranauskas",
                Results = new List<Result>
                {
                    new Result { ResultId = 22, ActivityId = 15, ParticipantId = 9,   Points = 2, Description = "Visai toli nubėgai"},
                    new Result { ResultId = 23, ActivityId = 18, ParticipantId = 9,   Points = 4, Description = "Net nesistengei"},
                    new Result { ResultId = 24, ActivityId = 20, ParticipantId = 9,   Points = 2, Description = "Net nesistengei"}
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
                    new Result { ResultId = 25, ActivityId = 1, ParticipantId = 11,   Points = 6, Description = "Lygiasios su pirma vieta!"},
                    new Result { ResultId = 26, ActivityId = 2, ParticipantId = 11,   Points = 8, Description = "Už tai, kad nusileidai vaidotui"},
                    new Result { ResultId = 27, ActivityId = 7, ParticipantId = 11,   Points = 6, Description = "Lygiasios su pirma vieta!"},
                    new Result { ResultId = 28, ActivityId = 15, ParticipantId = 11,   Points = 2, Description = "Lygiasios su pirma vieta!"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 12,
                FirstName = "Audrius",
                LastName = "Beniušis",
                Results = new List<Result>
                {
                    new Result { ResultId = 29, ActivityId = 17, ParticipantId = 12,   Points = 2, Description = "Už dalyvavimą"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 13,
                FirstName = "Nijolė",
                LastName = "Beriozovaitė-Sengupta",
                Results = new List<Result>
                {
                    new Result { ResultId = 30, ActivityId = 1, ParticipantId = 13,   Points = 4, Description = "Visai neblogai pavariai"},
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 14,
                FirstName = "Viktorija",
                LastName = "Bikulčiūtė",
                Results = new List<Result>
                {
                    new Result { ResultId = 31, ActivityId = 8, ParticipantId = 14,   Points = 6, Description = "Buvo gražu žiūrėti"},
                    new Result { ResultId = 32, ActivityId = 17, ParticipantId = 14,   Points = 2, Description = "Už gražias akis"},
                    new Result { ResultId = 33, ActivityId = 18, ParticipantId = 14,   Points = 4, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 15,
                FirstName = "Mindaugas",
                LastName = "Bilevičius",
                Results = new List<Result>
                {
                    new Result { ResultId = 34, ActivityId = 1, ParticipantId = 15,   Points = 4, Description = "One man army!"},
                    new Result { ResultId = 35, ActivityId = 2, ParticipantId = 15,   Points = 6, Description = "Antra vieta šešių žmonių komandoje?"},
                    new Result { ResultId = 36, ActivityId = 18, ParticipantId = 15,   Points = 4, Description = "One man army!"},
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 16,
                FirstName = "Justinas",
                LastName = "Bimbiris",
                Results = new List<Result>
                {
                    new Result { ResultId = 37, ActivityId = 15, ParticipantId = 16,   Points = 2, Description = "Už dalyvavimą"},
                    new Result { ResultId = 38, ActivityId = 17, ParticipantId = 16,   Points = 2, Description = "Už pastangas"},
                    new Result { ResultId = 39, ActivityId = 18, ParticipantId = 16,   Points = 4, Description = "Už pastangas"},
                    new Result { ResultId = 40, ActivityId = 20, ParticipantId = 16,   Points = 2, Description = "Už pastangas"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 17,
                FirstName = "Artūras",
                LastName = "Birbalas",
                Results = new List<Result>
                {
                    new Result { ResultId = 41, ActivityId = 1, ParticipantId = 17,   Points = 6, Description = "Tik antra vienta?"},
                    new Result { ResultId = 42, ActivityId = 8, ParticipantId = 17,   Points = 6, Description = "Galėjai ir geriau"},
                    new Result { ResultId = 43, ActivityId = 15, ParticipantId = 17,   Points = 2, Description = "Galėjai ir geriau"},
                    new Result { ResultId = 44, ActivityId = 20, ParticipantId = 17,   Points = 2, Description = "Galėjai ir geriau"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 18,
                FirstName = "Agnė",
                LastName = "Buožienė",
                Results = new List<Result>
                {
                    new Result { ResultId = 45, ActivityId = 1, ParticipantId = 18,   Points = 4, Description = "Visai neblogai pavariai"},
                    new Result { ResultId = 46, ActivityId = 18, ParticipantId = 18,   Points = 4, Description = "Galėjai ir geriau"}
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
                    new Result { ResultId = 47, ActivityId = 1, ParticipantId = 20,   Points = 8, Description = "Visai neblogai pavariai"},
                    new Result { ResultId = 48, ActivityId = 15, ParticipantId = 20,   Points = 2, Description = "Galėjai truputį geriau"},
                    new Result { ResultId = 49, ActivityId = 17, ParticipantId = 20,   Points = 4, Description = "Galėjai truputį geriau"}
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
                    new Result { ResultId = 50, ActivityId = 7, ParticipantId = 22,   Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 51, ActivityId = 11, ParticipantId = 22,   Points = 8, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 23,
                FirstName = "Vita",
                LastName = "Čyžiūtė",
                Results = new List<Result>
                {
                    new Result { ResultId = 52, ActivityId = 18, ParticipantId = 23,   Points = 2, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 24,
                FirstName = "Tomas",
                LastName = "Danilevičius",
                Results = new List<Result>
                {
                    new Result { ResultId = 53, ActivityId = 24, ParticipantId = 24,   Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 54, ActivityId = 7, ParticipantId = 24,   Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 55, ActivityId = 8, ParticipantId = 24,   Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 56, ActivityId = 15, ParticipantId = 24,   Points = 2, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 25,
                FirstName = "Saulius",
                LastName = "Daraška",
                Results = new List<Result>
                {
                    new Result { ResultId = 57, ActivityId = 7, ParticipantId = 25,   Points = 6, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 26,
                FirstName = "Darius",
                LastName = "Dužinskas",
                Results = new List<Result>
                {
                    new Result { ResultId = 58, ActivityId = 9, ParticipantId = 26,   Points = 10, Description = "Už gražias akis"},
                    new Result { ResultId = 59, ActivityId = 12, ParticipantId = 26,   Points = 10, Description = "Už gražias akis"},
                    new Result { ResultId = 60, ActivityId = 17, ParticipantId = 26,   Points = 2, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 27,
                FirstName = "Pior",
                LastName = "Filipovič",
                Results = new List<Result>
                {
                    new Result { ResultId = 61, ActivityId = 15, ParticipantId = 27,   Points = 2, Description = "Už gražias akis"},
                    new Result { ResultId = 62, ActivityId = 18, ParticipantId = 27,   Points = 4, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 28,
                FirstName = "Rasa",
                LastName = "Fokaitė",
                Results = new List<Result>
                {
                    new Result { ResultId = 63, ActivityId = 7, ParticipantId = 28,   Points = 6, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 29,
                FirstName = "Edgaras",
                LastName = "Gajauskas",
                Results = new List<Result>
                {
                    new Result { ResultId = 64, ActivityId = 2, ParticipantId = 29,   Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 65, ActivityId = 7, ParticipantId = 29,   Points = 6, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 30,
                FirstName = "Mantas",
                LastName = "Galeckas",
                Results = new List<Result>
                {
                    new Result { ResultId = 66, ActivityId = 8, ParticipantId = 30,   Points = 6, Description = "Už gražias akis"}
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
                    new Result { ResultId = 67, ActivityId = 7, ParticipantId = 32,   Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 68, ActivityId = 11, ParticipantId = 32,   Points = 8, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 33,
                FirstName = "Mindaugas",
                LastName = "Gaurys",
                Results = new List<Result>
                {
                    new Result { ResultId = 69, ActivityId = 1, ParticipantId = 33,   Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 70, ActivityId = 20, ParticipantId = 33,   Points = 2, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 34,
                FirstName = "Gediminas",
                LastName = "Geigalas",
                Results = new List<Result>
                {
                    new Result { ResultId = 71, ActivityId = 10, ParticipantId = 34,   Points = 10, Description = "Už gražias akis"},
                    new Result { ResultId = 72, ActivityId = 15, ParticipantId = 34,   Points = 2, Description = "Už gražias akis"},
                    new Result { ResultId = 73, ActivityId = 17, ParticipantId = 34,   Points = 2, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 35,
                FirstName = "Ruslan",
                LastName = "Grumbianin",
                Results = new List<Result>
                {
                    new Result { ResultId = 74, ActivityId = 7, ParticipantId = 35,   Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 75, ActivityId = 18, ParticipantId = 35,   Points = 2, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 36,
                FirstName = "Tomas",
                LastName = "Jakovlevas",
                Results = new List<Result>
                {
                    new Result { ResultId = 76, ActivityId = 1, ParticipantId = 36,   Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 77, ActivityId = 2, ParticipantId = 36,   Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 78, ActivityId = 15, ParticipantId = 36,   Points = 4, Description = "Už gražias akis"}
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
                    new Result { ResultId = 79, ActivityId = 1, ParticipantId = 39,   Points = 10, Description = "Už gražias akis"},
                    new Result { ResultId = 80, ActivityId = 3, ParticipantId = 39,   Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 81, ActivityId = 18, ParticipantId = 39,   Points = 2, Description = "Už gražias akis"},
                    new Result { ResultId = 82, ActivityId = 20, ParticipantId = 39,   Points = 2, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 40,
                FirstName = "Justinas",
                LastName = "Kameneckas",
                Results = new List<Result>
                {
                    new Result { ResultId = 83, ActivityId = 1, ParticipantId = 40,   Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 84, ActivityId = 2, ParticipantId = 40,   Points = 8, Description = "Už gražias akis"},
                    new Result { ResultId = 85, ActivityId = 7, ParticipantId = 40,   Points = 6, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 41,
                FirstName = "Vytautas",
                LastName = "Kaminskas",
                Results = new List<Result>
                {
                    new Result { ResultId = 86, ActivityId = 1, ParticipantId = 41,   Points = 8, Description = "Už gražias akis"},
                    new Result { ResultId = 87, ActivityId = 2, ParticipantId = 41,   Points = 8, Description = "Už gražias akis"},
                    new Result { ResultId = 88, ActivityId = 3, ParticipantId = 41,   Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 89, ActivityId = 7, ParticipantId = 41,   Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 90, ActivityId = 9, ParticipantId = 41,   Points = 10, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 42,
                FirstName = "Brigita",
                LastName = "Karpenkaitė",
                Results = new List<Result>
                {
                    new Result { ResultId = 91, ActivityId = 17, ParticipantId = 42,   Points = 2, Description = "Už gražias akis"},
                    new Result { ResultId = 92, ActivityId = 18, ParticipantId = 42,   Points = 2, Description = "Už gražias akis"},
                    new Result { ResultId = 93, ActivityId = 20, ParticipantId = 42,   Points = 2, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 43,
                FirstName = "Regina",
                LastName = "Kartanaitė",
                Results = new List<Result>
                {
                    new Result { ResultId = 94, ActivityId = 1, ParticipantId = 43,   Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 95, ActivityId = 2, ParticipantId = 43,   Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 96, ActivityId = 18, ParticipantId = 43,   Points = 4, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 44,
                FirstName = "Diana",
                LastName = "Kasinskaja",
                Results = new List<Result>
                {
                    new Result { ResultId = 97, ActivityId = 17, ParticipantId = 44,   Points = 2, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 45,
                FirstName = "Šarūnas",
                LastName = "Kasnauskas",
                Results = new List<Result>
                {
                    new Result { ResultId = 98, ActivityId = 17, ParticipantId = 45,   Points = 2, Description = "Už gražias akis"},
                    new Result { ResultId = 99, ActivityId = 18, ParticipantId = 45,   Points = 4, Description = "Už gražias akis"},
                    new Result { ResultId = 100, ActivityId = 20, ParticipantId = 45,   Points = 4, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 46,
                FirstName = "Linas Antanas",
                LastName = "Kavaliauskas",
                Results = new List<Result>
                {
                    new Result { ResultId = 101, ActivityId = 1, ParticipantId = 46,   Points = 4, Description = "Už gražias akis"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 47,
                FirstName = "Vitalis",
                LastName = "Kavaliauskas",
                Results = new List<Result>
                {
                    new Result { ResultId = 102, ActivityId = 7, ParticipantId = 47,   Points = 6, Description = "Už gražias akis"},
                    new Result { ResultId = 103, ActivityId = 15, ParticipantId = 47,   Points = 2, Description = "Už gražias akis"}
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
                         
                        Points = 6,
                        Description = "neblogai"
                    },
                    new Result
                    {
                        ActivityId = 15,
                        ParticipantId = 49,
                         
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
                         
                        Points = 6,
                        Description = "neblogai"
                    },
                    new Result
                    {
                        ActivityId = 11,
                        ParticipantId = 54,
                         
                        Points = 8,
                        Description = "neblogai"
                    },
                    new Result
                    {
                        ActivityId = 12,
                        ParticipantId = 54,
                         
                        Points = 6,
                        Description = "neblogai"
                    },
                    new Result
                    {
                        ActivityId = 15,
                        ParticipantId = 54,
                         
                        Points = 4,
                        Description = "neblogai"
                    },
                    new Result
                    {
                        ActivityId = 17,
                        ParticipantId = 54,
                         
                        Points = 2,
                        Description = "neblogai"
                    },
                    new Result
                    {
                        ActivityId = 18,
                        ParticipantId = 54,
                         
                        Points = 4,
                        Description = "neblogai"
                    },
                    new Result
                    {
                        ActivityId = 20,
                        ParticipantId = 54,
                         
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
                         
                        Points = 2,
                        Description = "neblogai"
                    },
                    new Result()
                    {
                        ActivityId = 17,
                        ParticipantId = 58,
                         
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
                         
                        Points = 8,
                        Description = "neblogai"
                    },
                    new Result
                    {
                        ActivityId = 2,
                        ParticipantId = 59,
                         
                        Points = 6,
                        Description = "neblogai"
                    },
                    new Result
                    {
                        ActivityId = 3,
                        ParticipantId = 59,
                         
                        Points = 8,
                        Description = "neblogai"
                    },
                    new Result
                    {
                        ActivityId = 20,
                        ParticipantId = 59,
                         
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
                         
                        Points = 8,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 3,
                        ParticipantId = 67,
                         
                        Points = 8,
                        Description = "neblogai"
                    },
                       new Result
                    {
                        ActivityId = 15,
                        ParticipantId = 67,
                         
                        Points = 2,
                        Description = "neblogai"
                    },
                        new Result
                    {
                        ActivityId = 18,
                        ParticipantId = 67,
                         
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
                         
                        Points = 6,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 15,
                        ParticipantId = 68,
                         
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
                         
                        Points = 2,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 18,
                        ParticipantId = 70,
                         
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
                         
                        Points = 8,
                        Description = "neblogai"
                    },

                      new Result
                    {
                        ActivityId = 2,
                        ParticipantId = 72,
                         
                        Points = 6,
                        Description = "neblogai"
                    },

                      new Result
                    {
                        ActivityId = 3,
                        ParticipantId = 72,
                         
                        Points = 6,
                        Description = "neblogai"
                    },

                      new Result
                    {
                        ActivityId = 15,
                        ParticipantId = 72,
                         
                        Points = 2,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 17,
                        ParticipantId = 72,
                         
                        Points = 2,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 18,
                        ParticipantId = 72,
                         
                        Points = 4,
                        Description = "neblogai"
                    },

                      new Result
                    {
                        ActivityId = 20,
                        ParticipantId = 72,
                         
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
                         
                        Points = 4,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 17,
                        ParticipantId = 73,
                         
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
                         
                        Points = 4,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 7,
                        ParticipantId = 77,
                         
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
                         
                        Points = 8,
                        Description = "neblogai"
                    },

                      new Result
                    {
                        ActivityId = 17,
                        ParticipantId = 80,
                         
                        Points = 2,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 20,
                        ParticipantId = 80,
                         
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
                {

                      new Result
                    {
                        ActivityId = 17,
                        ParticipantId = 81,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17),
                        Points = 2,
                        Description = "neblogai"
                    },
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 82,
                FirstName = "Mantas",
                LastName = "Stasytis",
                Results = new List<Result>()
                {
                      new Result
                    {
                        ActivityId = 1,
                        ParticipantId = 82,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1),
                        Points = 6,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 2,
                        ParticipantId = 82,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 2),
                        Points = 6,
                        Description = "neblogai"
                    },

                      new Result
                    {
                        ActivityId = 3,
                        ParticipantId = 82,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 3),
                        Points = 6,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 15,
                        ParticipantId = 82,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15),
                        Points = 2,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 17,
                        ParticipantId = 82,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17),
                        Points = 2,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 18,
                        ParticipantId = 82,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18),
                        Points = 4,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 20,
                        ParticipantId = 82,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 20),
                        Points = 2,
                        Description = "neblogai"
                    },
                }
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
                {

                      new Result
                    {
                        ActivityId = 1,
                        ParticipantId = 85,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1),
                        Points = 8,
                        Description = "neblogai"
                    },
                }
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
                {

                      new Result
                    {
                        ActivityId = 1,
                        ParticipantId = 87,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1),
                        Points = 6,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 2,
                        ParticipantId = 87,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 2),
                        Points = 6,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 3,
                        ParticipantId = 87,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 3),
                        Points = 6,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 15,
                        ParticipantId = 87,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15),
                        Points = 4,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 20,
                        ParticipantId = 87,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 20),
                        Points = 4,
                        Description = "neblogai"
                    },
                }
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
                {

                      new Result
                    {
                        ActivityId = 1,
                        ParticipantId = 90,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 1),
                        Points = 10,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 2,
                        ParticipantId = 90,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 2),
                        Points = 10,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 8,
                        ParticipantId = 90,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 8),
                        Points = 6,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 12,
                        ParticipantId = 90,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 12),
                        Points = 6,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 15,
                        ParticipantId = 90,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15),
                        Points = 2,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 17,
                        ParticipantId = 90,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17),
                        Points = 2,
                        Description = "neblogai"
                    },
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 91,
                FirstName = "Liubov",
                LastName = "Sverdan",
                Results = new List<Result>()
                {

                      new Result
                    {
                        ActivityId = 18,
                        ParticipantId = 91,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18),
                        Points = 4,
                        Description = "neblogai"
                    },
                }
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
                {

                      new Result
                    {
                        ActivityId = 8,
                        ParticipantId = 94,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 8),
                        Points = 6,
                        Description = "neblogai"
                    },
                      new Result
                    {
                        ActivityId = 18,
                        ParticipantId = 94,
                        Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18),
                        Points = 4,
                        Description = "neblogai"
                    },
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 95,
                FirstName = "Paulius",
                LastName = "Tuzikas",
                Results = new List<Result>
                {
                    new Result { ActivityId = 15, ParticipantId = 95,   Points = 2, Description = "Čia pavariai"},
                    new Result { ActivityId = 17, ParticipantId = 95,   Points = 2, Description = "Oho?!"},
                    new Result { ActivityId = 18, ParticipantId = 95,   Points = 4, Description = "Čia pavariai"},
                    new Result { ActivityId = 20, ParticipantId = 95,   Points = 4, Description = "Oho?!"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 96,
                FirstName = "Angelė",
                LastName = "Urbonavičiūtė",
                Results = new List<Result>
                {
                    new Result { ActivityId = 3, ParticipantId = 96,   Points = 6, Description = "Čia pavariai"},
                    new Result { ActivityId = 17, ParticipantId = 96,   Points = 4, Description = "Oho?!"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 97,
                FirstName = "Arnas",
                LastName = "Vaičekauskas",
                Results = new List<Result>
                {
                    new Result { ActivityId = 18, ParticipantId = 97,   Points = 2, Description = "Oho?!"}
                }
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
                Results = new List<Result>
                {
                    new Result { ActivityId = 17, ParticipantId = 102,   Points = 2, Description = "Čia pavariai"},
                    new Result { ActivityId = 18, ParticipantId = 102,   Points = 4, Description = "Oho?!"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 103,
                FirstName = "Nerijus",
                LastName = "Vilūnas",
                Results = new List<Result>
                {
                    new Result { ActivityId = 1, ParticipantId = 103,   Points = 6, Description = "Čia pavariai"},
                    new Result { ActivityId = 2, ParticipantId = 103,   Points = 6, Description = "Oho?!"},
                    new Result { ActivityId = 17, ParticipantId = 103,   Points = 2, Description = "Čia pavariai"},
                    new Result { ActivityId = 18, ParticipantId = 103,   Points = 4, Description = "Oho?!"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 104,
                FirstName = "Aleksandras",
                LastName = "Voitechovskis",
                Results = new List<Result>
                {
                    new Result { ActivityId = 1, ParticipantId = 104,   Points = 4, Description = "Čia pavariai"},
                    new Result { ActivityId = 15, ParticipantId = 104,   Points = 2, Description = "Oho?!"},
                    new Result { ActivityId = 17, ParticipantId = 104,   Points = 2, Description = "Čia pavariai"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 105,
                FirstName = "Raimundas",
                LastName = "Voveris",
                Results = new List<Result>
                {
                    new Result { ActivityId = 1, ParticipantId = 105,   Points = 10, Description = "Čia pavariai"},
                    new Result { ActivityId = 2, ParticipantId = 105,   Points = 10, Description = "Oho?!"},
                    new Result { ActivityId = 3, ParticipantId = 105,   Points = 8, Description = "Čia pavariai"},
                    new Result { ActivityId = 17, ParticipantId = 105,   Points = 2, Description = "Oho?!"},
                    new Result { ActivityId = 18, ParticipantId = 105,   Points = 4, Description = "Oho?!"}
                }
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
                Results = new List<Result>
                {
                    new Result { ActivityId = 17, ParticipantId = 107,   Points = 2, Description = "Čia pavariai"},
                    new Result { ActivityId = 18, ParticipantId = 107,   Points = 4, Description = "Oho?!"}

                }
            });
            
            base.Seed(context);
        }

        private static void AddActivityParticipations(ApplicationDbContext context)
        {
            var activityParticipations = new List<Tuple<int, int, string>>()
            {
                new Tuple<int, int, string>(1, 1, null),
                new Tuple<int, int, string>(1, 4, null),
                new Tuple<int, int, string>(1, 6, null),
                new Tuple<int, int, string>(1, 8, null),
                new Tuple<int, int, string>(1, 11, null),
                new Tuple<int, int, string>(1, 13, null),
                new Tuple<int, int, string>(1, 15, null),
                new Tuple<int, int, string>(1, 17, null),
                new Tuple<int, int, string>(1, 18, null),
                new Tuple<int, int, string>(1, 20, null),
                new Tuple<int, int, string>(1, 33, null),
                new Tuple<int, int, string>(1, 36, null),
                new Tuple<int, int, string>(1, 39, null),
                new Tuple<int, int, string>(1, 40, null),
                new Tuple<int, int, string>(1, 41, null),
                new Tuple<int, int, string>(1, 43, null),
                new Tuple<int, int, string>(1, 46, null),
                new Tuple<int, int, string>(1, 56, null),
                new Tuple<int, int, string>(1, 59, null),
                new Tuple<int, int, string>(1, 62, null),
                new Tuple<int, int, string>(1, 67, null),
                new Tuple<int, int, string>(1, 72, null),
                new Tuple<int, int, string>(1, 73, null),
                new Tuple<int, int, string>(1, 77, null),
                new Tuple<int, int, string>(1, 80, null),
                new Tuple<int, int, string>(1, 82, null),
                new Tuple<int, int, string>(1, 85, null),
                new Tuple<int, int, string>(1, 87, null),
                new Tuple<int, int, string>(1, 90, null),
                new Tuple<int, int, string>(1, 103, null),
                new Tuple<int, int, string>(1, 104, null),
                new Tuple<int, int, string>(1, 105, null),
                new Tuple<int, int, string>(2, 4, null),
                new Tuple<int, int, string>(2, 6, null),
                new Tuple<int, int, string>(2, 11, null),
                new Tuple<int, int, string>(2, 15, null),
                new Tuple<int, int, string>(2, 24, null),
                new Tuple<int, int, string>(2, 29, null),
                new Tuple<int, int, string>(2, 36, null),
                new Tuple<int, int, string>(2, 40, null),
                new Tuple<int, int, string>(2, 41, null),
                new Tuple<int, int, string>(2, 43, null),
                new Tuple<int, int, string>(2, 59, null),
                new Tuple<int, int, string>(2, 68, null),
                new Tuple<int, int, string>(2, 72, null),
                new Tuple<int, int, string>(2, 82, null),
                new Tuple<int, int, string>(2, 87, null),
                new Tuple<int, int, string>(2, 90, null),
                new Tuple<int, int, string>(2, 103, null),
                new Tuple<int, int, string>(2, 105, null),
                new Tuple<int, int, string>(3, 4, null),
                new Tuple<int, int, string>(3, 39, null),
                new Tuple<int, int, string>(3, 41, null),
                new Tuple<int, int, string>(3, 59, null),
                new Tuple<int, int, string>(3, 67, null),
                new Tuple<int, int, string>(3, 72, null),
                new Tuple<int, int, string>(3, 82, null),
                new Tuple<int, int, string>(3, 87, null),
                new Tuple<int, int, string>(3, 96, null),
                new Tuple<int, int, string>(3, 105, null),
                new Tuple<int, int, string>(7, 11, null),
                new Tuple<int, int, string>(7, 22, null),
                new Tuple<int, int, string>(7, 24, null),
                new Tuple<int, int, string>(7, 25, null),
                new Tuple<int, int, string>(7, 28, null),
                new Tuple<int, int, string>(7, 29, null),
                new Tuple<int, int, string>(7, 32, null),
                new Tuple<int, int, string>(7, 35, null),
                new Tuple<int, int, string>(7, 40, null),
                new Tuple<int, int, string>(7, 41, null),
                new Tuple<int, int, string>(7, 47, null),
                new Tuple<int, int, string>(7, 48, null),
                new Tuple<int, int, string>(7, 49, null),
                new Tuple<int, int, string>(7, 54, null),
                new Tuple<int, int, string>(7, 69, null),
                new Tuple<int, int, string>(7, 77, null),
                new Tuple<int, int, string>(7, 11, null),
                new Tuple<int, int, string>(8, 5, null),
                new Tuple<int, int, string>(8, 15, null),
                new Tuple<int, int, string>(8, 17, null),
                new Tuple<int, int, string>(8, 24, null),
                new Tuple<int, int, string>(8, 30, null),
                new Tuple<int, int, string>(8, 5, null),
                new Tuple<int, int, string>(8, 92, null),
                new Tuple<int, int, string>(8, 96, null),
                new Tuple<int, int, string>(9, 26, null),
                new Tuple<int, int, string>(9, 41, null),
                new Tuple<int, int, string>(10, 34, null),
                new Tuple<int, int, string>(11, 22, null),
                new Tuple<int, int, string>(11, 32, null),
                new Tuple<int, int, string>(11, 54, null),
                new Tuple<int, int, string>(12, 28, null),
                new Tuple<int, int, string>(12, 54, null),
                new Tuple<int, int, string>(11, 90, null),
                new Tuple<int, int, string>(15, 1, null),
                new Tuple<int, int, string>(15, 4, null),
                new Tuple<int, int, string>(15, 6, null),
                new Tuple<int, int, string>(15, 9, null),
                new Tuple<int, int, string>(15, 11, null),
                new Tuple<int, int, string>(15, 16, null),
                new Tuple<int, int, string>(15, 17, null),
                new Tuple<int, int, string>(15, 20, null),
                new Tuple<int, int, string>(15, 24, null),
                new Tuple<int, int, string>(15, 27, null),
                new Tuple<int, int, string>(15, 34, null),
                new Tuple<int, int, string>(15, 36, null),
                new Tuple<int, int, string>(15, 41, null),
                new Tuple<int, int, string>(15, 47, null),
                new Tuple<int, int, string>(15, 49, null),
                new Tuple<int, int, string>(15, 54, null),
                new Tuple<int, int, string>(15, 58, null),
                new Tuple<int, int, string>(15, 65, null),
                new Tuple<int, int, string>(15, 67, null),
                new Tuple<int, int, string>(15, 68, null),
                new Tuple<int, int, string>(15, 71, null),
                new Tuple<int, int, string>(15, 72, null),
                new Tuple<int, int, string>(15, 76, null),
                new Tuple<int, int, string>(15, 82, null),
                new Tuple<int, int, string>(15, 87, null),
                new Tuple<int, int, string>(15, 90, null),
                new Tuple<int, int, string>(15, 95, null),
                new Tuple<int, int, string>(15, 104, null),
                new Tuple<int, int, string>(17, 6, null),
                new Tuple<int, int, string>(17, 8, null),
                new Tuple<int, int, string>(17, 12, null),
                new Tuple<int, int, string>(17, 14, null),
                new Tuple<int, int, string>(17, 16, null),
                new Tuple<int, int, string>(17, 20, null),
                new Tuple<int, int, string>(17, 22, null),
                new Tuple<int, int, string>(17, 26, null),
                new Tuple<int, int, string>(17, 34, null),
                new Tuple<int, int, string>(17, 42, null),
                new Tuple<int, int, string>(17, 44, null),
                new Tuple<int, int, string>(17, 45, null),
                new Tuple<int, int, string>(17, 50, null),
                new Tuple<int, int, string>(17, 54, null),
                new Tuple<int, int, string>(17, 58, null),
                new Tuple<int, int, string>(17, 60, null),
                new Tuple<int, int, string>(17, 72, null),
                new Tuple<int, int, string>(17, 73, null),
                new Tuple<int, int, string>(17, 79, null),
                new Tuple<int, int, string>(17, 80, null),
                new Tuple<int, int, string>(17, 81, null),
                new Tuple<int, int, string>(17, 82, null),
                new Tuple<int, int, string>(17, 90, null),
                new Tuple<int, int, string>(17, 102, null),
                new Tuple<int, int, string>(17, 103, null),
                new Tuple<int, int, string>(17, 104, null),
                new Tuple<int, int, string>(17, 105, null),
                new Tuple<int, int, string>(17, 109, null),
                new Tuple<int, int, string>(18, 1, null),
                new Tuple<int, int, string>(18, 2, null),
                new Tuple<int, int, string>(18, 6, null),
                new Tuple<int, int, string>(18, 8, null),
                new Tuple<int, int, string>(18, 9, null),
                new Tuple<int, int, string>(18, 14, null),
                new Tuple<int, int, string>(18, 15, null),
                new Tuple<int, int, string>(18, 16, null),
                new Tuple<int, int, string>(18, 18, null),
                new Tuple<int, int, string>(18, 23, null),
                new Tuple<int, int, string>(18, 35, null),
                new Tuple<int, int, string>(18, 39, null),
                new Tuple<int, int, string>(18, 42, null),
                new Tuple<int, int, string>(18, 43, null),
                new Tuple<int, int, string>(18, 45, null),
                new Tuple<int, int, string>(18, 54, null),
                new Tuple<int, int, string>(18, 67, null),
                new Tuple<int, int, string>(18, 71, null),
                new Tuple<int, int, string>(18, 72, null),
                new Tuple<int, int, string>(18, 82, null),
                new Tuple<int, int, string>(18, 91, null),
                new Tuple<int, int, string>(18, 94, null),
                new Tuple<int, int, string>(18, 95, null),
                new Tuple<int, int, string>(18, 96, null),
                new Tuple<int, int, string>(18, 97, null),
                new Tuple<int, int, string>(18, 102, null),
                new Tuple<int, int, string>(18, 103, null),
                new Tuple<int, int, string>(18, 105, null),
                new Tuple<int, int, string>(18, 107, null),
                new Tuple<int, int, string>(20, 2, null),
                new Tuple<int, int, string>(20, 4, null),
                new Tuple<int, int, string>(20, 6, null),
                new Tuple<int, int, string>(20, 8, null),
                new Tuple<int, int, string>(20, 9, null),
                new Tuple<int, int, string>(20, 16, null),
                new Tuple<int, int, string>(20, 17, null),
                new Tuple<int, int, string>(20, 33, null),
                new Tuple<int, int, string>(20, 39, null),
                new Tuple<int, int, string>(20, 42, null),
                new Tuple<int, int, string>(20, 45, null),
                new Tuple<int, int, string>(20, 54, null),
                new Tuple<int, int, string>(20, 59, null),
                new Tuple<int, int, string>(20, 72, null),
                new Tuple<int, int, string>(20, 80, null),
                new Tuple<int, int, string>(20, 82, null),
                new Tuple<int, int, string>(20, 87, null),
                new Tuple<int, int, string>(20, 95, null),
                new Tuple<int, int, string>(4, 105, "50 km (Semi-Sport)"),
                new Tuple<int, int, string>(4, 41, "30 km (Mėgėjų grupė)"),
                new Tuple<int, int, string>(4, 81, "30 km (Mėgėjų grupė)"),
                new Tuple<int, int, string>(4, 82, "30 km (Mėgėjų grupė)"),
                new Tuple<int, int, string>(4, 56, "30 km (Mėgėjų grupė)"),
                new Tuple<int, int, string>(4, 16, "50 km (Semi-Sport)"),
                new Tuple<int, int, string>(4, 96, "30 km (Mėgėjų grupė)"),
                new Tuple<int, int, string>(6, 87, "10 km"),
                new Tuple<int, int, string>(6, 41, "21 km. 98 m."),
                new Tuple<int, int, string>(6, 105, "42 km. 195 m. Dydis M"),
                new Tuple<int, int, string>(6, 17, "10 km"),
                new Tuple<int, int, string>(6, 103, "10 km"),
                new Tuple<int, int, string>(6, 82, "4 km. 200 m."),
                new Tuple<int, int, string>(6, 24, "21 km. 98 m."),
                new Tuple<int, int, string>(6, 81, "10 km"),
                new Tuple<int, int, string>(6, 33, "42 km. 195 m. Dydis XL"),
                new Tuple<int, int, string>(6, 104, "4 km. 200 m."),
                new Tuple<int, int, string>(6, 39, "42 km. 195 m. Dydis M"),
                new Tuple<int, int, string>(6, 59, "21 km. 98 m."),
                new Tuple<int, int, string>(6, 96, "21 km. 98 m."),
                new Tuple<int, int, string>(6, 4, "4 km. 200 m."),
                new Tuple<int, int, string>(6, 45, "4 km. 200 m."),
                new Tuple<int, int, string>(6, 1, "42 km. 195 m. Dydis L"),
                new Tuple<int, int, string>(6, 77, "4 km. 200 m."),
                new Tuple<int, int, string>(6, 40, "21 km. 98 m."),
                new Tuple<int, int, string>(5, 105, null),
                new Tuple<int, int, string>(5, 74, null),
                new Tuple<int, int, string>(5, 72, null),
                new Tuple<int, int, string>(5, 4, null),
                new Tuple<int, int, string>(5, 87, null),
                new Tuple<int, int, string>(5, 39, null),
                new Tuple<int, int, string>(5, 41, null),
                new Tuple<int, int, string>(5, 105, null),
                new Tuple<int, int, string>(5, 45, null),
                new Tuple<int, int, string>(5, 1, null),
                new Tuple<int, int, string>(5, 82, null),
                new Tuple<int, int, string>(5, 40, null)
            };

            foreach (var row in activityParticipations)
            {
                context.ActivityParticipations.Add(new ActivityParticipation()
                {
                    ActivityId = row.Item1,
                    ParticipantId = row.Item2,
                    Information = row.Item3
                });
            }

            context.SaveChanges();
        }

    }
}
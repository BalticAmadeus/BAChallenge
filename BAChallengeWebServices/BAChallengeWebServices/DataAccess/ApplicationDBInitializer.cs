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
            context.Activities.Add(new Activity { ActivityId = 1, Name = "We Run", Date = DateTime.ParseExact("2016-03-12 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-03-09 22:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 2, Name = "Vilnius Challenge", Date = DateTime.ParseExact("2016-03-14 15:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-03-11 22:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 3, Name = "Bebro kelias", Date = DateTime.ParseExact("2016-04-14 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-07-08 22:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Description = "Blank", Location = "Širvintų raj.", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 4, Name = "Velomaratonas", Date = DateTime.ParseExact("2016-04-19 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-08-10 22:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 5, Name = "Orientacinis", Date = DateTime.ParseExact("2016-04-22 11:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-08-15 22:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 6, Name = "Vilniaus Maratonas", Date = DateTime.ParseExact("2016-05-21 09:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-08-26 22:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            //Brain activities
            context.Activities.Add(new Activity { ActivityId = 8, Name = "Paskaita (Švietimas)", Date = DateTime.ParseExact("2016-03-14 10:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-03-10 12:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Brain, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 9, Name = "Paskaita (Išorinis pranešimas)", Date = DateTime.ParseExact("2016-03-19 10:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-03-15 12:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Brain, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            //Games activities
            context.Activities.Add(new Activity { ActivityId = 10, Name = "Programavimo varžybos", Date = DateTime.ParseExact("2016-03-10 17:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-03-07 09:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Games, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 11, Name = "Stalo žaidimų turnyras", Date = DateTime.ParseExact("2016-05-12 13:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-05-09 12:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Games, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 12, Name = "Mortal Kombat turnyras", Date = DateTime.ParseExact("2016-05-20 14:40", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-05-16 10:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Games, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 13, Name = "Šachmatų turnyras", Date = DateTime.ParseExact("2016-07-12 14:40", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-07-07 17:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Games, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 14, Name = "Totalizatorius", Date = DateTime.ParseExact("2016-06-18 15:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-06-14 15:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Games, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            //Team activities
            context.Activities.Add(new Activity { ActivityId = 15, Name = "Infobalt Sąskrydis", Date = DateTime.ParseExact("2016-07-18 12:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-07-13 10:50", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Team, Description = "Blank", Location = "Trakų raj.", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 16, Name = "Vandensvydis", Date = DateTime.ParseExact("2016-07-10 14:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-07-06 10:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Team, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 17, Name = "Tinklinis", Date = DateTime.ParseExact("2016-07-02 11:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-06-28 10:50", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Team, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 18, Name = "Dažasvydis", Date = DateTime.ParseExact("2016-07-11 15:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-07-08 10:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Team, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 19, Name = "Krepšinio/futbolo turnyras", Date = DateTime.ParseExact("2016-07-25 14:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-07-20 10:50", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Team, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });

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
                    new Result { ResultId = 1, ActivityId = 1, ParticipantId = 1, Activity = context.Activities.FirstOrDefault(x => x.ActivityId ==1), Points = 6, Description = "Gerai padirbejai"},
                    new Result { ResultId = 2, ActivityId = 12, ParticipantId = 1, Activity = context.Activities.FirstOrDefault(x => x.ActivityId ==12), Points = 2, Description = "Galėjai ir geriau"}
                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 2,
                FirstName = "Rimvydas",
                LastName = "Aniulis",
                Results = new List<Result>
                {
                    new Result { ResultId = 3, ActivityId = 5, ParticipantId = 2, Activity = context.Activities.FirstOrDefault(x => x.ActivityId ==5), Points = 6, Description = "Visai neblogai"},
                    new Result { ResultId = 4, ActivityId = 6, ParticipantId = 2, Activity = context.Activities.FirstOrDefault(x => x.ActivityId ==6), Points = 8, Description = "Nustebinai mane"}

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 3,
                FirstName = "Mindaugas",
                LastName = "Ardaravičius",
                Results = new List<Result>
                {
                    new Result { ResultId = 5, ActivityId = 16, ParticipantId = 3, Activity = context.Activities.FirstOrDefault(x => x.ActivityId ==16), Points = 0, Description = "Kodel nedalyvavai?!"},
                    new Result { ResultId = 6, ActivityId = 17, ParticipantId = 3, Activity = context.Activities.FirstOrDefault(x => x.ActivityId ==17), Points = 8, Description = "Už dalyvavima"}

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 4,
                FirstName = "Sandra",
                LastName = "Auzacalitaitė",
                Results = new List<Result>
                {
                    new Result { ResultId = 7, ActivityId = 2, ParticipantId = 4, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 2), Points = 2, Description = "Kodel dalyvavai?!"},
                    new Result { ResultId = 8, ActivityId = 3, ParticipantId = 4, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 3), Points = 6, Description = "Už nedalyvavima"}

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 5,
                FirstName = "Ignas",
                LastName = "Bagdonas",
                Results = new List<Result>
                {
                    new Result { ResultId = 9, ActivityId = 2, ParticipantId = 5, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 2), Points = 6, Description = "Sveikinu pirma vieta!"},
                    new Result { ResultId = 10, ActivityId = 3, ParticipantId = 5, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 3), Points = 5, Description = "Už nedalyvavima"}

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 6,
                FirstName = "Vitalij",
                LastName = "Bakula",
                Results = new List<Result>
                {
                    new Result { ResultId = 11, ActivityId = 4, ParticipantId = 6, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 4), Points = 8, Description = "Čia pavariai"},
                    new Result { ResultId = 12, ActivityId = 5, ParticipantId = 6, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 5), Points = 0, Description = "Kodel nedalyvavai?!"}

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 7,
                FirstName = "Laura",
                LastName = "Balkiūtė",
                Results = new List<Result>
                {
                    new Result { ResultId = 13, ActivityId = 4, ParticipantId = 7, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 4), Points = 6, Description = "Visai neblogai pavariai"},
                    new Result { ResultId = 14, ActivityId = 5, ParticipantId = 7, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 5), Points = 4, Description = "Galėjai ir geriau"}

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 8,
                FirstName = "Irmantas",
                LastName = "Bankauskas",
                Results = new List<Result>
                {
                    new Result { ResultId = 15, ActivityId = 6, ParticipantId = 8, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 6), Points = 6, Description = "Greitai bėgai"},
                    new Result { ResultId = 16, ActivityId = 7, ParticipantId = 8, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 7), Points = 12, Description = "Beast!"}

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 9,
                FirstName = "Edvinas",
                LastName = "Baranauskas",
                Results = new List<Result>
                {
                    new Result { ResultId = 17, ActivityId = 6, ParticipantId = 9, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 6), Points = 6, Description = "Visai toli nubėgai"},
                    new Result { ResultId = 18, ActivityId = 7, ParticipantId = 9, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 7), Points = 4, Description = "Net nesistengei"}

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 10,
                FirstName = "Vaidotas",
                LastName = "Baužys",
                Results = new List<Result>
                {
                    new Result { ResultId = 19, ActivityId = 8, ParticipantId = 10, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 8), Points = 2, Description = "Už nelabai gražias akis"},
                    new Result { ResultId = 20, ActivityId = 9, ParticipantId = 10, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 9), Points = 4, Description = "Nuostabų rezultatą pasiekei"}

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 11,
                FirstName = "Jaunius",
                LastName = "Belickas",
                Results = new List<Result>
                {
                    new Result { ResultId = 21, ActivityId = 8, ParticipantId = 11, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 8), Points = 5, Description = "Lygiasios su pirma vieta!"},
                    new Result { ResultId = 22, ActivityId = 9, ParticipantId = 11, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 9), Points = 1, Description = "Už tai, kad nusileidai vaidotui"}

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 12,
                FirstName = "Audrius",
                LastName = "Beniušis",
                Results = new List<Result>
                {
                    new Result { ResultId = 23, ActivityId = 10, ParticipantId = 12, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 10), Points = 1, Description = "Už nedalyvavimą"},
                    new Result { ResultId = 24, ActivityId = 11, ParticipantId = 12, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 11), Points = 40, Description = "Už dalyvavima"}

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 13,
                FirstName = "Nijolė",
                LastName = "Beriozovaitė-Sengupta",
                Results = new List<Result>
                {
                    new Result { ResultId = 25, ActivityId = 10, ParticipantId = 13, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 10), Points = 6, Description = "Visai neblogai pavariai"},
                    new Result { ResultId = 26, ActivityId = 11, ParticipantId = 13, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 11), Points = 4, Description = "Galėjai ir geriau"}

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 14,
                FirstName = "Viktorija",
                LastName = "Bikulčiūtė",
                Results = new List<Result>
                {
                    new Result { ResultId = 27, ActivityId = 12, ParticipantId = 14, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 12), Points = 6, Description = "Buvo gražu žiūrėti"},
                    new Result { ResultId = 28, ActivityId = 13, ParticipantId = 14, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 13), Points = 3, Description = "Už gražias akis"}

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 15,
                FirstName = "Mindaugas",
                LastName = "Bilevičius",
                Results = new List<Result>
                {
                    new Result { ResultId = 29, ActivityId = 12, ParticipantId = 15, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 12), Points = 12, Description = "One man army!"},
                    new Result { ResultId = 30, ActivityId = 13, ParticipantId = 15, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 13), Points = 2, Description = "Antra vieta šešių žmonių komandoje?"}

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 16,
                FirstName = "Justinas",
                LastName = "Bimbiris",
                Results = new List<Result>
                {
                    new Result { ResultId = 31, ActivityId = 14, ParticipantId = 16, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 14), Points = 6, Description = "Už dalyvavimą"},
                    new Result { ResultId = 32, ActivityId = 15, ParticipantId = 16, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15), Points = 1, Description = "Už pastangas"}

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 17,
                FirstName = "Artūras",
                LastName = "Birbalas",
                Results = new List<Result>
                {
                    new Result { ResultId = 33, ActivityId = 14, ParticipantId = 17, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 14), Points = 0, Description = "Tik antra vienta? Nenusipelnei"},
                    new Result { ResultId = 34, ActivityId = 15, ParticipantId = 17, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 15), Points = 4, Description = "Galėjai ir geriau"}

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 18,
                FirstName = "Agnė",
                LastName = "Buožienė",
                Results = new List<Result>
                {
                    new Result { ResultId = 35, ActivityId = 16, ParticipantId = 18, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 16), Points = 6, Description = "Visai neblogai pavariai"},
                    new Result { ResultId = 36, ActivityId = 17, ParticipantId = 18, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17), Points = 4, Description = "Galėjai ir geriau"}

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 19,
                FirstName = "Dariuš",
                LastName = "Butkevičius",
                Results = new List<Result>
                {
                    new Result { ResultId = 37, ActivityId = 16, ParticipantId = 19, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 16), Points = 5, Description = "Šaunuolis"},
                    new Result { ResultId = 38, ActivityId = 17, ParticipantId = 19, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 17), Points = 4, Description = "Oho! Neblogai."}

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 20,
                FirstName = "Giedrius",
                LastName = "Butkus",
                Results = new List<Result>
                {
                    new Result { ResultId = 39, ActivityId = 18, ParticipantId = 20, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18), Points = 7, Description = "Visai neblogai pavariai"},
                    new Result { ResultId = 40, ActivityId = 19, ParticipantId = 20, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 19), Points = 3, Description = "Galėjai truputį geriau"}

                }
            });
            context.Participants.Add(new Participant
            {
                ParticipantId = 21,
                FirstName = "Jurij",
                LastName = "Čiževskij",
                Results = new List<Result>
                {
                    new Result { ResultId = 41, ActivityId = 18, ParticipantId = 21, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 18), Points = 6, Description = "Visai neblogai pavariai"},
                    new Result { ResultId = 42, ActivityId = 19, ParticipantId = 21, Activity = context.Activities.FirstOrDefault(x => x.ActivityId == 19), Points = 0, Description = "Nuvyliai mane"}

                }
            });

            AddActivityParticipations(context);

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
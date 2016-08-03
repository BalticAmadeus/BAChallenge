using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BAChallengeWebServices.Models;
using System.Globalization;

namespace BAChallengeWebServices.DataAccess
{
    public class ApplicationDBInitializer : CreateDatabaseIfNotExists<ApplicationDBContext>
    {
        protected override void Seed(ApplicationDBContext context)
        {
            //Activities Database
            //Sports activities
            context.Activities.Add(new Activity { ActivityId = 1, Name = "We Run", Date = DateTime.ParseExact("2016-03-12 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-03-09 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Status = ActivityStatus.Open, Description = "Blank", Location= "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 2, Name = "Vilnius Challenge", Date = DateTime.ParseExact("2016-03-14 15:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-03-11 15:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Status = ActivityStatus.Open, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 3, Name = "Bebro kelias", Date = DateTime.ParseExact("2016-04-14 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-04-11 16:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Status = ActivityStatus.Open, Description = "Blank", Location = "Širvintų raj.", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 4, Name = "Velomaratonas", Date = DateTime.ParseExact("2016-04-19 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-04-16 12:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Status = ActivityStatus.Open, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 5, Name = "Orientacinis", Date = DateTime.ParseExact("2016-04-22 11:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-04-18 10:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Status = ActivityStatus.Open, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 6, Name = "Vilniaus Maratonas", Date = DateTime.ParseExact("2016-05-21 09:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-05-15 12:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Status = ActivityStatus.Open, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 7, Name = "Velomaratonas", Date = DateTime.ParseExact("2016-04-19 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-04-16 12:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Status = ActivityStatus.Open, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            //Brain activities
            context.Activities.Add(new Activity { ActivityId = 8, Name = "Paskaita (Švietimas)", Date = DateTime.ParseExact("2016-03-14 10:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-03-10 12:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Brain, Status = ActivityStatus.Open, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 9, Name = "Paskaita (Išorinis pranešimas)", Date = DateTime.ParseExact("2016-03-19 10:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-03-15 12:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Brain, Status = ActivityStatus.Open, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            //Games activities
            context.Activities.Add(new Activity { ActivityId = 10, Name = "Programavimo varžybos", Date = DateTime.ParseExact("2016-03-10 17:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-03-07 09:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Games, Status = ActivityStatus.Open, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 11, Name = "Stalo žaidimų turnyras", Date = DateTime.ParseExact("2016-05-12 13:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-05-09 12:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Games, Status = ActivityStatus.Open, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 12, Name = "Mortal Kombat turnyras", Date = DateTime.ParseExact("2016-05-20 14:40", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-05-16 10:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Games, Status = ActivityStatus.Open, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 13, Name = "Šachmatų turnyras", Date = DateTime.ParseExact("2016-07-12 14:40", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-07-07 17:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Games, Status = ActivityStatus.Open, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 14, Name = "Totalizatorius", Date = DateTime.ParseExact("2016-06-18 15:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-06-14 15:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Games, Status = ActivityStatus.Open, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            //Team activities
            context.Activities.Add(new Activity { ActivityId = 15, Name = "Infobalt Sąskrydis", Date = DateTime.ParseExact("2016-07-18 12:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-07-13 10:50", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Team, Status = ActivityStatus.Open, Description = "Blank", Location = "Trakų raj.", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 16, Name = "Vandensvydis", Date = DateTime.ParseExact("2016-07-10 14:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-07-06 10:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Team, Status = ActivityStatus.Open, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 17, Name = "Tinklinis", Date = DateTime.ParseExact("2016-07-02 11:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-06-28 10:50", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Team, Status = ActivityStatus.Open, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 18, Name = "Dažasvydis", Date = DateTime.ParseExact("2016-07-11 15:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-07-08 10:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Team, Status = ActivityStatus.Open, Description = "Blank", Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });
            context.Activities.Add(new Activity { ActivityId = 19, Name = "Krepšinio/futbolo turnyras", Date = DateTime.ParseExact("2016-07-25 14:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-07-20 10:50", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Team, Status = ActivityStatus.Open, Description = "Blank" , Location = "Vilnius", RegistrationUrl = @"https://docs.google.com/spreadsheets/d/1fb_OWYg_X-JGkTogEQe78qoakBh-H2UpFDr1OOjwlwM/edit?usp=sharing" });

            //Admins Database
            context.Admins.Add(new Admin { AdminId = 1, Username = "Indre", PasswordHash = "4813494d137e1631bba301d5acab6e7bb7aa74ce1185d456565ef51d737677b2" });
            base.Seed(context);

            //Participant Database table
            context.Participants.Add(new Participant { ParticipantId = 1, Name = "Nikolaj", Surname = "Anikejev", Results = new List<Result>
            {
                new Result { ResultId = 1, Activity }
            } });
            /*context.Participants.Add(new Participant { ParticipantId = 2, Name = "Rimvydas", Surname = "Aniulis" });
            context.Participants.Add(new Participant { ParticipantId = 3, Name = "Mindaugas", Surname = "Ardaravičius" });
            context.Participants.Add(new Participant { ParticipantId = 4, Name = "Sandra", Surname = "Auzacalitaitė" });
            context.Participants.Add(new Participant { ParticipantId = 5, Name = "Ignas", Surname = "Bagdonas" });
            context.Participants.Add(new Participant { ParticipantId = 6, Name = "Vitalij", Surname = "Bakula" });
            context.Participants.Add(new Participant { ParticipantId = 7, Name = "Laura", Surname = "Balkiūte" });
            context.Participants.Add(new Participant { ParticipantId = 8, Name = "Irmantas", Surname = "Bankauskas" });
            
            //Result Database table
            context.Results.Add(new Result { ResultId = 1, ParticipantId = 1, ActivityId = 1, Results = 8, Description = "Toli nubego"});
            context.Results.Add(new Result { ResultId = 2, ParticipantId = 4, ActivityId = 1, Results = 4, Description = "Toli nubego" });
            context.Results.Add(new Result { ResultId = 3, ParticipantId = 4, ActivityId = 2, Results = 6, Description = "Gerai padirbejo" });
            context.Results.Add(new Result { ResultId = 4, ParticipantId = 5, ActivityId = 8, Results = 6, Description = "Ne paskutinis" });
            context.Results.Add(new Result { ResultId = 5, ParticipantId = 6, ActivityId = 1, Results = 6, Description = "Labai Toli nubego" });
            context.Results.Add(new Result { ResultId = 6, ParticipantId = 6, ActivityId = 2, Results = 8, Description = "Pasivijo Igna Bagdona" });
            context.Results.Add(new Result { ResultId = 7, ParticipantId = 8, ActivityId = 1, Results = 6, Description = "Neblogai nubego" });
            context.Results.Add(new Result { ResultId = 8, ParticipantId = 8, ActivityId = 17, Results = 2, Description = "Geras totalizatorius" });
            context.Results.Add(new Result { ResultId = 9, ParticipantId = 8, ActivityId = 19, Results = 4, Description = "Toli nuskrido" });*/
        }
    }
}
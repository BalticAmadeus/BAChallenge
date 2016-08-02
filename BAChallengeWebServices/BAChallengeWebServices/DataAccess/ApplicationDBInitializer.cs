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
            context.Activities.Add(new Activity { ActivityId = 1, Name = "We Run", Date = DateTime.ParseExact("2016-03-12 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-03-09 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Status = ActivityStatus.Open, Description = "Blank" ,Location = "Vilnius"});
            context.Activities.Add(new Activity { ActivityId = 2, Name = "Vilnius Challenge", Date = DateTime.ParseExact("2016-03-14 15:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-03-11 15:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Status = ActivityStatus.Open, Description = "Blank", Location = "Kaunas" });
            context.Activities.Add(new Activity { ActivityId = 3, Name = "Bebro kelias", Date = DateTime.ParseExact("2016-04-14 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-04-11 16:20", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Status = ActivityStatus.Open, Description = "Blank", Location = "Ukmerge" });
            context.Activities.Add(new Activity { ActivityId = 4, Name = "Velomaratonas", Date = DateTime.ParseExact("2016-04-19 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-04-16 12:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Status = ActivityStatus.Open, Description = "Blank", Location = "Vilnius" });
            context.Activities.Add(new Activity { ActivityId = 5, Name = "Orientacinis", Date = DateTime.ParseExact("2016-04-22 11:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-04-18 10:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Status = ActivityStatus.Open, Description = "Blank", Location = "Vilnius" });
            context.Activities.Add(new Activity { ActivityId = 6, Name = "Vilniaus Maratonas", Date = DateTime.ParseExact("2016-05-21 09:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-05-15 12:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Status = ActivityStatus.Open, Description = "Blank", Location = "Kaunas" });
            context.Activities.Add(new Activity { ActivityId = 7, Name = "Velomaratonas", Date = DateTime.ParseExact("2016-04-19 16:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-04-16 12:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Sports, Status = ActivityStatus.Open, Description = "Blank", Location = "Ukmerge" });
            context.Activities.Add(new Activity { ActivityId = 8, Name = "Paskaita", Date = DateTime.ParseExact("2016-03-14 10:30", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), RegistrationDate = DateTime.ParseExact("2016-03-10 12:10", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), Branch = ActivityBranch.Brain, Status = ActivityStatus.Open, Description = "Blank", Location = "Vilnius" });

            base.Seed(context);
        }
    }
}
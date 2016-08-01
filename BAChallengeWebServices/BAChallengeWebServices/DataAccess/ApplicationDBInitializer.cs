using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BAChallengeWebServices.Models;

namespace BAChallengeWebServices.DataAccess
{
    public class ApplicationDBInitializer : CreateDatabaseIfNotExists<ApplicationDBContext>
    {
        protected override void Seed(ApplicationDBContext context)
        {
            context.Activities.Add(new Activity { ActivityId = 1, Name = "Begimas", Date = DateTime.Now, RegistrationDate = DateTime.Now, Branch = ActivityBranch.Brain, Status = ActivityStatus.Open, Description = "Blank" });
            context.Activities.Add(new Activity { ActivityId = 2, Name = "Mastymas", Date = DateTime.Now, RegistrationDate = DateTime.Now, Branch = ActivityBranch.Brain, Status = ActivityStatus.Open, Description = "Blank" });
            context.Activities.Add(new Activity { ActivityId = 3, Name = "Rasymas", Date = DateTime.Now, RegistrationDate = DateTime.Now, Branch = ActivityBranch.Brain, Status = ActivityStatus.Open, Description = "Blank" });
            context.Activities.Add(new Activity { ActivityId = 4, Name = "Verkimas", Date = DateTime.Now, RegistrationDate = DateTime.Now, Branch = ActivityBranch.Brain, Status = ActivityStatus.Open, Description = "Blank" });


            base.Seed(context);
        }
    }
}
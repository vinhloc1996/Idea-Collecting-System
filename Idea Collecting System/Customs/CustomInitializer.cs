using System.Data.Entity;
using Idea_Collecting_System.Models;

namespace Idea_Collecting_System.Customs
{
    //Implement in final stage
    public class CustomInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {


            base.Seed(context);
        }
    }
}
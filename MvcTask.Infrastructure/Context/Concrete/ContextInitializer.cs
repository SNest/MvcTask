namespace MvcTask.Infrastructure.Context.Concrete
{
    using System.Data.Entity;

    public class ContextInitializer : DropCreateDatabaseIfModelChanges<EfContext>
    {
        protected override void Seed(EfContext db)
        {
        }
    }
}


namespace MvcTask.Infrastructure.Context.Concrete.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using MvcTask.Domain.Entities.Concrete;

    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}

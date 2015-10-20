namespace MvcTask.Infrastructure.Context.Concrete.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using MvcTask.Domain.Entities.Concrete;

    public class PlatformTypeConfiguration : EntityTypeConfiguration<PlatformType>
    {
        public PlatformTypeConfiguration()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Type).IsRequired()
                                 .HasMaxLength(20);
        }
    }
}

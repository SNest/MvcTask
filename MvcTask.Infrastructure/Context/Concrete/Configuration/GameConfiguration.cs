namespace MvcTask.Infrastructure.Context.Concrete.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using MvcTask.Domain.Entities.Concrete;

    public class GameConfiguration : EntityTypeConfiguration<Game>
    {
        public GameConfiguration()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Key).IsRequired()
                                .HasMaxLength(50);
            this.Property(x => x.Name).IsRequired()
                                 .HasMaxLength(50);
            this.Property(x => x.Description).IsRequired();
            this.Property(x => x.Price).HasColumnType("money").IsRequired();
            this.Property(x => x.UnitsInStock).HasColumnType("smallint").IsRequired();
            this.Property(x => x.Discontinued).HasColumnType("bit").IsRequired();
        }
    }
}

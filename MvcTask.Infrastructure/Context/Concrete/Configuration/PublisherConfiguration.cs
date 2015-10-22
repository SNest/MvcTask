namespace MvcTask.Infrastructure.Context.Concrete.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using MvcTask.Domain.Entities.Concrete;

    class PublisherConfiguration : EntityTypeConfiguration<Publisher>
    {
        public PublisherConfiguration()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.CompanyName).IsRequired().HasColumnType("nvarchar")
                                 .HasMaxLength(40);
            this.Property(x => x.Description).IsRequired().HasColumnType("ntext");
            this.Property(x => x.HomePage).IsRequired().HasColumnType("ntext");
        }
    }
}

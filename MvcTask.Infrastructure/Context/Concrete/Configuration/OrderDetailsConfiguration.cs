namespace MvcTask.Infrastructure.Context.Concrete.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using MvcTask.Domain.Entities.Concrete;

    class OrderDetailsConfiguration : EntityTypeConfiguration<OrderDetails>
    {
        public OrderDetailsConfiguration()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Price).IsRequired().HasColumnType("money");
            this.Property(x => x.Quantity).IsRequired().HasColumnType("smallint");
            this.Property(x => x.Discount).IsRequired().HasColumnType("real");
        }
    }
}

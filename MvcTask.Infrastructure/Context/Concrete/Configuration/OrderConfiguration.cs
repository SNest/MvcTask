namespace MvcTask.Infrastructure.Context.Concrete.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using MvcTask.Domain.Entities.Concrete;

    class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.OrderDate).IsRequired().HasColumnType("date");
        }
    }
}

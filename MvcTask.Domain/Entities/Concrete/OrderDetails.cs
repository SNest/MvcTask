namespace MvcTask.Domain.Entities.Concrete
{
    public class OrderDetails : Entity<long>
    {
        public decimal Price { get; set; }

        public short Quantity { get; set; }

        public float Discount { get; set; }

        public long ProductId { get; set; }

        public virtual Game Product { get; set; }
    }
}

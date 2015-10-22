namespace MvcTask.Domain.Entities.Concrete
{
    using System;
    using System.Collections.Generic;

    public class Order : Entity<long>
    {
        public Order()
        {
            this.OrderDetailses = new HashSet<OrderDetails>();
            this.OrderDate = DateTime.UtcNow;
        }
        public long? CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrderDetails> OrderDetailses { get; set; }
    }
}

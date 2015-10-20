namespace MvcTask.Infrastructure.Context.Concrete.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using MvcTask.Domain.Entities.Concrete;

    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Name).IsRequired()
                                 .HasMaxLength(30);
            this.Property(x => x.Body).IsRequired();
        }
    }
}

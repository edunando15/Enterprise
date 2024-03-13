using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).HasMaxLength(50);
            builder.Property(b => b.Author).HasMaxLength(50);
            builder.Property(b => b.Publisher).HasMaxLength(50);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Entities;

namespace Model.Configurations
{
    internal class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
    {

        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.ToTable("BookCategory");
            builder.HasKey(b => new { b.BookId, b.CategoryId });
        }
    }
}

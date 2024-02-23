using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbConnect.Data.Config;

public class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasQueryFilter(_ => _.IsDeleted);
        builder.ToTable(nameof(Book));
        builder.Property(b => b.Title).IsRequired().HasMaxLength(Constant.Name);
        
    }
}
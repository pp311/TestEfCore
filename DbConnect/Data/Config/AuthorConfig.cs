using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DbConnect.Data.Config;

public class AuthorConfig : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable(nameof(Author));
        builder.Property(a => a.Name).IsRequired().HasMaxLength(Constant.Name);
        
        builder
            .HasMany(a => a.Books)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.ClientNoAction);
    }
}

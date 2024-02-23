using Microsoft.EntityFrameworkCore;

namespace DbConnect.Data;

public class BookDbContext : DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
    }
    
    public DbSet<Book> Books { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookDbContext).Assembly);
    }
}

//  fluent api -> data annotation -> conventions
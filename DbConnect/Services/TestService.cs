using DbConnect.Data;
using DbConnect.Requests;
using Microsoft.EntityFrameworkCore;

namespace DbConnect.Services;

public class TestService
{
    private readonly BookDbContext _context;
    public TestService(BookDbContext context)
    {
        _context = context;
    }

    public async Task CreateBookAsync(CreateBookRequest request)
    {
        var book = new Book
        {
            Title = request.Title,
        };

        _context.Books.Add(book);

        
        await _context.SaveChangesAsync();
   }
    
    public async Task<IEnumerable<Book>> GetBooksAsync(CancellationToken cancellationToken)
    {
        return await _context.Books.ToListAsync(cancellationToken);
    }
    
    public async Task<Book> GetBookAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Books.Where(_ => _.Id == id).FirstOrDefaultAsync(cancellationToken);
    }
    
    public async Task UpdateBookAsync(int id, CreateBookRequest request)
    {
        var book = await _context.Books.FindAsync(id);
        if (book is null)
            throw new Exception("Book not found");

        // _mapper.Map(request, book);
        book.Title = request.Title;
        
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteBookAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book is null)
            throw new Exception("Book not found");
        
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }
}
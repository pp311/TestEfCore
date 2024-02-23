using DbConnect.Requests;
using DbConnect.Services;
using Microsoft.AspNetCore.Mvc;

namespace DbConnect.Controller;

[ApiController]
[Route("/api/test")]
public class TestController : ControllerBase
{
    private readonly TestService _testService;
    public TestController(TestService testService)
    {
        _testService = testService;
    } 
    
    [HttpPost]
    public async Task<IActionResult> CreateBook(CreateBookRequest request)
    {
        await _testService.CreateBookAsync(request);
        return Created();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetBooks(CancellationToken cancellationToken)
    {
        var books = _testService.GetBooksAsync(cancellationToken);
        return Ok(books);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(int id, CancellationToken cancellationToken)
    {
        var book = _testService.GetBookAsync(id, cancellationToken);
        return Ok(book);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, CreateBookRequest request)
    {
        await _testService.UpdateBookAsync(id, request);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        await _testService.DeleteBookAsync(id);
        return NoContent();
    }
}
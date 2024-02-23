using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TestApi.Services;

namespace TestApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly TestService _service;
    public TestController(TestService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<ActionResult<BookResponse>> Get()
    {
        return await _service.Get();
    }

    [HttpPost("books/{bookId:guid}")] //slug
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> Post([FromRoute] Guid bookId, [FromQuery] CreateBookRequest request, CancellationToken cancellationToken)
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        var cancelToken = cts.Token;
        Task task = Task.Delay(100000, cancellationToken);
        return 5;
    }

}

public  class CreateBookRequest
{
    [MaxLength(10)]
    public string Title { get; set; }
    public string Author { get; set; }
}

public class BookResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public string AuthorName { get; set; }
}

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    
    public Author Author { get; set; }
}

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
}
namespace DbConnect.Requests;

public class CreateBookRequest
{
    public string Title { get; set; } = null!;
    public string AuthorName { get; set; } = null!;

}
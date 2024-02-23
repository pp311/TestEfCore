using System.ComponentModel.DataAnnotations;

namespace DbConnect.Data;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public bool IsDeleted { get; set; }
    
    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;// navigation property
}
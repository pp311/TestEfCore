using AutoMapper;
using TestApi.Controllers;

namespace TestApi.Services;

public class TestService
{
    private readonly IMapper _mapper;
    public TestService(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<BookResponse> Get()
    {
        // db fetch
        var author = new Author
        {
            Id = 1,
            Name = "Nguyen Van A"
        };
        
        var book = new Book 
        {
            Id = Guid.NewGuid(),
            Title = "Sach 1",
            AuthorId = author.Id,
            Author = author
        };
       
        // mapping
        
        return _mapper.Map<BookResponse>(book);
    }
    
    public async Task<int> Post(Guid bookId, CreateBookRequest request)
    {
        return 5;
    } 
}

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookResponse>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name)); 
    }
}
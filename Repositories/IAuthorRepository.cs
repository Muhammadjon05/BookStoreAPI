using Book.API.Entities;
using Book.API.Exceptions;

namespace Book.API.Repositories;

public interface IAuthorRepository
{
    Task AddAuthor(Author author);
    Task<Author?> GetAuthorById(Guid authorId);
    Task DeleteAuthorById(Guid authorId);
    Task<List<Author>> GetAuthors();
    
}
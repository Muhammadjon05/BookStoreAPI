using Book.API.Context;
using Book.API.Entities;
using Book.API.Exceptions;
using Microsoft.EntityFrameworkCore;
namespace Book.API.Repositories;
public class AuthorRepository : IAuthorRepository
{
    private readonly BookDbContext _context;

    public AuthorRepository(BookDbContext context)
    {
        _context = context;
    }

    public async Task AddAuthor(Author author)
    {
        await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync();
    }

    public  async Task<Author?> GetAuthorById(Guid authorId)
    {
        var author = await _context.Authors.FirstOrDefaultAsync(i => i.Id == authorId);
        if (author == null)
        {
            throw new AuthorNotFoundException(authorId.ToString());
        }
        return author;
    }

    public async Task DeleteAuthorById(Guid authorId)
    {
        var author = await GetAuthorById(authorId);
        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Author>> GetAuthors()
    {
        var authors = await _context.Authors.ToListAsync();
        return authors;
    }
}
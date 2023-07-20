using Book.API.Context;
using Book.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book.API.Repositories;

public class BookRepository: IBookRepository
{
    private readonly BookDbContext _context;

    public BookRepository(BookDbContext context)
    {
        _context = context;
    }

    public async Task<List<BookAuthor>> GetAuthorsBooks(Guid authorId)
    {
        var books = await _context.BookAuthors.
            Where(i => i.AuthorId == authorId).ToListAsync();
        return books;
    }



    public async Task AddBookAuthor(BookAuthor bookAuthor)
    {
        await _context.BookAuthors.AddAsync(bookAuthor);
        await _context.SaveChangesAsync();
    }

    public  async Task AddBook(Entities.Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBook(Guid bookId)
    {
        var book = await GetBookById(bookId);
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }

    public async Task<Entities.Book?> GetBookById(Guid bookId)
    {
        var book = await _context.Books.FirstOrDefaultAsync(i => i.BookId == bookId);
        
        return book;
    }
}
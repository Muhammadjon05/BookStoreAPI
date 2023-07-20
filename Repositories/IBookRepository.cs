using Book.API.Entities;
using Book.API.Exceptions;
using Book.API.Models.BookModels;

namespace Book.API.Repositories;

public interface IBookRepository
{
	Task<List<BookAuthor>> GetAuthorsBooks(Guid authorId);
	Task AddBook(Entities.Book book);
	Task AddBookAuthor (BookAuthor bookAuthor);
	Task DeleteBook(Guid bookId);
	Task<Entities.Book?> GetBookById(Guid bookId);
	

}
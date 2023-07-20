using Book.API.Entities;
using Book.API.Exceptions;
using Book.API.FileServices;
using Book.API.Models;
using Book.API.Models.BookModels;
using Book.API.Models.CommentModels;
using Book.API.ParseHelper;
using Book.API.Repositories;
using Book.API.Validators;

namespace Book.API.Managers;

public class BookManager
{
    private readonly IBookRepository _bookRepository;
    private readonly AuthorManager _authorManager;
    public BookManager(IBookRepository bookRepository, AuthorManager authorManager)
    {
        _bookRepository = bookRepository;
        _authorManager = authorManager;
    }
    
    public async Task<List<BookAuthorModel>> GetAuthorsBooks(Guid authorId)
    {
        await _authorManager.GetAuthorById(authorId);
        var authorBooks = await _bookRepository.GetAuthorsBooks(authorId);
        return ParseService.ParseToBookAuthorModels(authorBooks);
    }

  

    public async Task<BookModel> AddBook(Guid authorId,CreateBookModel modelBook)
    {
        var validator = new BookValidator();
        var result = validator.Validate(modelBook);
        if (!result.IsValid)
        {
            throw new CreateBookModelIsNotValid("Your given input is not valid");
        }
        
        
        await _authorManager.GetAuthorById(authorId);
        var book = new Entities.Book
        {
            Title = modelBook.Title,
            BookFileUrl = FileService.BookFiles(modelBook.BookFileUrl),
            Description = modelBook.Description,
            BookPhotoUrl = FileService.BookImages(modelBook.BookPhotoUrl!)
        };// generate qilish kere 
        await _bookRepository.AddBook(book);
        var authorBook = new BookAuthor()
        {
            AuthorId = authorId,
            BookId = book.BookId
        };
        await _bookRepository.AddBookAuthor(authorBook);
        return ParseService.ParseToBookModel(book);
    }

    public async Task DeleteBook(Guid authorId,Guid bookId)
    {
        await _authorManager.GetAuthorById(authorId);
        var book = await _bookRepository.GetBookById(bookId);
        if (book == null)
        {
            throw new BookNotFoundException(bookId.ToString());
        }
        
        var isExist =  book.AuthorBooks.Any(i => i.AuthorId == authorId && i.BookId == bookId);
        if (isExist)
        {
            await _bookRepository.DeleteBook(bookId); 
        }
        else
        {
            throw new UnRelatedAuhotorsBookException($"Book is not related to this author");
        }
    }

    public async Task<BookModel> GetBookById(Guid authorId,Guid bookId)
    {
        await _authorManager.GetAuthorById(authorId);
        var book = await _bookRepository.GetBookById(bookId);
        if (book == null)
        {
            throw new BookNotFoundException(bookId.ToString());
        }
        var isExist =  book.AuthorBooks.Any(i => i.AuthorId == authorId && i.BookId == bookId);
        if (isExist)
        {
            return ParseService.ParseToBookModel(book);   
        }
        else
        {
            throw new UnRelatedAuhotorsBookException($"Book is not related to this author");
        }
    }
    
  

 
    
}
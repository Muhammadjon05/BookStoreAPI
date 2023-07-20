using Microsoft.AspNetCore.Mvc;
using Book.API.Models.BookModels;
using System;
using System.Threading.Tasks;
using Book.API.Exceptions;

namespace Book.API.Controllers
{
    public partial class AuthorsController
    {
        [HttpPost("{authorId}/books")]
        public async Task<IActionResult> AddBook(Guid authorId, [FromForm] CreateBookModel modelBook)
        {
            try
            {
                var book = await _bookManager.AddBook(authorId: authorId, modelBook);
                return Ok(book);
            }
            catch (AuthorNotFoundException e)
            {
                return BadRequest($"With this {authorId} we could not find an author");
            }
            catch (CreateBookModelIsNotValid e)
            {
                return BadRequest("Input is invalid try again");
            }
            
        }

        [HttpGet("{authorId}/books")]
        public async Task<IActionResult> GetSingleAuthorBooks(Guid authorId)
        {
            try
            {
                var books = await _bookManager.GetAuthorsBooks(authorId);
                return Ok(books);
            }
            catch (AuthorNotFoundException e)
            {
                return BadRequest($"With this {authorId} we could not find an author");
            }
           
        }

        [HttpGet("{authorId}/books/{bookId}")]
        public async Task<IActionResult> GetBookById(Guid authorId, Guid bookId)
        {
            try
            {
                var book = await _bookManager.GetBookById(authorId, bookId);
                return Ok(book);
            }
            catch (BookNotFoundException e)
            {
                return BadRequest($"With this {bookId} we could not find an book");
            }
            catch (AuthorNotFoundException e)
            {
                return BadRequest($"With this {authorId} we could not find an author");
            }
            catch (UnRelatedAuhotorsBookException e)
            {
                
                return BadRequest($"Book is not related to this author");
            }
          
        }

        [HttpDelete("{authorId}/books/{bookId}")]
        public async Task<IActionResult> DeleteAuthorsBook(Guid authorId, Guid bookId)
        {
            try
            {
                await _bookManager.DeleteBook(authorId, bookId);
                return Ok();
            }
            catch (AuthorNotFoundException e)
            {
                return BadRequest($"With this {authorId} we could not find an author");
            }
            catch (BookNotFoundException e)
            {
                return BadRequest($"With this {bookId} we could not find an book");
            }
            catch (UnRelatedAuhotorsBookException e)
            {
                return BadRequest($"Book is not related to this author");
            }
       
        }
    }
}
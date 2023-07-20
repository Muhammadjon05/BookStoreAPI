using Microsoft.AspNetCore.Mvc;
using Book.API.Models.CommentModels;
using System;
using System.Threading.Tasks;
using Book.API.Exceptions;

namespace Book.API.Controllers
{
    public partial class AuthorsController
    {
        [HttpPost("{authorId}/books/{bookId}/comments")]
        public async Task<IActionResult> AddComment(Guid authorId, Guid bookId, CreateCommentModel model)
        {
            try
            {
                var comment = await _commentManager.AddComment(authorId, bookId, model);
                return Ok(comment);

            }
            catch (BookNotFoundException e)
            {
                return BadRequest($"With this {bookId} we could not find an book");
            }
            catch (AuthorNotFoundException e)
            {
                return BadRequest($"With this {authorId} we could not find an author");
            }
            catch (CreateCommentModelIsNotValid e)
            {
                return BadRequest("Invalid input try again");
            }
          
        }

        [HttpGet("{authorId}/books/{bookId}/comments")]
        public async Task<IActionResult> GetComments(Guid authorId, Guid bookId)
        {
            try
            {
                var comments = await _commentManager.GetComments(authorId, bookId);
                return Ok(comments);
            }
            catch (BookNotFoundException e)
            {
                return BadRequest($"With this {bookId} we could not find an book");
            }
            catch (AuthorNotFoundException e)
            {
                return BadRequest($"With this {authorId} we could not find an author"); 
            }
        }

        [HttpGet("{authorId}/books/{bookId}/comments/{commentId}")]
        public async Task<IActionResult> GetCommentById(Guid authorId, Guid bookId, Guid commentId)
        {
            try
            {
                var comment = await _commentManager.GetCommentBydId(authorId, bookId, commentId);
                return Ok(comment);
            }
            catch (BookNotFoundException e)
            {
                return BadRequest($"With this {bookId} we could not find an book");
            }
            catch (AuthorNotFoundException e)
            {
                return BadRequest($"With this {authorId} we could not find an author");
            }
            catch (CommentNotFoundException e)
            {
                return BadRequest($"With this {commentId} we could not find an comment");
            }

        }

        [HttpDelete("{authorId}/books/{bookId}/comments/{commentId}")]
        public async Task<IActionResult> DeleteCommentById(Guid authorId, Guid bookId, Guid commentId)
        {
            try
            {
                await _commentManager.Delete(authorId, bookId, commentId);
                return Ok();
            }
            catch (BookNotFoundException e)
            {
                return BadRequest($"With this {bookId} we could not find an book");
            }
            catch (AuthorNotFoundException e)
            {
                return BadRequest($"With this {authorId} we could not find an author");
            }
            catch (CommentNotFoundException e)
            {
                return BadRequest($"With this {commentId} we could not find an comment");
            }
         
        }
    }
}
using System.Net;
using Book.API.Managers;
using Book.API.Models.AuthorModels;
using Book.API.Models.BookModels;
using Book.API.Models.CommentModels;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;
using Book.API.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Book.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public partial  class AuthorsController : ControllerBase
{
    private readonly AuthorManager _authorManager;
    private readonly BookManager _bookManager;
    private readonly CommentManager _commentManager;
    public AuthorsController(AuthorManager authorManager, BookManager bookManager, CommentManager commentManager)
    {
        _authorManager = authorManager;
        _bookManager = bookManager;
        _commentManager = commentManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAuthors()
    {
        var authors = await _authorManager.GetAuthors();
        return Ok(authors);
    }

    [HttpPost]
    public async Task<IActionResult> AddAuthor(CreateAuthorModel model)
    {
        try
        {
            var author = await _authorManager.AddAuthor(model);
            return Ok(author);
        }
        catch (CreateAuthorModelNotValid e)
        {
            return BadRequest("Your given input is not valid");
        }
    }

    [HttpGet("{authorId}")]
    [ProducesResponseType(type: typeof(AuthorModel), statusCode: 200)]
    public async Task<IActionResult> GetAuthorById(Guid authorId)
    {
        try
        {
            var author = await _authorManager.GetAuthorById(authorId);
            return Ok(author);
        }
        catch (AuthorNotFoundException e)
        {
            return BadRequest($"With this {authorId} we could not find an author");
        }
      
     
    }

    [HttpDelete("{authorId}")]
    public async Task<IActionResult> DeleteAuthorById(Guid authorId)
    {
        try
        {
           await _authorManager.DeleteAuthorById(authorId);
           return Ok();
        }
        catch (AuthorNotFoundException e)
        {
            return BadRequest($"With this {authorId} we could not find an author");
        }
    }
}
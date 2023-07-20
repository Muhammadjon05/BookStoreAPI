using Book.API.Entities;
using Book.API.Exceptions;
using Book.API.Models;
using Book.API.Models.AuthorModels;
using Book.API.Models.CommentModels;
using Book.API.ParseHelper;
using Book.API.Repositories;
using Book.API.Validators;

namespace Book.API.Managers;

public class AuthorManager
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorManager(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    
    public async Task<AuthorModel> AddAuthor(CreateAuthorModel model)
    {

        var validator = new AuthorValidator();
        var result = validator.Validate(model);
        if (!result.IsValid)
        {
            throw new CreateAuthorModelNotValid("Your given input is not valid");
        }
        
        var author = new Author()
        {
            Firstname = model.Firstname,
            Lastname = model.Lastname,
            Username = model.Username,
            Password = model.Password
        };
        await _authorRepository.AddAuthor(author);
        return ParseService.ParseToAuthorModel(author);
    }

    public async Task<AuthorModel> GetAuthorById(Guid authorId)
    {
        var author = await _authorRepository.GetAuthorById(authorId);
        if (author == null)
        {
            throw new AuthorNotFoundException(authorId.ToString());
        }
        return ParseService.ParseToAuthorModel(author);
    }

    public async Task DeleteAuthorById(Guid authorId)
    {

        await GetAuthorById(authorId);
        await _authorRepository.DeleteAuthorById(authorId);
    }

    public async Task<List<AuthorModel>> GetAuthors()
    {
        var authors = await _authorRepository.GetAuthors();
        return ParseService.ParseToAuthorList(authors);
    }

  
}
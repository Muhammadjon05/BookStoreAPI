using Book.API.Entities;
using Book.API.Exceptions;
using Book.API.Models.CommentModels;
using Book.API.ParseHelper;
using Book.API.Repositories;
using Book.API.Validators;

namespace Book.API.Managers;

public class CommentManager
{
    private readonly ICommentRepository _commentRepository;
    private readonly BookManager _bookManager;
    public CommentManager(ICommentRepository commentRepository, BookManager bookManager)
    {
        _commentRepository = commentRepository;
        _bookManager = bookManager;
    }

    public async Task<CommentModel> AddComment(Guid authorId, Guid bookId,CreateCommentModel model)
    {

        var validator = new CommentValidator();
        var result = validator.Validate(model);
        if (!result.IsValid)
        {
            throw new CreateCommentModelIsNotValid("Your given input is not valid");
        }
        await _bookManager.GetBookById(authorId,bookId);
        var comment = new Comment()
        {
            Message = model.Message,
            AuthorId = authorId,
            BookId = bookId
        };
        await _commentRepository.AddComment(comment);
        return ParseService.ParseToCommentModel(comment);
    }
    public async Task<List<CommentModel>> GetComments(Guid authorId, Guid bookId)
    {
        await _bookManager.GetBookById(authorId,bookId);
        var comments = await _commentRepository.GetComments(authorId, bookId);
        return ParseService.ParseToCommentModelList(comments);
    }

    public async Task<CommentModel> GetCommentBydId(Guid authorId, Guid bookId, Guid commentId)
    {
        await _bookManager.GetBookById(authorId,bookId);
        var comment = await _commentRepository.GetCommentById(commentId);
        if (comment == null)
        {
            throw new CommentNotFoundException(commentId.ToString());
        }
        return ParseService.ParseToCommentModel(comment);
    }
      
    public async Task Delete(Guid authorId, Guid bookId, Guid commentId)
    {
        await _bookManager.GetBookById(authorId,bookId);
        await _commentRepository.DeleteComment(commentId);
    }
    

}
using Book.API.Entities;

namespace Book.API.Repositories;

public interface ICommentRepository
{
	Task AddComment(Comment comment);
	Task<Comment?> GetCommentById(Guid commentId);
	Task<List<Comment>> GetComments(Guid authorId,Guid bookId);
	Task DeleteComment(Guid commentId);
	
}
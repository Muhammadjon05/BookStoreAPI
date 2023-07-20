using Book.API.Context;
using Book.API.Entities;
using Book.API.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Book.API.Repositories;

public class CommentRepository: ICommentRepository
{
    private readonly BookDbContext _context;

    public CommentRepository(BookDbContext context)
    {
        _context = context;
    }

    public async Task AddComment(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
    }

    public async Task<Comment?> GetCommentById(Guid commentId)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(i => i.Id == commentId);
	
        return comment;
    }

    public async Task<List<Comment>> GetComments(Guid authorId, Guid bookId)
    {
        var comments = await _context.Comments.Where
            (i => i.AuthorId == authorId && i.BookId == bookId).ToListAsync();
        return comments;
    }

    public async Task DeleteComment(Guid commentId)
    {
        var comment = await _context.Comments.FirstOrDefaultAsync(i => i.Id == commentId);
        if (comment == null)
        {
            throw new CommentNotFoundException(commentId.ToString());
        }
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
    }
}
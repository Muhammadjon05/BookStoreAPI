using Book.API.Entities;
using Book.API.Models;
using Book.API.Models.AuthorModels;
using Book.API.Models.BookModels;
using Book.API.Models.CommentModels;

namespace Book.API.ParseHelper;

public class ParseService
{
    public static AuthorModel ParseToAuthorModel(Author author)
    {
        var authorModel = new AuthorModel()
        {
            Id = author.Id,
            Firstname = author.Firstname,
            Lastname = author.Lastname,
            Username = author.Username,
            AuthorBooks = ParseToBookAuthorModels(author.AuthorBooks),
            Comments = ParseToCommentModelList(author.Comments)
        };
        return authorModel;
    }
    public static List<BookAuthorModel> ParseToBookAuthorModels(List<BookAuthor>? authors)
    {
        if (authors == null || authors.Count == 0)
        {
            return new List<BookAuthorModel>();
        }
        else
        {
            var list = new List<BookAuthorModel>();
            foreach (var author in authors)
            {
                list.Add(ParseToBookAuthorModel(author));
            }

            return list;
        }
    }
    public static List<AuthorModel> ParseToAuthorList(List<Author>? authors)
    {
        if (authors == null || authors.Count == 0)
        {
            return new List<AuthorModel>();
        }
        else
        {
            var model = new List<AuthorModel>();
            foreach (var author in authors)
            {
                model.Add(ParseToAuthorModel(author));
            }

            return model;
        }
    }


    public static BookAuthorModel ParseToBookAuthorModel(BookAuthor author)
    {
        var model = new BookAuthorModel()
        {
            Id = author.Id,
            AuthorId = author.AuthorId,
            BookId = author.BookId
        };
        return model;
    }

    public static CommentModel ParseToCommentModel(Comment comment)
    {
        var model = new CommentModel()
        {
            Id = comment.Id,
            AuthorId = comment.AuthorId,
            Message = comment.Message,
            BookId = comment.BookId,
            CreatedDate = comment.CreatedDate
        };
        return model;
    }

    public static List<CommentModel> ParseToCommentModelList(List<Comment>? comments)
    {
        if (comments == null || comments.Count == 0)
        {
            return new List<CommentModel>();
        }
        else
        {
            var list = new List<CommentModel>();
            foreach (var comment in comments)
            {
                list.Add(ParseToCommentModel(comment));
            }

            return list;
        }
    }
    public static BookModel ParseToBookModel(Entities.Book book)
    {
        var model = new BookModel
        {
            BookId = book.BookId,
            Title = book.Title,
            BookFileUrl = book.BookFileUrl,
            BookPhotoUrl = book.BookPhotoUrl,
            Description = book.Description,
            Comments = ParseToCommentModelList(book.Comments),
            AuthorBooks = ParseToBookAuthorModels(book.AuthorBooks)
        };
        return model;
    }
    public static List<BookAuthorModel> ParseToAuthorModels(List<BookAuthor>? bookAuthors)
    {
        if (bookAuthors == null || bookAuthors.Count == 0)
        {
            return new List<BookAuthorModel>();
        }
        else
        {
            var list = new List<BookAuthorModel>();
            foreach (var bookAuthor in bookAuthors)
            {
                list.Add(ParseService.ParseToBookAuthorModel(bookAuthor));
            }

            return list;
        }
    }
}
namespace Book.API.Models.BookModels;

public class CreateBookModel
{
    public required string Title { get; set; }
    public string? Description { get; set; }

    public IFormFile? BookPhotoUrl { get; set; }
    public required IFormFile BookFileUrl { get; set; }
}
using Book.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book.API.Context;

public class BookDbContext:DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }


    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Entities.Book> Books => Set<Entities.Book>();
    public DbSet<BookAuthor> BookAuthors {  get; set; }
    public DbSet<Comment> Comments { get; set; }
}
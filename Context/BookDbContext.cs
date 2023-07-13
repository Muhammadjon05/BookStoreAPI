using Book.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book.API.Context;

public class BookDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }

    DbSet<Author> Authors { get; set; }
    DbSet<Entities.Book> Books { get; set; }
    DbSet<BookAuthor> BookAuthors {  get; set; }
    DbSet<Comment> Comments { get; set; }
}
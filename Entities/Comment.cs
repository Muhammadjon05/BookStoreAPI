using System.ComponentModel.DataAnnotations;

namespace Book.API.Entities;

    public class Comment
{
        [Key]
        public Guid Id { get; set; }

        public string Message { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public Guid BookId { get; set; }

        public virtual Book Book { get; set; }

        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }

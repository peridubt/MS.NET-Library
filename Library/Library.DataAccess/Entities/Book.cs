using System.ComponentModel.DataAnnotations.Schema;

namespace Library.DataAccess.Entities;

[Table("Book")]
public class Book : BaseEntity
{
    public string BookName { get; set; }
    public int NumberOfPages { get; set; }
    public int PublishingYear { get; set; }
    public string ISBN { get; set; }

    public int? AuthorId { get; set; }
    public Author Author { get; set; }

    public int? PublisherId { get; set; }
    public Publisher Publisher { get; set; }

    public int? BookTypeId { get; set; }
    public BookType? BookType { get; set; }

    public virtual ICollection<BookDownloads> BookDownloads { get; set; }
    public virtual ICollection<BookUpdates> BookUpdates { get; set; }
}
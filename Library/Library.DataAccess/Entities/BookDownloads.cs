using System.ComponentModel.DataAnnotations.Schema;

namespace Library.DataAccess.Entities;

[Table("BookDownloads")]
public class BookDownloads : BaseEntity
{
    public int? UserId { get; set; }
    public User User { get; set; }

    public int? BookId { get; set; }
    public Book Book { get; set; }

    public DateTime DownloadDate { get; set; }
}
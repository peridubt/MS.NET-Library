using System.ComponentModel.DataAnnotations.Schema;

namespace Library.DataAccess.Entities;

[Table("Publisher")]
public class Publisher: BaseEntity
{
    public string PublisherName { get; set; }
    public int Code { get; set; }
    
    public virtual ICollection<Book> Books { get; set; }
}
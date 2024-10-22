using System.ComponentModel.DataAnnotations.Schema;

namespace Library.DataAccess.Entities;

[Table("BookType")]
public class BookType: BaseEntity
{
    public string BookTypeName { get; set; }
    
    public virtual ICollection<Book>? Books { get; set; }
}
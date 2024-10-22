using System.ComponentModel.DataAnnotations.Schema;

namespace Library.DataAccess.Entities;

[Table("Author")]
public class Author : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PatronymicName { get; set; }

    public virtual ICollection<Book>? Books { get; set; }
}
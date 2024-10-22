using System.ComponentModel.DataAnnotations.Schema;

namespace Library.DataAccess.Entities;

[Table("User")]
public class User : BaseEntity
{
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string EMail { get; set; }
    
    public virtual ICollection<BookDownloads>? BookDownloads { get; set; }
}
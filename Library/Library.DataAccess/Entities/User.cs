using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Library.DataAccess.Entities;

[Table("User")]
public class User : IdentityUser<int>, IBaseEntity
{
    public Guid ExternalId { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }

    public virtual ICollection<BookDownloads>? BookDownloads { get; set; }
}

public class UserRole : IdentityUserRole<int>
{
}
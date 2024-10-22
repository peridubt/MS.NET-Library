using System.ComponentModel.DataAnnotations.Schema;

namespace Library.DataAccess.Entities;

[Table("Employee")]
public class Employee: User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PatronymicName { get; set; }
    public string PhoneNumber { get; set; }
    
    public virtual ICollection<BookUpdates>? BookUpdates { get; set; }
}
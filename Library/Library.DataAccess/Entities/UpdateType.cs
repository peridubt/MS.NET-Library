using System.ComponentModel.DataAnnotations.Schema;

namespace Library.DataAccess.Entities;

[Table("UpdateType")]
public class UpdateType : BaseEntity
{
    public string UpdateTypeName { get; set; }
    public virtual ICollection<BookUpdates> BookUpdates { get; set; }
}
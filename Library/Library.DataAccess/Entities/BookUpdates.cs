using System.ComponentModel.DataAnnotations.Schema;

namespace Library.DataAccess.Entities;

[Table("BookUpdates")]
public class BookUpdates : BaseEntity
{
    public int? EmployeeId { get; set; }
    public Employee Employee { get; set; }
    
    public int? BookId { get; set; }
    public Book Book { get; set; }
    
    public int? UpdateTypeId { get; set; }
    public UpdateType UpdateType { get; set; }
    
    public DateTime LogTime { get; set; }
    
}
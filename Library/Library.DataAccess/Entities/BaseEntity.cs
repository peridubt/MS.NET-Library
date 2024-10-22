namespace Library.DataAccess.Entities;

public class BaseEntity
{
    public int Id { get; set; } // PK

    public Guid ExternalId { get; set; }
    public DateTime ModificationTime { get; set; } // optional
    public DateTime CreationTime { get; set; } //optional 
}
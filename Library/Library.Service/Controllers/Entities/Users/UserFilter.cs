namespace Library.Service.Controllers.Entities.Users;

public class UserFilter
{
    public string? LoginPart { get; set; }
    public string? EmailPart { get; set; }
    
    public DateTime? CreationTime { get; set; }
    public DateTime? ModificationTime { get; set; }
}
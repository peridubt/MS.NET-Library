namespace Library.BusinessLogic.Users.Entities;

public class FilterUserModel
{
    public string? LoginPart { get; set; }
    public string? EmailPart { get; set; }
    
    public DateTime? CreationTime { get; set; }
    public DateTime? ModificationTime { get; set; }
}
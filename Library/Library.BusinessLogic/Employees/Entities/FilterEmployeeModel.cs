using Library.BusinessLogic.Users.Entities;

namespace Library.BusinessLogic.Employees.Entities;

public class FilterEmployeeModel : FilterUserModel
{
    public string FirstNamePart { get; set; }
    public string LastNamePart { get; set; }
    public string? PatronymicNamePart { get; set; }
    public string PhoneNumberPart { get; set; }
}
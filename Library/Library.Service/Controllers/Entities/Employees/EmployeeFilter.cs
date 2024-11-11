namespace Library.Service.Controllers.Entities.Employees;

public class EmployeeFilter
{
    public string LastNamePart { get; set; }
    public string FirstNamePart { get; set; }
    public string? PatronymicNamePart { get; set; }
    public string PhoneNumberPart { get; set; }
}
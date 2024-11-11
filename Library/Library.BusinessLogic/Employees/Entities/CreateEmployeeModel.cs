using Library.BusinessLogic.Users.Entities;

namespace Library.BusinessLogic.Employees.Entities;

public class CreateEmployeeModel : CreateUserModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PatronymicName { get; set; }
    public string PhoneNumber { get; set; }
}
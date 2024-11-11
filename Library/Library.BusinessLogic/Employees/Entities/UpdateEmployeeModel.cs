using Library.BusinessLogic.Users.Entities;

namespace Library.BusinessLogic.Employees.Entities;

public class UpdateEmployeeModel: UpdateUserModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PatronymicName { get; set; }
    public string PhoneNumber { get; set; }
}
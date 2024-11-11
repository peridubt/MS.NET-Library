using Library.Service.Controllers.Entities.Users;

namespace Library.Service.Controllers.Entities.Employees;

public class RegisterEmployeeRequest : RegisterUserRequest
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string PatronymicName { get; set; }
    public string PhoneNumber { get; set; }
}
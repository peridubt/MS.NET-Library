namespace Library.Service.Controllers.Entities.Users;

public class RegisterUserRequest
{
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
}
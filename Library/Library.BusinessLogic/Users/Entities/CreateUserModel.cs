namespace Library.BusinessLogic.Users.Entities;

public class CreateUserModel
{
    public string Login { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
}
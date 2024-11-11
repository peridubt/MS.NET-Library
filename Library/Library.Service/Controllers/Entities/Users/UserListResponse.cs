using Library.BusinessLogic.Users.Entities;

namespace Library.Service.Controllers.Entities.Users;

public class UserListResponse
{
    public List<UserModel> Users { get; set; }
}
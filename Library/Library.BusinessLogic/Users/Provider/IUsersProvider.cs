using Library.BusinessLogic.Users.Entities;

namespace Library.BusinessLogic.Users.Provider;

public interface IUsersProvider
{
    IEnumerable<UserModel> GetUsers(FilterUserModel? filter = null);
    UserModel GerUserInfo(int id);
}
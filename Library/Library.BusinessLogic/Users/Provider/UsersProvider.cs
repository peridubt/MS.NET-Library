using AutoMapper;
using Library.BusinessLogic.Users.Entities;
using Library.BusinessLogic.Users.Exceptions;
using Library.DataAccess;
using Library.DataAccess.Entities;

namespace Library.BusinessLogic.Users.Provider;

public class UsersProvider: IUsersProvider
{
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public UsersProvider(IRepository<User> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public IEnumerable<UserModel> GetUsers(FilterUserModel? filter = null)
    {
        string? loginPart = filter?.LoginPart;
        string? emailPart = filter?.EmailPart;
        DateTime? creationTime = filter?.CreationTime;
        DateTime? modificationTime = filter?.ModificationTime;

        var users = _userRepository.GetAll(u =>
            (loginPart == null || u.Login == loginPart) &&
            (emailPart == null || u.Email.Contains(emailPart)) &&
            (creationTime == null || u.CreationTime == creationTime) &&
            (modificationTime == null || u.ModificationTime == modificationTime)
        );
        return _mapper.Map<IEnumerable<UserModel>>(users);
    }

    public UserModel GerUserInfo(int id)
    {
        var entity = _userRepository.GetById(id);
        if (entity == null)
        {
            throw new UserNotFoundException("User not found");
        }

        return _mapper.Map<UserModel>(entity);
    }
}
using AutoMapper;
using Library.BusinessLogic.Users.Entities;
using Library.BusinessLogic.Users.Manager;
using Library.BusinessLogic.Users.Provider;
using Library.Service.Controllers.Entities.Users;
using Library.Service.Validator.User;
using Microsoft.AspNetCore.Mvc;

namespace Library.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersManager _usersManager;
    private readonly IUsersProvider _usersProvider;
    private readonly IMapper _mapper;
    private readonly Serilog.ILogger _logger;

    public UsersController(IUsersManager usersManager, IUsersProvider usersProvider,
        IMapper mapper, Serilog.ILogger logger)
    {
        _usersManager = usersManager;
        _usersProvider = usersProvider;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpPost]
    public IActionResult RegisterUser([FromBody] RegisterUserRequest request)
    {
        var validationResult = new UserValidator().Validate(request);
        if (validationResult.IsValid)
        {
            var createUserModel = _mapper.Map<CreateUserModel>(request);
            var userModel = _usersManager.CreateUser(createUserModel);
            return Ok(new UserListResponse
            {
                Users = [userModel]
            });
        }

        _logger.Error(validationResult.ToString());
        return BadRequest(validationResult.ToString());
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _usersProvider.GetUsers();
        return Ok(new UserListResponse
        {
            Users = users.ToList()
        });
    }

    [HttpGet]
    [Route("filter")]
    public IActionResult GetFilteredUsers([FromQuery] UserFilter filter)
    {
        var userFilterModel = _mapper.Map<FilterUserModel>(filter);
        var users = _usersProvider.GetUsers(userFilterModel);
        return Ok(new UserListResponse
        {
            Users = users.ToList()
        });
    }
}
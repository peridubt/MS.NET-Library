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
public class UsersController(
    IUsersManager usersManager,
    IUsersProvider usersProvider,
    IMapper mapper,
    Serilog.ILogger logger)
    : ControllerBase
{
    [HttpPost]
    public IActionResult RegisterUser([FromBody] RegisterUserRequest request)
    {
        var validationResult = new UserValidator().Validate(request);
        if (validationResult.IsValid)
        {
            var createUserModel = mapper.Map<CreateUserModel>(request);
            var userModel = usersManager.CreateUser(createUserModel);
            return Ok(new UserListResponse
            {
                Users = [userModel]
            });
        }

        logger.Error(validationResult.ToString());
        return BadRequest(validationResult.ToString());
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = usersProvider.GetUsers();
        return Ok(new UserListResponse
        {
            Users = users.ToList()
        });
    }

    [HttpGet]
    [Route("filter")]
    public IActionResult GetFilteredUsers([FromQuery] UserFilter filter)
    {
        var userFilterModel = mapper.Map<FilterUserModel>(filter);
        var users = usersProvider.GetUsers(userFilterModel);
        return Ok(new UserListResponse
        {
            Users = users.ToList()
        });
    }
}
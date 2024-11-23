using Library.BusinessLogic.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Service.Controllers;

public class AuthController(IAuthProvider authProvider) : ControllerBase
{
    [HttpGet]
    [Route("login")]
    public async Task<IActionResult> LoginUser([FromQuery] string email, [FromQuery] string password)
    {
        try
        {
            var tokens = await authProvider.AuthorizeUser(email, password);
            return Ok(tokens);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // #TODO: Реализовать
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterUser(string email, string password) 
    {
        throw new NotImplementedException();
    }
}
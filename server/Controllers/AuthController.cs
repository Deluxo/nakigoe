using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Services;
using Server.Models.InputModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Server.Data;

namespace Server.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class AuthController : ControllerBase
  {

    readonly IUSerService _userService;
    readonly UserContext _userContext;
    public AuthController(IUSerService userService, UserContext userContext)
    {
      _userService = userService;
      _userContext = userContext;
    }

    [Authorize]
    [HttpGet]
    public IActionResult get()
    {
      // Gets the user id and then finds the user
      var test = User.Identity.Name;
      var user = 
        _userContext.Users.FirstOrDefault(user => user.Id.Equals(test));
      return Ok(test);
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Post([FromBody] AuthModel authModel)
    {
      var token = _userService.Authenticate(authModel.username, authModel.password);

      return Ok(token ?? "Username or password not valid");
    }
  }
}
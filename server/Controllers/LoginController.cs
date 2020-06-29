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
using Models.DataObjects;

namespace Server.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class LoginController : ControllerBase
  {

    readonly IUSerService _userService;
    readonly UserContext _userContext;
    public LoginController(IUSerService userService, UserContext userContext)
    {
      _userService = userService;
      _userContext = userContext;
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Post([FromForm] LoginModel authModel)
    {
      var auth = _userService.Authenticate(authModel.UserName, authModel.Password);

      if (auth == null)
        return Unauthorized("Username or password invalid");

      return Ok(auth);
    }
  }
}
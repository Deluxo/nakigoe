using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Services;
using Server.Models.InputModels;

namespace Server.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AuthController : ControllerBase
  {

    readonly IUSerService _userService;
    public AuthController(IUSerService userService)
    {
      _userService = userService;
    }

    [HttpPost]
    public IActionResult Post([FromBody] AuthModel authModel)
    {
      var token = _userService.Authenticate(authModel.username, authModel.password);

      return Ok(token ?? "Username or password not valid");
    }
  }
}
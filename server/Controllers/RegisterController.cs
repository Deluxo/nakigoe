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

namespace Server.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class RegisterController : ControllerBase
  {
    readonly IUSerService _userService;
    public RegisterController(IUSerService userService)
    {
      _userService = userService;
    }

    [HttpPost]
    public IActionResult Post([FromForm] RegisterModel registerModel)
    {
      var userExists = _userService.IfUserExists(registerModel.UserName);
      if (userExists)
        return Unauthorized("Username has already been taken");

      var token = _userService.Register(registerModel);

      return Ok(token);
    }
  }
}
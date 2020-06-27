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
    readonly IFileService _fileService;
    public RegisterController(IUSerService userService, IFileService fileService)
    {
      _userService = userService;
      _fileService = fileService;

    }

    [HttpPost]
    public IActionResult Post([FromForm] RegisterModel registerModel)
    {
      var userExists = _userService.IfUserExists(registerModel.UserName);
      if (userExists)
        return Unauthorized("Username has already been taken");

      _fileService.SaveProfilePic(registerModel.ProfilePicture);

      var token = _userService.Register(registerModel);

      return Ok(token);
    }
  }
}
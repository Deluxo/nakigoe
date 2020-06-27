using System.Linq;
using Server.Data;
using BCrypt.Net;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using System.Text;
using Models.DataObjects;
using Server.Models.InputModels;
using Server.Models.OutputModels;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Server.Services
{
  public interface IFileService
  {
    string ProfilePicDir { get; set; }

    void SaveProfilePic(IFormFile file);
    void CreateDirectories();
  }

  public class FileService : IFileService
  {

    public string ProfilePicDir { get; set; }

    public void CreateDirectories()
    {
      // Create folder to store profile pics
      if (!Directory.Exists(ProfilePicDir))
        Directory.CreateDirectory(ProfilePicDir);
    }
    public void SaveProfilePic(IFormFile file)
    {

    }
  }

  public class FileServiceFactory
  {
    public static FileService Create(string profilePicDir)
    {
      var fileService = new FileService
      {
        ProfilePicDir = profilePicDir
      };
      fileService.CreateDirectories();
      return fileService;
    }
  }
}


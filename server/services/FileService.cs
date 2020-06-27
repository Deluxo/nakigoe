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
using System.Threading.Tasks;

namespace Server.Services
{
  public interface IFileService
  {
    string ProfilePicDir { get; set; }

    Task<string> SaveProfilePic(IFormFile file);
    void CreateDirectories();
  }

  public class FileService : IFileService
  {

    public string ProfilePicDir { get; set; }

    public void CreateDirectories()
    {
      if (!Directory.Exists(ProfilePicDir))
        Directory.CreateDirectory(ProfilePicDir);
    }
    public async Task<string> SaveProfilePic(IFormFile file)
    {
      var newName = file.FileName; // TODO: Change to like, guid or something
      var newPath = Path.Combine(ProfilePicDir, newName);
      // TODO: Handle multiple files uploaded and stuff
      using (var fileStream = new FileStream(newPath, FileMode.Create))
      {
        await file.CopyToAsync(fileStream);
      }

      return newName;
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


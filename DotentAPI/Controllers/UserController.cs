using Microsoft.AspNetCore.Mvc;

using DotnetAPI.Dots;
using DotnetAPI.Models;
using DotnetAPI.Data;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    DataContextDapper _dapper;
    public UserController(IConfiguration config)
    {
        _dapper = new DataContextDapper(config);
    }

    [HttpGet("/Users")]
    public IEnumerable<User> GetAll()
    {
        IEnumerable<User> users = _dapper.LoadData<User>(@$"SELECT * FROM MarketingSchema.Users");
        return users;
    }

    [HttpGet("/User/{id}")]
    public IActionResult GetById(int id)
    {
        try {
          User user = _dapper.LoadDataSingle<User>(@$"SELECT * FROM MarketingSchema.Users WHERE Id = {id}");
          return Ok(user);
        } catch (Exception e) {
          return BadRequest(e.Message);
        }
    }

    [HttpPost("")]
    public IActionResult Create(UserDots user)
    {
        bool success = _dapper.ExecuteSql(
          @$"INSERT INTO MarketingSchema.Users 
          (Username, Email, Password, Active) 
          VALUES (
            '{user.Username}', 
            '{user.Email}', 
            '{user.Password}', 
            '{user.Active}'
          )");

        if (success)
        {
            return Ok("User created successfully");
        }
        else
        {
            return BadRequest("Failed to create user");
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UserDots user)
    {
        try {
            User existingUser = _dapper.LoadDataSingle<User>(@$"SELECT * FROM MarketingSchema.Users WHERE Id = {id}");

            bool success = _dapper.ExecuteSql(
              @$"UPDATE MarketingSchema.Users 
              SET 
                Username = '{user.Username}', 
                Email = '{user.Email}', 
                Password = '{user.Password}', 
                Active = '{user.Active}' 
              WHERE Id = {id}");

            if (success)
            {
                return Ok("User updated successfully");
            }
            else
            {
                return BadRequest("Failed to update user");
            }
        } catch (Exception e) {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try {
            User existingUser = _dapper.LoadDataSingle<User>(@$"SELECT * FROM MarketingSchema.Users WHERE Id = {id}");

            bool success = _dapper.ExecuteSql(@$"DELETE FROM MarketingSchema.Users WHERE Id = {id}");

            if (success)
            {
                return Ok("User deleted successfully");
            }
            else
            {
                return BadRequest("Failed to delete user");
            }
        } catch (Exception e) {
            return BadRequest(e.Message);
        }
    }
}

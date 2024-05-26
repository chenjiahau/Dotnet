using Microsoft.AspNetCore.Mvc;
using DotnetAPI.Dots;
using DotnetAPI.Models;
using DotnetAPI.Data;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserEFController : ControllerBase
{
    DataContextEF _entityFramework;  

    public UserEFController(IConfiguration config)
    {
        _entityFramework = new DataContextEF(config);
    }

    [HttpGet("/EF/Users")]
    public IEnumerable<User> GetAll()
    {
        IEnumerable<User> users = _entityFramework.Users.ToList();
        return users;
    }

    [HttpGet("/EF/User/{id}")]
    public IActionResult GetById(int id)
    {
        try {
            User? user = _entityFramework.Users.Find(id);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        } catch (Exception e) {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("/EF/User")]
    public IActionResult Create(UserDots user)
    {
        User newUser = new User
        {
            Username = user.Username,
            Email = user.Email,
            Password = user.Password,
            Active = user.Active
        };

        _entityFramework.Users.Add(newUser);
        _entityFramework.SaveChanges();

        return Ok("User created successfully");
    }

    [HttpPut("/EF/User/{id}")]
    public IActionResult Update(int id, UserDots user)
    {
        try {
            User? existingUser = _entityFramework.Users.Find(id);

            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                existingUser.Active = user.Active;

                _entityFramework.SaveChanges();

                return Ok("User updated successfully");
            }
            else
            {
                return NotFound();
            }
        } catch (Exception e) {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("/EF/User/{id}")]
    public IActionResult Delete(int id)
    {
        try {
            User? existingUser = _entityFramework.Users.Find(id);

            if (existingUser != null)
            {
                _entityFramework.Users.Remove(existingUser);
                _entityFramework.SaveChanges();

                return Ok("User deleted successfully");
            }
            else
            {
                return NotFound();
            }
        } catch (Exception e) {
            return BadRequest(e.Message);
        }
    }
}

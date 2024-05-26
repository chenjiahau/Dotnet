namespace DotnetAPI.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool   Active { get; set; }
    public DateTime CreatedAt { get; set; }

    public User()
    {
        Id = 0;
        Username = "";
        Email = "";
        Password = "";
        Active = false;
        CreatedAt = DateTime.Now;
    }
}
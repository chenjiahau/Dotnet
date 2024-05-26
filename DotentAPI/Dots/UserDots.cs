namespace DotnetAPI.Data;

public class UserDots
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool   Active { get; set; }
    public DateTime CreatedAt { get; set; }

    public UserDots()
    {
        Username = "";
        Email = "";
        Password = "";
        Active = false;
        CreatedAt = DateTime.Now;
    }
}
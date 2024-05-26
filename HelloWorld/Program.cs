using System.Text.Json;
using HelloWorld.Models;

namespace HelloWorld;

class Program
{
    static void Main(string[] args)
    {
        string json = System.IO.File.ReadAllText("user.json");

        IEnumerable<User>? users = JsonSerializer.Deserialize<IEnumerable<User>>(json);

        if (users != null)
        {
            foreach (var user in users)
            {
                user.Slogan = "Hello, World!";
            }
        }

        var serializeOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string newJson = JsonSerializer.Serialize(users, serializeOptions);
        System.IO.File.WriteAllText("new_user.json", newJson);
    }
}
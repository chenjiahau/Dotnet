using System.Text.Json.Serialization;

namespace HelloWorld.Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("weight")]
        public double Weight { get; set; }

        [JsonPropertyName("height")]
        public double Height { get; set; }

        [JsonPropertyName("slogan")]
        public string Slogan { get; set; }

        public User(
          int id,
          string firstName, string lastName, string email, string gender, 
          int age, double weight, double height, string slogan
        ) {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Gender = gender;
            Age = age;
            Weight = weight;
            Height = height;
            Slogan = slogan;
        }
    }
}
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public class User
{
    private Guid _id;
    private string _username;
    private string _password;

    public User() { }

    public User(Guid id, string username, string password)
    {
        _id = id;
        _username = username;
        _password = password;
    }

    [JsonPropertyName("id")]
    [Key]
    public Guid Id { get => _id; set => _id = value; }

    [JsonPropertyName("username")]
    [Required(ErrorMessage = "Username is Required")]
    public string Username { get => _username; set => _username = value; }

    [JsonPropertyName("password")]
    public string Password { get => _password; set => _password = value; }
}

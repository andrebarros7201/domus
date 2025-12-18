using NCuid;

namespace Domus.API.Models;

public class User {

    public User() {
        CreatedAt = DateTime.UtcNow;
        Id = Cuid.Generate();
    }

    public string Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public ICollection<Property> Properties { get; set; } = new List<Property>();
}
using Domus.API.Enums;
using NCuid;

namespace Domus.API.Models;

public class Property {
    public Property() {
        Id = Cuid.Generate();
        CreatedAt = DateTime.UtcNow;
    }
    
    public string Id { get; set; }
    
    public string UserId { get; set; } = string.Empty;
    public User User { get; set; } = null!;
    
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int NumberRooms { get; set; }
    public PropertyStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
using Domus.API.Enums;

namespace Domus.API.DTOs.Property;

public class PropertyDto {
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; } 
    public int NumberRooms { get; set; }
    public string Location { get; set; } = string.Empty;
    public PropertyStatus Status { get; set; }
}
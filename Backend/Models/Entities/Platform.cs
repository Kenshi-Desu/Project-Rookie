using Backend.Model.Junctions;

namespace Backend.Model.Entities;

public class Platform
{   
    // PK
    public long Id { get; set; }

    // Data
    public required string LogoImageUrl { get; set; }
    public required string Name { get; set; }

    // Junction
    public ICollection<GameAvailablePlatform> AvailableForGames { get; set; } = new List<GameAvailablePlatform>();
}
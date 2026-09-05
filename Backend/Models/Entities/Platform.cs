using Backend.Model.Junctions;

namespace Backend.Model.Entities;

public class Platform
{
    public int Id { get; set; }
    public required string Name { get; set; }

    // Junctions
    public ICollection<GameAvailablePlatform> AvailableForGames { get; set; } = new List<GameAvailablePlatform>();
}
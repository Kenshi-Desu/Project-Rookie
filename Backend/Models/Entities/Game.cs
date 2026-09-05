using Backend.Model.Junctions;

namespace Backend.Model.Entities;

public class Game
{
    public int Id { get; set; }

    // Game Data
    public required string Logo { get; set; }
    public required string Name { get; set; }
    public required Company Developer { get; set; }
    public required string Engine { get; set; }

    // Junctions
    public ICollection<GameAvailablePlatform> AvailablePlatforms { get; set; } = new List<GameAvailablePlatform>();
}
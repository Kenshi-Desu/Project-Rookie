using Backend.Model.Junctions;

namespace Backend.Model.Entities;

public class Game
{
    // PK
    public long Id { get; set; }

    // FK
    public long DeveloperId { get; set; }
    public required Company Developer { get; set; }

    // Data
    public required string LogoImageUrl { get; set; }
    public required string HeroImageUrl { get; set; }
    public required string Name { get; set; }
    public required string Engine { get; set; }
    public required string Description { get; set; }

    // Junction
    public ICollection<GameAvailablePlatform> AvailablePlatforms { get; set; } = new List<GameAvailablePlatform>();

    // Relationships
    public ICollection<Character> Characters { get; set; } = new List<Character>();
    public ICollection<Weapon> Weapons { get; set; } = new List<Weapon>();
    public ICollection<Region> Regions { get; set; } = new List<Region>();
}
namespace Backend.Model.Entities;

public class Region
{
    // PK
    public long Id { get; set; }

    // FK
    public long GameId { get; set; }
    public required Game Game { get; set; }

    // Data
    public required string HeroImageUrl { get; set; }
    public required string LogoImageUrl { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    // Relationship
    public ICollection<Character> Characters { get; set; } = new List<Character>();
}
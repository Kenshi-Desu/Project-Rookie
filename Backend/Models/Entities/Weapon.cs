using Backend.Model.Junctions;

namespace Backend.Model.Entities;

public class Weapon
{  
    // PK
    public long Id { get; set; }
    
    // FK
    public long GameId { get; set; }
    public required Game Game { get; set; }
    public long? WielderId { get; set; }
    public Character? Wielder { get; set; }
    
    // Data
    public required string HeroImageUrl { get; set; }
    public required string Name { get; set; }
    public short MainStatus { get; set; }
    public short SubStatus { get; set; }

    // Relationship
    public ICollection<Character> Characters { get; set; } = new List<Character>();

    // Junction
    public ICollection<CharacterAlternativeWeapon> AlternativeForCharacters { get; set; } = new List<CharacterAlternativeWeapon>();
}
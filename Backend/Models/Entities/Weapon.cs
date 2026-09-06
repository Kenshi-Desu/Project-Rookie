using Backend.Model.Junctions;

namespace Backend.Model.Entities;

public class Weapon
{  
    // PK
    public long Id { get; set; }
    
    // FK
    public long GameId { get; set; }
    public required Game Game { get; set; }
    
    // Data
    public required string HeroImageUrl { get; set; }
    public required string Name { get; set; }
    public short MainStatus { get; set; }
    public short SubStatus { get; set; }

    // Junctions
    public ICollection<CharacterAlternativeWeapon> AlternativeForCharacters { get; set; } = new List<CharacterAlternativeWeapon>();
}
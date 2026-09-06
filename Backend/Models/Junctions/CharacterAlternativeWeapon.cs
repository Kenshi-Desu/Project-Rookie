using Backend.Model.Entities;

namespace Backend.Model.Junctions;

public class CharacterAlternativeWeapon
{   
    // FK
    public long CharacterId { get; set; }
    public required Character Character { get; set; }
    public long WeaponId { get; set; }
    public required Weapon Weapon { get; set; }

    // Data
    public required string PriorityTier { get; set; }
}
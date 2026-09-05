using Backend.Model.Entities;

namespace Backend.Model.Junctions;

public class CharacterAlternativeWeapon
{
    public int CharacterId { get; set; }
    public required Character Character { get; set; }

    public int WeaponId { get; set; }
    public required Weapon Weapon { get; set; }

    // Finalize the way to get data if foreign or enum
    // public required string PriorityTier { get; set; }
}
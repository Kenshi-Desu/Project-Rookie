using Backend.Model.Enums;
using Backend.Model.Junctions;

namespace Backend.Model.Entities;

public class Character
{
    // Id's
    public int Id { get; set; }

    // Personal Data
    public required string Name { get; set; }
    public required DateOnly BirthDate { get; set; }
    public required Gender Gender { get; set; } = Gender.Unknown;

    public int SignatureWeaponId { get; set; }
    public required Weapon SignatureWeapon { get; set; }

    // Junctions
    public ICollection<CharacterAlternativeWeapon> AlternativeWeapons { get; set; } = new List<CharacterAlternativeWeapon>();
}
using Backend.Model.Junctions;

namespace Backend.Model.Entities;

public class Weapon
{
    public int Id { get; set; }
    public required string Name { get; set; }

    // status
    public int MainStatus { get; set; }
    public int SubStatus { get; set; }

    // Junctions
    public ICollection<CharacterAlternativeWeapon> AlternativeForCharacters { get; set; } = new List<CharacterAlternativeWeapon>();
}
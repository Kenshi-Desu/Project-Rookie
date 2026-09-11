using Backend.Model.Enums;
using Backend.Model.Junctions;

namespace Backend.Model.Entities;

public class Character
{
    // PK
    public long Id { get; set; }

    // FK
    public long GameId { get; set; }
    public required Game Game { get; set; }
    public long? BirthPlaceId { get; set; }
    public required Region? BirthPlace { get; set; }
    public long? NationId { get; set; }
    public required Region? Nation { get; set; }

    // Data
    public required string AvatarImageUrl { get; set; }
    public required string HeroImageUrl { get; set; }
    public required string Name { get; set; }
    public required string RealName { get; set; }
    public required DateOnly BirthDate { get; set; }
    public required Gender Gender { get; set; } = Gender.Unknown;
    public required DateOnly ReleaseDate { get; set; }
    public required Weapon SignatureWeapon { get; set; }
    public required string Description { get; set; }

    // Junction
    public ICollection<CharacterAlternativeWeapon> AlternativeWeapons { get; set; } = new List<CharacterAlternativeWeapon>();
}
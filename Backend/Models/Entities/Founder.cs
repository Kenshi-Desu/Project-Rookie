using Backend.Model.Junctions;

namespace Backend.Model.Entities;

public class Founder
{
    // PK
    public long Id { get; set; }

    // Data
    public required string AvatarImageUrl { get; set; }
    public required string HeroImageUrl { get; set; }
    public required string Name { get; set; }

    // Junction
    public ICollection<CompanyFounder> Companies { get; set; } = new List<CompanyFounder>();
}

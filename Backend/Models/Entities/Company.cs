using Backend.Model.Junctions;

namespace Backend.Model.Entities;

public class Company
{
    // PK
    public long Id { get; set; }

    // Data
    public required string LogoImageUrl { get; set; }
    public required string Name { get; set; }
    public required string Headquarters { get; set; }
    public required string Description { get; set; }

    // Relationship
    public ICollection<Game> DevelopedGames { get; set; } = new List<Game>();

    // Junction
    public ICollection<CompanyFounder> Founders { get; set; } = new List<CompanyFounder>();
}
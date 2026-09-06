using Backend.Model.Entities;

namespace Backend.Model.Junctions;

public class CompanyFounder
{
    // FK
    public long FounderId { get; set; }
    public required Founder Founder { get; set; }
    public long CompanyId { get; set; }
    public required Company Company { get; set; }

    // Data
    public ushort FoundedYear { get; set; }
}

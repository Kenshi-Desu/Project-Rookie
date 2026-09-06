using Backend.Model.Entities;

namespace Backend.Model.Junctions;

public class GameAvailablePlatform
{
    // FK
    public long GameId { get; set; }
    public required Game Game { get; set; }
    public long PlatformId { get; set; }
    public required Platform Platform { get; set; }

    // Data
    public required DateOnly ReleaseDate { get; set; }
}
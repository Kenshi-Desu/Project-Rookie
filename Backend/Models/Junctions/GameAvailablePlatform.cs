using Backend.Model.Entities;

namespace Backend.Model.Junctions;

public class GameAvailablePlatform
{
    public int GameId { get; set; }
    public required Game Game { get; set; }
    public int PlatformId { get; set; }
    public required Platform Platform { get; set; }
}
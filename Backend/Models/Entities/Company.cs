namespace Backend.Model.Entities;

public class Company
{
    public int Id { get; set; }

    // Company Data
    public required string Logo { get; set; }
    public required string Name { get; set; }
    public required string Founded { get; set; }
    public required string Founders { get; set; }
    public required string Headquarters { get; set; }
    public required string Description { get; set; }
}
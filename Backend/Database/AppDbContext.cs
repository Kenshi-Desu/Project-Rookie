using Microsoft.EntityFrameworkCore;
using Backend.Model.Entities;
using Backend.Model.Junctions;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Founder> Founders => Set<Founder>();
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Platform> Platforms => Set<Platform>();
    public DbSet<Region> Regions => Set<Region>();
    public DbSet<Character> Characters => Set<Character>();
    public DbSet<Weapon> Weapons => Set<Weapon>();
    public DbSet<GameAvailablePlatform> GameAvailablePlatforms => Set<GameAvailablePlatform>();
    public DbSet<CharacterAlternativeWeapon> CharacterAlternativeWeapons => Set<CharacterAlternativeWeapon>();
    public DbSet<CompanyFounder> CompanyFounders => Set<CompanyFounder>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("public");

        modelBuilder.Entity<GameAvailablePlatform>()
            .HasKey(x => new { x.GameId, x.PlatformId });

        modelBuilder.Entity<CharacterAlternativeWeapon>()
            .HasKey(x => new { x.CharacterId, x.WeaponId });

        modelBuilder.Entity<CompanyFounder>()
            .HasKey(x => new { x.CompanyId, x.FounderId });

        modelBuilder.Entity<Game>()
            .HasOne(x => x.Developer)
            .WithMany(x => x.DevelopedGames)
            .HasForeignKey(x => x.DeveloperId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Character>()
            .HasOne(x => x.SignatureWeapon)
            .WithMany()
            .HasForeignKey(x => x.SignatureWeaponId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CompanyFounder>()
            .HasOne(x => x.Company)
            .WithMany(x => x.Founders)
            .HasForeignKey(x => x.CompanyId);

        modelBuilder.Entity<CompanyFounder>()
            .HasOne(x => x.Founder)
            .WithMany(x => x.Companies)
            .HasForeignKey(x => x.FounderId);
    }
}
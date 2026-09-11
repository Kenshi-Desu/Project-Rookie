using Microsoft.EntityFrameworkCore;

using Backend.Model.Entities;
using Backend.Model.Junctions;

// ++ ============================================= ++ \\
// ||  Refactor later on by separation of concerns  || \\
// ++ ============================================= ++ \\

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    // + -------------------------- + \\
    // |          ENTITIY           | \\
    // + -------------------------- + \\
    public DbSet<Character> Characters => Set<Character>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Founder> Founders => Set<Founder>();
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Platform> Platforms => Set<Platform>();
    public DbSet<Region> Regions => Set<Region>();
    public DbSet<Weapon> Weapons => Set<Weapon>();

    // + -------------------------- + \\
    // |          JUNCTION          | \\
    // + -------------------------- + \\
    public DbSet<CharacterAlternativeWeapon> CharacterAlternativeWeapons => Set<CharacterAlternativeWeapon>();
    public DbSet<CompanyFounder> CompanyFounders => Set<CompanyFounder>();
    public DbSet<GameAvailablePlatform> GameAvailablePlatforms => Set<GameAvailablePlatform>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("public");

        // + -------------------------- + \\
        // |          ENTITIY           | \\
        // + -------------------------- + \\

        // Company
        modelBuilder.Entity<Company>(company =>
        {
            company.HasKey(c => c.Id);
        });

        // Founder
        modelBuilder.Entity<Founder>(founder =>
        {
            founder.HasKey(f => f.Id);
        });

        // Platform
        modelBuilder.Entity<Platform>(platform =>
        {
            platform.HasKey(p => p.Id);
        });

        // Game
        modelBuilder.Entity<Game>(game =>
        {
            game.HasKey(g => g.Id);

            game.HasOne(g => g.Developer)
                .WithMany(c => c.DevelopedGames)
                .HasForeignKey(g => g.DeveloperId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Region
        modelBuilder.Entity<Region>(region =>
        {
            region.HasKey(r => r.Id);

            region.HasOne(r => r.Game)
                .WithMany(g => g.Regions)
                .HasForeignKey(r => r.GameId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Character
        modelBuilder.Entity<Character>(character =>
        {
            character.HasKey(c => c.Id); 
            
            character.HasOne(c => c.Game)
                .WithMany(g => g.Characters)
                .HasForeignKey(c => c.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            character.HasOne(c => c.BirthPlace)
                .WithMany(r => r.Characters)
                .HasForeignKey(c => c.BirthPlaceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                
            character.HasOne(c => c.Nation)
                .WithMany(r => r.Characters)
                .HasForeignKey(c => c.NationId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        // Weapon
        modelBuilder.Entity<Weapon>(weapon =>
        {
            weapon.HasKey(w => w.Id); 

            weapon.HasOne(w => w.Game)
                .WithMany(g => g.Weapons)
                .HasForeignKey(w => w.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            weapon.HasOne(w => w.Wielder)
                .WithOne(c => c.SignatureWeapon)
                .HasForeignKey<Weapon>(w => w.WielderId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // + -------------------------- + \\
        // |          JUNCTION          | \\
        // + -------------------------- + \\

        modelBuilder.Entity<GameAvailablePlatform>()
            .HasKey(x => new { x.GameId, x.PlatformId });

        modelBuilder.Entity<CharacterAlternativeWeapon>()
            .HasKey(x => new { x.CharacterId, x.WeaponId });

        modelBuilder.Entity<CompanyFounder>()
            .HasKey(x => new { x.CompanyId, x.FounderId });
    }
}
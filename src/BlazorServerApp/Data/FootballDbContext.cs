using BlazorServerApp.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BlazorServerApp.Data;

public partial class FootballDbContext : DbContext
{
    public FootballDbContext()
    {
    }

    public FootballDbContext(DbContextOptions<FootballDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Match> Matches { get; set; }
    public virtual DbSet<Player> Players { get; set; }
    public virtual DbSet<Position> Positions { get; set; }
    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasOne(d => d.Team1Navigation)
                .WithMany(p => p.MatchTeam1Navigations)
                .HasForeignKey(d => d.Team1)
                .HasConstraintName("FK_Matches_Team1_Teams_Id");

            entity.HasOne(d => d.Team2Navigation)
                .WithMany(p => p.MatchTeam2Navigations)
                .HasForeignKey(d => d.Team2)
                .HasConstraintName("FK_Matches_Team2_Teams_Id");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Position)
                .WithMany(p => p.Players)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK_Players_Positions");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.Property(e => e.Logo).HasMaxLength(50);

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

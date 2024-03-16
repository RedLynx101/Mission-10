using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission10API.Models;

public partial class BowlingLeagueContext : DbContext
{
    public BowlingLeagueContext()
    {
    }

    public BowlingLeagueContext(DbContextOptions<BowlingLeagueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bowler> Bowlers { get; set; }

    public virtual DbSet<BowlerScore> BowlerScores { get; set; }

    public virtual DbSet<MatchGame> MatchGames { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<Tournament> Tournaments { get; set; }

    public virtual DbSet<TourneyMatch> TourneyMatches { get; set; }

    public virtual DbSet<ZtblBowlerRating> ZtblBowlerRatings { get; set; }

    public virtual DbSet<ZtblSkipLabel> ZtblSkipLabels { get; set; }

    public virtual DbSet<ZtblWeek> ZtblWeeks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=BowlingLeague.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bowler>(entity =>
        {
            entity.HasIndex(e => e.BowlerLastName, "BowlerLastName");

            entity.HasIndex(e => e.TeamId, "BowlersTeamID");

            entity.Property(e => e.BowlerId)
                .HasColumnType("INT")
                .HasColumnName("BowlerID");
            entity.Property(e => e.BowlerAddress).HasColumnType("nvarchar (50)");
            entity.Property(e => e.BowlerCity).HasColumnType("nvarchar (50)");
            entity.Property(e => e.BowlerFirstName).HasColumnType("nvarchar (50)");
            entity.Property(e => e.BowlerLastName).HasColumnType("nvarchar (50)");
            entity.Property(e => e.BowlerMiddleInit).HasColumnType("nvarchar (1)");
            entity.Property(e => e.BowlerPhoneNumber).HasColumnType("nvarchar (14)");
            entity.Property(e => e.BowlerState).HasColumnType("nvarchar (2)");
            entity.Property(e => e.BowlerZip).HasColumnType("nvarchar (10)");
            entity.Property(e => e.TeamId)
                .HasColumnType("INT")
                .HasColumnName("TeamID");

            entity.HasOne(d => d.Team).WithMany(p => p.Bowlers).HasForeignKey(d => d.TeamId);
        });

        modelBuilder.Entity<BowlerScore>(entity =>
        {
            entity.HasKey(e => new { e.MatchId, e.GameNumber, e.BowlerId });

            entity.ToTable("Bowler_Scores");

            entity.HasIndex(e => e.BowlerId, "BowlerID");

            entity.HasIndex(e => new { e.MatchId, e.GameNumber }, "MatchGamesBowlerScores");

            entity.Property(e => e.MatchId)
                .HasColumnType("INT")
                .HasColumnName("MatchID");
            entity.Property(e => e.GameNumber).HasColumnType("smallint");
            entity.Property(e => e.BowlerId)
                .HasColumnType("INT")
                .HasColumnName("BowlerID");
            entity.Property(e => e.HandiCapScore)
                .HasDefaultValue((short)0)
                .HasColumnType("smallint");
            entity.Property(e => e.RawScore)
                .HasDefaultValue((short)0)
                .HasColumnType("smallint");
            entity.Property(e => e.WonGame).HasColumnType("bit");

            entity.HasOne(d => d.Bowler).WithMany(p => p.BowlerScores)
                .HasForeignKey(d => d.BowlerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<MatchGame>(entity =>
        {
            entity.HasKey(e => new { e.MatchId, e.GameNumber });

            entity.ToTable("Match_Games");

            entity.HasIndex(e => e.WinningTeamId, "Team1ID");

            entity.HasIndex(e => e.MatchId, "TourneyMatchesMatchGames");

            entity.Property(e => e.MatchId)
                .HasColumnType("INT")
                .HasColumnName("MatchID");
            entity.Property(e => e.GameNumber).HasColumnType("smallint");
            entity.Property(e => e.WinningTeamId)
                .HasDefaultValue(0)
                .HasColumnType("INT")
                .HasColumnName("WinningTeamID");

            entity.HasOne(d => d.Match).WithMany(p => p.MatchGames)
                .HasForeignKey(d => d.MatchId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasIndex(e => e.TeamId, "TeamID").IsUnique();

            entity.Property(e => e.TeamId)
                .HasColumnType("INT")
                .HasColumnName("TeamID");
            entity.Property(e => e.CaptainId)
                .HasColumnType("INT")
                .HasColumnName("CaptainID");
            entity.Property(e => e.TeamName).HasColumnType("nvarchar (50)");
        });

        modelBuilder.Entity<Tournament>(entity =>
        {
            entity.HasKey(e => e.TourneyId);

            entity.Property(e => e.TourneyId)
                .HasColumnType("INT")
                .HasColumnName("TourneyID");
            entity.Property(e => e.TourneyDate).HasColumnType("date");
            entity.Property(e => e.TourneyLocation).HasColumnType("nvarchar (50)");
        });

        modelBuilder.Entity<TourneyMatch>(entity =>
        {
            entity.HasKey(e => e.MatchId);

            entity.ToTable("Tourney_Matches");

            entity.HasIndex(e => e.OddLaneTeamId, "TourneyMatchesOdd");

            entity.HasIndex(e => e.TourneyId, "TourneyMatchesTourneyID");

            entity.HasIndex(e => e.EvenLaneTeamId, "Tourney_MatchesEven");

            entity.Property(e => e.MatchId)
                .HasColumnType("INT")
                .HasColumnName("MatchID");
            entity.Property(e => e.EvenLaneTeamId)
                .HasDefaultValue(0)
                .HasColumnType("INT")
                .HasColumnName("EvenLaneTeamID");
            entity.Property(e => e.Lanes).HasColumnType("nvarchar (5)");
            entity.Property(e => e.OddLaneTeamId)
                .HasDefaultValue(0)
                .HasColumnType("INT")
                .HasColumnName("OddLaneTeamID");
            entity.Property(e => e.TourneyId)
                .HasDefaultValue(0)
                .HasColumnType("INT")
                .HasColumnName("TourneyID");

            entity.HasOne(d => d.EvenLaneTeam).WithMany(p => p.TourneyMatchEvenLaneTeams).HasForeignKey(d => d.EvenLaneTeamId);

            entity.HasOne(d => d.OddLaneTeam).WithMany(p => p.TourneyMatchOddLaneTeams).HasForeignKey(d => d.OddLaneTeamId);

            entity.HasOne(d => d.Tourney).WithMany(p => p.TourneyMatches).HasForeignKey(d => d.TourneyId);
        });

        modelBuilder.Entity<ZtblBowlerRating>(entity =>
        {
            entity.HasKey(e => e.BowlerRating);

            entity.ToTable("ztblBowlerRatings");

            entity.Property(e => e.BowlerRating).HasColumnType("nvarchar (15)");
            entity.Property(e => e.BowlerHighAvg).HasColumnType("smallint");
            entity.Property(e => e.BowlerLowAvg).HasColumnType("smallint");
        });

        modelBuilder.Entity<ZtblSkipLabel>(entity =>
        {
            entity.HasKey(e => e.LabelCount);

            entity.ToTable("ztblSkipLabels");

            entity.Property(e => e.LabelCount)
                .ValueGeneratedNever()
                .HasColumnType("INT");
        });

        modelBuilder.Entity<ZtblWeek>(entity =>
        {
            entity.HasKey(e => e.WeekStart);

            entity.ToTable("ztblWeeks");

            entity.Property(e => e.WeekStart).HasColumnType("date");
            entity.Property(e => e.WeekEnd).HasColumnType("date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

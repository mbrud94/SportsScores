using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportsScoresAPI.Models;
using SportsScoresAPI.Models.Entities;

namespace SportsScoresAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TeamEntity>()
                .HasMany(t => t.HomeGames)
                .WithOne(g => g.HomeTeam)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TeamEntity>()
                .HasMany(t => t.AwayGames)
                .WithOne(g => g.AwayTeam)
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<CompetitionEntity> Competitions { get; set; }
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<GameEventEntity> GameEvents { get; set; }
        public DbSet<GameSquadAssignmentEntity> GameSquadAssignments { get; set; }
        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<PlayerToTeamAssignmentEntity> PlayerToTeamAssignments { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<TeamToCompetitionAssignmentEntity> TeamToCompetitionAssignments { get; set; }
        public DbSet<NationalityEntity> Nationalities { get; set; }
        public DbSet<PlayerPositionEntity> PlayerPositions { get; set; }
    }
}

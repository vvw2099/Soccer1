using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Soccer.Web.Data.Entities;

namespace Soccer.Web.Data
{
    public class DataContex: DbContext
    {
        public DataContex(DbContextOptions<DataContex> options):base(options)
        {

        }

        public DbSet<GroupDetailEntity> GroupDetails { get; set; }

        public DbSet<GroupEntity> Groups { get; set; }

        public DbSet<MatchEntity> Matches { get; set; }

        
        public DbSet<TeamEntity> Teams { get; set; }

        public DbSet<TournamentEntity> Tournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeamEntity>()
                .HasIndex(t => t.Name)
                .IsUnique();
        }

    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZPP_aplikacja_internetowa.Data.DatabaseModels;

namespace ZPP_aplikacja_internetowa.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<GameUser> GameUsers { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<GameStatus> GameStatuses { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<GameUser>()
                        .HasKey(x => new {x.UserId });
                        //.HasKey(x => new { x.GameId, x.UserId });

            builder.Entity<GameUser>()
               .HasOne(x => x.User)
               .WithMany(x => x.Games)
               .HasForeignKey(x => x.UserId);

            builder.Entity<GameUser>()
               .HasOne(x => x.Game)
               .WithMany(x => x.Players)
               .HasForeignKey(x => x.GameId);

            builder.Entity<Map>()
                .HasMany(x => x.Games)
                .WithOne(x => x.Map)
                .HasForeignKey(x => x.MapId);

            builder.Entity<Game>()
                .HasOne(x => x.GameStatuses)
                .WithMany(x => x.Games)
                .HasForeignKey(x => x.GameStatusId);

            builder.Entity<GameStatus>()
                .HasData(
                new GameStatus{GameStatusId = 1, StatusName = "Started" },
                new GameStatus{GameStatusId = 2, StatusName = "Ended" });
            builder.Entity<Map>()
                .HasData(
                new Map { MapId = 1, Name = "Dust2" }
                );
        }
    }
}
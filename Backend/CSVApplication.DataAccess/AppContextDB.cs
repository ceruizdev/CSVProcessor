using CSVApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSVApplication.DataAccess
{
    public class AppContextDB : DbContext
    {

        public DbSet<CSVBodyEntity> CSVBody { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public AppContextDB(DbContextOptions<AppContextDB> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CSVBodyEntity>().ToTable("CSVBody");
            modelBuilder.Entity<UserEntity>().ToTable("User");
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity[] {
                    new UserEntity{
                        Email = "admin@test.com",
                        Id = Guid.NewGuid(),
                        Name = "Administrator",
                        Password = "Test123",
                        Role = "Administrator",
                        Surname = "",
                        UserName = "Administrator"
                    },
                    new UserEntity{
                        Email = "carlos@test.com",
                        Id = Guid.NewGuid(),
                        Name = "Carlos",
                        Password = "Test321",
                        Role = "Standard",
                        Surname = "Ruiz",
                        UserName = "carlos93"
                    },
                }
           );
        }



    }
}
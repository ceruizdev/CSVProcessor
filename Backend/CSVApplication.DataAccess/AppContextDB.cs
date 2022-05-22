using CSVApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSVApplication.DataAccess
{
    public class AppContextDB: DbContext
    {

        public DbSet<CSVBodyEntity> CSVBody { get; set; }
        public AppContextDB(DbContextOptions<AppContextDB> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CSVBodyEntity>().ToTable("CSVBody");
        }


       
    }
}
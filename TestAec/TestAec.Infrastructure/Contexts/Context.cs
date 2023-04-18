using Microsoft.EntityFrameworkCore;
using TestAec.Domain.AggregatesModel;
using TestAec.Infrastructure.EntityConfigurations;

namespace TestAec.Infrastructure.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Card> Cards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseLazyLoadingProxies(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Schema
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.ApplyConfiguration(new CardEntityTypeConfiguration());

        }

    }
}

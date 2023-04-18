using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TestAec.Infrastructure.Contexts;

namespace TestAec.Infrastructure.Factories
{
    public class TestAecDbContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<Context> builder = new DbContextOptionsBuilder<Context>();
            builder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=DB_Automacao;TrustServerCertificate=true;User ID=sa;Password=senha@1234",
                x => x.MigrationsHistoryTable("__MigrationsHistory", "dbo")
                .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));

            return new Context(builder.Options);
        }
    }
}

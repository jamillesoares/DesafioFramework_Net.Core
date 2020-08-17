using Framework.Desafio.Repository.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Framework.Desafio.Repository
{
    public class FabricaPersisteContexto : IDesignTimeDbContextFactory<AppDbContext>
    {
        private const string ConnectionString = "server=127.0.0.1;port=3306;database=Framework;uid=root;password=admin";

        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(ConnectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}

using DeslocamentoAPI.Data.Mapping;
using DeslocamentoAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeslocamentoAPI.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opcoes)
            : base(opcoes)
        {

        }

        public ApplicationDbContext()
        {
        }

        public DbSet<Carro> Carros { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Condutor> Condutores { get; set; }

        public DbSet<Deslocamento> Deslocamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Carro>(new CarroConfiguration().Configure);
            modelBuilder.Entity<Cliente>(new ClienteConfiguration().Configure);
            modelBuilder.Entity<Condutor>(new CondutorConfiguration().Configure);
            modelBuilder.Entity<Deslocamento>(new DeslocamentoConfiguration().Configure);

        }

    }
}
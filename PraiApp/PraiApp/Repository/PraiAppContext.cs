using Microsoft.EntityFrameworkCore;
using PraiApp.Models;

namespace PraiApp.Repository
{
    public class PraiAppContext : DbContext
    {
        public PraiAppContext(DbContextOptions<PraiAppContext> options) : base(options)
        {
        }

        public DbSet<EnderecoModel> EnderecoModel { get; set; }
        public DbSet<ResponsavelModel> ResponsavelModel { get; set; }
        public DbSet<OrganizacaoModel> OrganizacaoModel { get; set; }
        public DbSet<UserModel> UserModel { get; set; }
        public DbSet<PraiaModel> PraiaModel { get; set; }
        public DbSet<AvaliacaoModel> AvaliacaoModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}

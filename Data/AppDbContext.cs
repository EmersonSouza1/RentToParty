
using Microsoft.EntityFrameworkCore;
using RentToParty.Model;

namespace RentToParty.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<PessoaModel> Pessoas { get; set; }

        public DbSet<EnderecoModel> Enderecos { get; set; }

        public DbSet<ImovelModel> Imoveis { get; set; }

        public DbSet<LocacaoModel> Locacoes { get; set; }

        public DbSet<DisponibilidadeModel> Disponibilidade { get; set; }

        public DbSet<Carac_ImovelModel> Carac_Imovel { get; set; }

        public DbSet<CaracteristicaModel> Caracteristicas { get; set; }

        public DbSet<Excessao_DispoModel> Excessao_Dispo { get; set; }

        public DbSet<PrecoModel> Preco { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
        
    }

}
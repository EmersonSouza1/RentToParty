﻿
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
        
    }

}
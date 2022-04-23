﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentToParty.Data;

namespace RentToParty.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("RentToParty.Model.DisponibilidadeModel", b =>
                {
                    b.Property<int>("IdDisponibilidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiaDaSemana")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("HoraFinal")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdImovel")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdDisponibilidade");

                    b.HasIndex("IdImovel");

                    b.ToTable("Disponibilidade");
                });

            modelBuilder.Entity("RentToParty.Model.EnderecoModel", b =>
                {
                    b.Property<int>("IdEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cep")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cidade")
                        .HasColumnType("TEXT");

                    b.Property<string>("Complemento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Logradouro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Numero")
                        .HasColumnType("TEXT");

                    b.HasKey("IdEndereco");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("RentToParty.Model.ImovelModel", b =>
                {
                    b.Property<int>("IdIMovel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProprietario")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProprietarioIdPessoa")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("enderecoIdEndereco")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdIMovel");

                    b.HasIndex("ProprietarioIdPessoa");

                    b.HasIndex("enderecoIdEndereco");

                    b.ToTable("Imovel");
                });

            modelBuilder.Entity("RentToParty.Model.LocacaoModel", b =>
                {
                    b.Property<int>("IdLocacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DtaFimLocacao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DtainicioLocacao")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdImovel")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdLocatario")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LocatarioIdPessoa")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Valor")
                        .HasColumnType("TEXT");

                    b.HasKey("IdLocacao");

                    b.HasIndex("IdImovel");

                    b.HasIndex("LocatarioIdPessoa");

                    b.ToTable("Locacao");
                });

            modelBuilder.Entity("RentToParty.Model.PessoaModel", b =>
                {
                    b.Property<int>("IdPessoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF_CNPJ")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DtaNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("IdPessoa");

                    b.HasIndex("IdEndereco");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("RentToParty.Model.DisponibilidadeModel", b =>
                {
                    b.HasOne("RentToParty.Model.ImovelModel", "Imovel")
                        .WithMany()
                        .HasForeignKey("IdImovel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imovel");
                });

            modelBuilder.Entity("RentToParty.Model.ImovelModel", b =>
                {
                    b.HasOne("RentToParty.Model.PessoaModel", "Proprietario")
                        .WithMany()
                        .HasForeignKey("ProprietarioIdPessoa");

                    b.HasOne("RentToParty.Model.EnderecoModel", "endereco")
                        .WithMany()
                        .HasForeignKey("enderecoIdEndereco");

                    b.Navigation("endereco");

                    b.Navigation("Proprietario");
                });

            modelBuilder.Entity("RentToParty.Model.LocacaoModel", b =>
                {
                    b.HasOne("RentToParty.Model.ImovelModel", "Imovel")
                        .WithMany()
                        .HasForeignKey("IdImovel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentToParty.Model.PessoaModel", "Locatario")
                        .WithMany()
                        .HasForeignKey("LocatarioIdPessoa");

                    b.Navigation("Imovel");

                    b.Navigation("Locatario");
                });

            modelBuilder.Entity("RentToParty.Model.PessoaModel", b =>
                {
                    b.HasOne("RentToParty.Model.EnderecoModel", "Endereco")
                        .WithMany()
                        .HasForeignKey("IdEndereco")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });
#pragma warning restore 612, 618
        }
    }
}

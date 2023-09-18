﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrevisaoClimatica.Api.Data;

#nullable disable

namespace PrevisaoClimatica.Api.Migrations
{
    [DbContext(typeof(PrevisaoClimaticaContext))]
    [Migration("20230918125944_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PrevisaoClimatica.Api.Models.AeroportoPrevisao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodigoIcao")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Condicao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("DescricaoClima")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("DirecaoVento")
                        .HasColumnType("int");

                    b.Property<int>("PressaoAtmosferica")
                        .HasColumnType("int");

                    b.Property<int>("Tempo")
                        .HasColumnType("int");

                    b.Property<DateTime>("UltimaAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Umidade")
                        .HasColumnType("int");

                    b.Property<int>("Vento")
                        .HasColumnType("int");

                    b.Property<string>("Visibilidade")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("AeroportoPrevisao", (string)null);
                });

            modelBuilder.Entity("PrevisaoClimatica.Api.Models.CidadePrevisao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Condicao")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescricaoClima")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<int>("IndiceUV")
                        .HasColumnType("int");

                    b.Property<int>("Max")
                        .HasColumnType("int");

                    b.Property<int>("Min")
                        .HasColumnType("int");

                    b.Property<DateTime>("UltimaAtualizacao")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CidadePrevisao", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}

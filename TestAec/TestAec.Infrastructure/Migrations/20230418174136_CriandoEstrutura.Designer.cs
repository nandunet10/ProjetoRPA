﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestAec.Infrastructure.Contexts;

#nullable disable

namespace TestAec.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230418174136_CriandoEstrutura")]
    partial class CriandoEstrutura
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestAec.Domain.AggregatesModel.Card", b =>
                {
                    b.Property<Guid>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("cardId");

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("area");

                    b.Property<string>("Autor")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("autor");

                    b.Property<DateTime>("DataPublicacao")
                        .HasColumnType("Date")
                        .HasColumnName("dataPublicao");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("descricao");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("titulo");

                    b.HasKey("CardId");

                    b.ToTable("Cards", "dbo");
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ventasPymes.api.Data;

#nullable disable

namespace ventasPymes.api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ventasPymes.api.Model.Enums.Nomenclador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("boolean");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NomencladorPadreId")
                        .HasColumnType("integer");

                    b.Property<int>("Orden")
                        .HasColumnType("integer");

                    b.Property<bool>("ReadOnly")
                        .HasColumnType("boolean");

                    b.Property<bool>("Visible")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("NomencladorPadreId");

                    b.ToTable("Nomencladores");
                });

            modelBuilder.Entity("ventasPymes.api.Model.Enums.Nomenclador", b =>
                {
                    b.HasOne("ventasPymes.api.Model.Enums.Nomenclador", "NomencladorPadre")
                        .WithMany()
                        .HasForeignKey("NomencladorPadreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NomencladorPadre");
                });
#pragma warning restore 612, 618
        }
    }
}

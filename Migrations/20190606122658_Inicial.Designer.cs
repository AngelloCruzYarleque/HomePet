﻿// <auto-generated />
using HomePet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomePet.Migrations
{
    [DbContext(typeof(PetDbContext))]
    [Migration("20190606122658_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HomePet.Models.Mascota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Edad")
                        .IsRequired();

                    b.Property<string>("Foto");

                    b.Property<string>("Nombre")
                        .IsRequired();

                    b.Property<float>("Peso");

                    b.Property<string>("Sexo")
                        .IsRequired();

                    b.Property<string>("Tamano")
                        .IsRequired();

                    b.Property<string>("TipoPelo")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Mascotas");
                });
#pragma warning restore 612, 618
        }
    }
}

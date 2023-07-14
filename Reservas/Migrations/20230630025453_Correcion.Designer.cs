﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservas.BData;

#nullable disable

namespace Reservas.BData.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230630025453_Correcion")]
    partial class Correcion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Reservas.BData.Data.Entity.Habitacion", b =>
                {
                    b.Property<int>("Nhab")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Nhab"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("Decimal(10,2)");

                    b.Property<int?>("ReservaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Senia")
                        .HasColumnType("Decimal(10,2)");

                    b.Property<int>("camas")
                        .HasColumnType("int");

                    b.HasKey("Nhab");

                    b.HasIndex("ReservaId");

                    b.ToTable("Habitaciones");

                    b.HasData(
                        new
                        {
                            Nhab = 1,
                            Estado = "Reservada",
                            Precio = 200m,
                            Senia = 30m,
                            camas = 20
                        });
                });

            modelBuilder.Entity("Reservas.BData.Data.Entity.Huespedes", b =>
                {
                    b.Property<string>("DNI")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Num_Hab")
                        .HasColumnType("int");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.Property<bool>("checking")
                        .HasMaxLength(30)
                        .HasColumnType("bit");

                    b.HasKey("DNI");

                    b.HasIndex(new[] { "DNI" }, "Huespedes_DNI_UQ")
                        .IsUnique();

                    b.ToTable("Huesped");
                });

            modelBuilder.Entity("Reservas.BData.Data.Entity.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("NumTarjeta")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("ReservaId")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("ReservaId");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("Reservas.BData.Data.Entity.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DNI")
                        .HasColumnType("int");

                    b.Property<int>("Nhab")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha_fin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fecha_inicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("idPersona")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "Id_Reserva_UQ")
                        .IsUnique();

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Reservas.BData.Data.Entity.Habitacion", b =>
                {
                    b.HasOne("Reservas.BData.Data.Entity.Reserva", null)
                        .WithMany("habitaciones")
                        .HasForeignKey("ReservaId");
                });

            modelBuilder.Entity("Reservas.BData.Data.Entity.Persona", b =>
                {
                    b.HasOne("Reservas.BData.Data.Entity.Reserva", null)
                        .WithMany("personas")
                        .HasForeignKey("ReservaId");
                });

            modelBuilder.Entity("Reservas.BData.Data.Entity.Reserva", b =>
                {
                    b.Navigation("habitaciones");

                    b.Navigation("personas");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RubSort.DataStorageSystem;

namespace RubSort.DataStorageSystem.SqlMigrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200528025306_FixRecyclingPointCoordinates")]
    partial class FixRecyclingPointCoordinates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("RubSort.DataStorageSystem.Dbo.RecyclingPointDbo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AddressAddressLine")
                        .HasColumnType("text");

                    b.Property<string>("AddressCity")
                        .HasColumnType("text");

                    b.Property<string>("AddressCountry")
                        .HasColumnType("text");

                    b.Property<string>("ContactsEmail")
                        .HasColumnType("text");

                    b.Property<string>("ContactsTelephone")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RecyclingPoints");
                });

            modelBuilder.Entity("RubSort.DataStorageSystem.Dbo.UserDbo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RubSort.DataStorageSystem.Dbo.RecyclingPointDbo", b =>
                {
                    b.OwnsOne("RubSort.DataStorageSystem.Dbo.GeoCoordinateDbo", "GeoCoordinate", b1 =>
                        {
                            b1.Property<long>("RecyclingPointDboId")
                                .HasColumnType("bigint");

                            b1.Property<double?>("Latitude")
                                .HasColumnType("double precision");

                            b1.Property<double?>("Longitude")
                                .HasColumnType("double precision");

                            b1.HasKey("RecyclingPointDboId");

                            b1.ToTable("RecyclingPoints");

                            b1.WithOwner()
                                .HasForeignKey("RecyclingPointDboId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
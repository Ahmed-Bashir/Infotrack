﻿// <auto-generated />
using Infotrack.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infotrack.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210124170704_InitalMigration")]
    partial class InitalMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Infotrack.Models.Hit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Keywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ScrapeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ScrapeId");

                    b.ToTable("Hits");
                });

            modelBuilder.Entity("Infotrack.Models.Scrape", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SearchEngineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SearchEngineId");

                    b.ToTable("Scrapes");
                });

            modelBuilder.Entity("Infotrack.Models.SearchEngine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SearchEngines");
                });

            modelBuilder.Entity("Infotrack.Models.Hit", b =>
                {
                    b.HasOne("Infotrack.Models.Scrape", "Scrape")
                        .WithMany("Hits")
                        .HasForeignKey("ScrapeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Scrape");
                });

            modelBuilder.Entity("Infotrack.Models.Scrape", b =>
                {
                    b.HasOne("Infotrack.Models.SearchEngine", "SearchEngine")
                        .WithMany("Scrapes")
                        .HasForeignKey("SearchEngineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SearchEngine");
                });

            modelBuilder.Entity("Infotrack.Models.Scrape", b =>
                {
                    b.Navigation("Hits");
                });

            modelBuilder.Entity("Infotrack.Models.SearchEngine", b =>
                {
                    b.Navigation("Scrapes");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using HobbyPrinterApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HobbyPrinterApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230426125049_First Setup")]
    partial class FirstSetup
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HobbyPrinterApi.Models.Hobby", b =>
                {
                    b.Property<int>("HobbyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HobbyID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FK_PeopleID")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisteredDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("HobbyID");

                    b.HasIndex("FK_PeopleID");

                    b.ToTable("Hobbys");
                });

            modelBuilder.Entity("HobbyPrinterApi.Models.Link", b =>
                {
                    b.Property<int>("LinkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LinkID"));

                    b.Property<int>("FK_HobbyID")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LinkID");

                    b.HasIndex("FK_HobbyID");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("HobbyPrinterApi.Models.People", b =>
                {
                    b.Property<int>("PeopleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PeopleID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PersonNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisteredDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PeopleID");

                    b.ToTable("People");
                });

            modelBuilder.Entity("HobbyPrinterApi.Models.Hobby", b =>
                {
                    b.HasOne("HobbyPrinterApi.Models.People", "Peoples")
                        .WithMany("Hobbys")
                        .HasForeignKey("FK_PeopleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Peoples");
                });

            modelBuilder.Entity("HobbyPrinterApi.Models.Link", b =>
                {
                    b.HasOne("HobbyPrinterApi.Models.Hobby", "Hobbys")
                        .WithMany("Links")
                        .HasForeignKey("FK_HobbyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hobbys");
                });

            modelBuilder.Entity("HobbyPrinterApi.Models.Hobby", b =>
                {
                    b.Navigation("Links");
                });

            modelBuilder.Entity("HobbyPrinterApi.Models.People", b =>
                {
                    b.Navigation("Hobbys");
                });
#pragma warning restore 612, 618
        }
    }
}

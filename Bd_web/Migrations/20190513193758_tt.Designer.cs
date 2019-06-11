﻿// <auto-generated />
using System;
using Bd_web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bd_web.Migrations
{
    [DbContext(typeof(Context_app))]
    [Migration("20190513193758_tt")]
    partial class tt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bd_web.Models.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres");

                    b.Property<string>("Name_club");

                    b.Property<int>("Row");

                    b.Property<int>("Seat");

                    b.Property<int>("Sector");

                    b.HasKey("Id");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("Bd_web.Models.Club_Sponsor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SponsorId");

                    b.Property<int?>("clubId");

                    b.HasKey("Id");

                    b.HasIndex("SponsorId");

                    b.HasIndex("clubId");

                    b.ToTable("Club_Sponsors");
                });

            modelBuilder.Entity("Bd_web.Models.Footballer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Amplya");

                    b.Property<string>("Name");

                    b.Property<int?>("clubId");

                    b.HasKey("Id");

                    b.HasIndex("clubId");

                    b.ToTable("Footballers");
                });

            modelBuilder.Entity("Bd_web.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Club_gameId");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Name_M");

                    b.Property<string>("Ticet_string");

                    b.HasKey("Id");

                    b.HasIndex("Club_gameId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Bd_web.Models.People", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("personalEnumId");

                    b.HasKey("Id");

                    b.HasIndex("personalEnumId");

                    b.ToTable("Peoples");
                });

            modelBuilder.Entity("Bd_web.Models.PersonalEnum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Proffesion");

                    b.HasKey("Id");

                    b.ToTable("PersonalEnums");
                });

            modelBuilder.Entity("Bd_web.Models.Profit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("Money_p");

                    b.Property<string>("Name_P");

                    b.Property<int?>("ShopeTypeId");

                    b.Property<int?>("clubId");

                    b.HasKey("Id");

                    b.HasIndex("ShopeTypeId");

                    b.HasIndex("clubId");

                    b.ToTable("Profits");
                });

            modelBuilder.Entity("Bd_web.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("Bd_web.Models.Sponsor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Sponsors");
                });

            modelBuilder.Entity("Bd_web.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date_t");

                    b.Property<int?>("Match_TId");

                    b.Property<string>("Name_T");

                    b.Property<int>("position");

                    b.Property<int>("row");

                    b.Property<string>("sector");

                    b.HasKey("Id");

                    b.HasIndex("Match_TId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Bd_web.Models.Сosts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("Money_C");

                    b.Property<string>("Name_C");

                    b.Property<int?>("ShopeTypeId");

                    b.Property<int?>("clubId");

                    b.HasKey("Id");

                    b.HasIndex("ShopeTypeId");

                    b.HasIndex("clubId");

                    b.ToTable("Costs_s");
                });

            modelBuilder.Entity("Bd_web.Models.Club_Sponsor", b =>
                {
                    b.HasOne("Bd_web.Models.Sponsor", "Sponsor")
                        .WithMany()
                        .HasForeignKey("SponsorId");

                    b.HasOne("Bd_web.Models.Club", "club")
                        .WithMany()
                        .HasForeignKey("clubId");
                });

            modelBuilder.Entity("Bd_web.Models.Footballer", b =>
                {
                    b.HasOne("Bd_web.Models.Club", "club")
                        .WithMany("Footballers")
                        .HasForeignKey("clubId");
                });

            modelBuilder.Entity("Bd_web.Models.Match", b =>
                {
                    b.HasOne("Bd_web.Models.Club", "Club_game")
                        .WithMany()
                        .HasForeignKey("Club_gameId");
                });

            modelBuilder.Entity("Bd_web.Models.People", b =>
                {
                    b.HasOne("Bd_web.Models.PersonalEnum", "personalEnum")
                        .WithMany()
                        .HasForeignKey("personalEnumId");
                });

            modelBuilder.Entity("Bd_web.Models.Profit", b =>
                {
                    b.HasOne("Bd_web.Models.Shop", "ShopeType")
                        .WithMany()
                        .HasForeignKey("ShopeTypeId");

                    b.HasOne("Bd_web.Models.Club", "club")
                        .WithMany()
                        .HasForeignKey("clubId");
                });

            modelBuilder.Entity("Bd_web.Models.Ticket", b =>
                {
                    b.HasOne("Bd_web.Models.Match", "Match_T")
                        .WithMany()
                        .HasForeignKey("Match_TId");
                });

            modelBuilder.Entity("Bd_web.Models.Сosts", b =>
                {
                    b.HasOne("Bd_web.Models.Shop", "ShopeType")
                        .WithMany()
                        .HasForeignKey("ShopeTypeId");

                    b.HasOne("Bd_web.Models.Club", "club")
                        .WithMany()
                        .HasForeignKey("clubId");
                });
#pragma warning restore 612, 618
        }
    }
}

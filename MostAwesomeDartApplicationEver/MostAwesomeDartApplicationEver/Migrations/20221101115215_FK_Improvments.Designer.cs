﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MostAwesomeDartApplicationEver.Models;

#nullable disable

namespace MostAwesomeDartApplicationEver.Migrations
{
    [DbContext(typeof(DartDbContext))]
    [Migration("20221101115215_FK_Improvments")]
    partial class FK_Improvments
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("MostAwesomeDartApplicationEver.Models.Darter", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("MatchId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("Darters");
                });

            modelBuilder.Entity("MostAwesomeDartApplicationEver.Models.Hit", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HitArea")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Hit");
                });

            modelBuilder.Entity("MostAwesomeDartApplicationEver.Models.Leg", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DartsThrown")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SetId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WinnerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SetId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Legs");
                });

            modelBuilder.Entity("MostAwesomeDartApplicationEver.Models.Match", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ScheduledDateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WinnerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WinnerId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("MostAwesomeDartApplicationEver.Models.Round", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DartsThrown")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LegId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WinnerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LegId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("MostAwesomeDartApplicationEver.Models.Set", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DarterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DartsThrown")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MatchId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WinnerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DarterId");

                    b.HasIndex("MatchId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("MostAwesomeDartApplicationEver.Models.Throw", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HitId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoundId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("HitId");

                    b.HasIndex("RoundId");

                    b.ToTable("Throws");
                });

            modelBuilder.Entity("MostAwesomeDartApplicationEver.Models.Darter", b =>
                {
                    b.HasOne("MostAwesomeDartApplicationEver.Models.Match", null)
                        .WithMany("Darters")
                        .HasForeignKey("MatchId");
                });

            modelBuilder.Entity("MostAwesomeDartApplicationEver.Models.Leg", b =>
                {
                    b.HasOne("MostAwesomeDartApplicationEver.Models.Set", "Set")
                        .WithMany()
                        .HasForeignKey("SetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MostAwesomeDartApplicationEver.Models.Darter", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId");

                    b.Navigation("Set");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("MostAwesomeDartApplicationEver.Models.Match", b =>
                {
                    b.HasOne("MostAwesomeDartApplicationEver.Models.Darter", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("MostAwesomeDartApplicationEver.Models.Round", b =>
                {
                    b.HasOne("MostAwesomeDartApplicationEver.Models.Leg", "Leg")
                        .WithMany()
                        .HasForeignKey("LegId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MostAwesomeDartApplicationEver.Models.Darter", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId");

                    b.Navigation("Leg");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("MostAwesomeDartApplicationEver.Models.Set", b =>
                {
                    b.HasOne("MostAwesomeDartApplicationEver.Models.Darter", "Darter")
                        .WithMany()
                        .HasForeignKey("DarterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MostAwesomeDartApplicationEver.Models.Match", "Match")
                        .WithMany()
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MostAwesomeDartApplicationEver.Models.Darter", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId");

                    b.Navigation("Darter");

                    b.Navigation("Match");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("MostAwesomeDartApplicationEver.Models.Throw", b =>
                {
                    b.HasOne("MostAwesomeDartApplicationEver.Models.Hit", "Hit")
                        .WithMany()
                        .HasForeignKey("HitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MostAwesomeDartApplicationEver.Models.Round", "Round")
                        .WithMany()
                        .HasForeignKey("RoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hit");

                    b.Navigation("Round");
                });

            modelBuilder.Entity("MostAwesomeDartApplicationEver.Models.Match", b =>
                {
                    b.Navigation("Darters");
                });
#pragma warning restore 612, 618
        }
    }
}

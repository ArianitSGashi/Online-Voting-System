﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineVotingSystem.Infrastructure.Persistence.Context;

#nullable disable

namespace OnlineVotingSystem.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineVotingSystem.Domain.Entities.Campaign", b =>
                {
                    b.Property<int>("CampaignID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampaignID"));

                    b.Property<int>("CandidateID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ElectionID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("CampaignID");

                    b.HasIndex("CandidateID");

                    b.HasIndex("ElectionID");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("OnlineVotingSystem.Domain.Entities.Candidates", b =>
                {
                    b.Property<int>("CandidateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CandidateID"));

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ElectionID")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Income")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Party")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Works")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CandidateID");

                    b.HasIndex("ElectionID");

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("OnlineVotingSystem.Domain.Entities.Complaints", b =>
                {
                    b.Property<int>("ComplaintID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComplaintID"));

                    b.Property<DateTime>("ComplaintDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ComplaintText")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ElectionID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ComplaintID");

                    b.HasIndex("ElectionID");

                    b.ToTable("Complaints");
                });

            modelBuilder.Entity("OnlineVotingSystem.Domain.Entities.Elections", b =>
                {
                    b.Property<int>("ElectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ElectionID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ElectionID");

                    b.ToTable("Elections");
                });

            modelBuilder.Entity("OnlineVotingSystem.Domain.Entities.Feedback", b =>
                {
                    b.Property<int>("FeedbackID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackID"));

                    b.Property<int>("ElectionID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FeedbackDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FeedbackText")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FeedbackID");

                    b.HasIndex("ElectionID");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("OnlineVotingSystem.Domain.Entities.Result", b =>
                {
                    b.Property<int>("ResultID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResultID"));

                    b.Property<int>("CandidateID")
                        .HasColumnType("int");

                    b.Property<int>("ElectionID")
                        .HasColumnType("int");

                    b.Property<int>("TotalVotes")
                        .HasColumnType("int");

                    b.HasKey("ResultID");

                    b.HasIndex("CandidateID");

                    b.HasIndex("ElectionID");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("OnlineVotingSystem.Domain.Entities.Votes", b =>
                {
                    b.Property<int>("VoteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VoteID"));

                    b.Property<int>("CandidateID")
                        .HasColumnType("int");

                    b.Property<int>("ElectionID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("VoteDate")
                        .HasColumnType("datetime2");

                    b.HasKey("VoteID");

                    b.HasIndex("CandidateID");

                    b.HasIndex("ElectionID");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("OnlineVotingSystem.Domain.Entities.Campaign", b =>
                {
                    b.HasOne("OnlineVotingSystem.Domain.Entities.Candidates", "Candidates")
                        .WithMany("Campaigns")
                        .HasForeignKey("CandidateID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OnlineVotingSystem.Domain.Entities.Elections", "Elections")
                        .WithMany("Campaigns")
                        .HasForeignKey("ElectionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Candidates");

                    b.Navigation("Elections");
                });

            modelBuilder.Entity("OnlineVotingSystem.Domain.Entities.Candidates", b =>
                {
                    b.HasOne("OnlineVotingSystem.Domain.Entities.Elections", "Elections")
                        .WithMany("Candidates")
                        .HasForeignKey("ElectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Elections");
                });

            modelBuilder.Entity("OnlineVotingSystem.Domain.Entities.Complaints", b =>
                {
                    b.HasOne("OnlineVotingSystem.Domain.Entities.Elections", "Elections")
                        .WithMany("Complaints")
                        .HasForeignKey("ElectionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Elections");
                });

            modelBuilder.Entity("OnlineVotingSystem.Domain.Entities.Feedback", b =>
                {
                    b.HasOne("OnlineVotingSystem.Domain.Entities.Elections", "Elections")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ElectionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Elections");
                });

            modelBuilder.Entity("OnlineVotingSystem.Domain.Entities.Result", b =>
                {
                    b.HasOne("OnlineVotingSystem.Domain.Entities.Candidates", "Candidates")
                        .WithMany("Results")
                        .HasForeignKey("CandidateID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OnlineVotingSystem.Domain.Entities.Elections", "Elections")
                        .WithMany("Results")
                        .HasForeignKey("ElectionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Candidates");

                    b.Navigation("Elections");
                });

            modelBuilder.Entity("OnlineVotingSystem.Domain.Entities.Votes", b =>
                {
                    b.HasOne("OnlineVotingSystem.Domain.Entities.Candidates", "Candidates")
                        .WithMany("Votes")
                        .HasForeignKey("CandidateID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OnlineVotingSystem.Domain.Entities.Elections", "Elections")
                        .WithMany("Votes")
                        .HasForeignKey("ElectionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Candidates");

                    b.Navigation("Elections");
                });

            modelBuilder.Entity("OnlineVotingSystem.Domain.Entities.Candidates", b =>
                {
                    b.Navigation("Campaigns");

                    b.Navigation("Results");

                    b.Navigation("Votes");
                });

            modelBuilder.Entity("OnlineVotingSystem.Domain.Entities.Elections", b =>
                {
                    b.Navigation("Campaigns");

                    b.Navigation("Candidates");

                    b.Navigation("Complaints");

                    b.Navigation("Feedbacks");

                    b.Navigation("Results");

                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}

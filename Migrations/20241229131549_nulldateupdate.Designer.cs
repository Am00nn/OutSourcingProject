﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OutsourcingSystem;

#nullable disable

namespace OutsourcingSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241229131549_nulldateupdate")]
    partial class nulldateupdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OutsourcingSystem.Models.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientID"));

                    b.Property<decimal>("CommitmentRating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("UID")
                        .HasColumnType("int");

                    b.HasKey("ClientID");

                    b.HasIndex("UID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.ClientRequestDeveloper", b =>
                {
                    b.Property<int>("RequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestID"));

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RequestID");

                    b.HasIndex("ClientID");

                    b.ToTable("ClientRequestDeveloper");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.ClientRequestTeam", b =>
                {
                    b.Property<int>("RequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestID"));

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RequestID");

                    b.HasIndex("ClientID");

                    b.ToTable("ClientRequestTeam");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.ClientReviewDeveloper", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewID"));

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DeveloperID")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("ReviewID");

                    b.HasIndex("ClientID");

                    b.HasIndex("DeveloperID");

                    b.ToTable("ClientReviewDeveloper");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.ClientReviewTeam", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewID"));

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("ReviewID");

                    b.HasIndex("ClientID");

                    b.HasIndex("TeamID");

                    b.ToTable("ClientReviewTeam");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.Developer", b =>
                {
                    b.Property<int>("DeveloperID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeveloperID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<bool>("AvailabilityStatus")
                        .HasColumnType("bit");

                    b.Property<bool>("CanBePartOfTeam")
                        .HasColumnType("bit");

                    b.Property<string>("CareerSummary")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("CompletedProjects")
                        .HasColumnType("int");

                    b.Property<decimal>("HourlyRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("int");

                    b.HasKey("DeveloperID");

                    b.HasIndex("UserID");

                    b.ToTable("Developer");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.DeveloperSkill", b =>
                {
                    b.Property<int>("DeveloperID")
                        .HasColumnType("int");

                    b.Property<int>("SkillID")
                        .HasColumnType("int");

                    b.Property<int>("Proficiency")
                        .HasColumnType("int");

                    b.HasKey("DeveloperID", "SkillID");

                    b.HasIndex("SkillID");

                    b.ToTable("DeveloperSkill");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.FeedbackOnClient", b =>
                {
                    b.Property<int>("FeedbackID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackID"));

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeveloperID")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("FeedbackID");

                    b.HasIndex("ClientID");

                    b.HasIndex("DeveloperID");

                    b.HasIndex("TeamID");

                    b.ToTable("FeedbackOnClient");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.Project", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectID"));

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<int>("DailyHoursNeeded")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("DeveloperID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("StartAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("ProjectID");

                    b.HasIndex("ClientID");

                    b.HasIndex("DeveloperID");

                    b.HasIndex("TeamID");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.Skills", b =>
                {
                    b.Property<int>("SkillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SkillID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SkillID");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.TeamMember", b =>
                {
                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.Property<DateTime>("JoinedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("TeamID");

                    b.ToTable("TeamMember");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.Teams", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamID"));

                    b.Property<int>("CompletedProjects")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("HourlyRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TeamCapacity")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TeamID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.User", b =>
                {
                    b.Property<int>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("UID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.Client", b =>
                {
                    b.HasOne("OutsourcingSystem.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.ClientRequestDeveloper", b =>
                {
                    b.HasOne("OutsourcingSystem.Models.Client", "Client")
                        .WithMany("ClientRequestDeveloper")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.ClientRequestTeam", b =>
                {
                    b.HasOne("OutsourcingSystem.Models.Client", "Client")
                        .WithMany("ClientRequestTeam")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.ClientReviewDeveloper", b =>
                {
                    b.HasOne("OutsourcingSystem.Models.Client", null)
                        .WithMany("ClientReviewDeveloper")
                        .HasForeignKey("ClientID");

                    b.HasOne("OutsourcingSystem.Models.Developer", "Developer")
                        .WithMany("ClientReviewDeveloper")
                        .HasForeignKey("DeveloperID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.ClientReviewTeam", b =>
                {
                    b.HasOne("OutsourcingSystem.Models.Client", "Client")
                        .WithMany("ClientReviewTeam")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OutsourcingSystem.Models.Teams", "Teams")
                        .WithMany("ClientReviewTeam")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.Developer", b =>
                {
                    b.HasOne("OutsourcingSystem.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.DeveloperSkill", b =>
                {
                    b.HasOne("OutsourcingSystem.Models.Developer", "Developer")
                        .WithMany("DeveloperSkills")
                        .HasForeignKey("DeveloperID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OutsourcingSystem.Models.Skills", "Skills")
                        .WithMany("DeveloperSkills")
                        .HasForeignKey("SkillID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.FeedbackOnClient", b =>
                {
                    b.HasOne("OutsourcingSystem.Models.Client", "Client")
                        .WithMany("FeedbackOnClient")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OutsourcingSystem.Models.Developer", "Developer")
                        .WithMany("FeedbackOnClient")
                        .HasForeignKey("DeveloperID");

                    b.HasOne("OutsourcingSystem.Models.Teams", "Team")
                        .WithMany("FeedbackOnClient")
                        .HasForeignKey("TeamID");

                    b.Navigation("Client");

                    b.Navigation("Developer");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.Project", b =>
                {
                    b.HasOne("OutsourcingSystem.Models.Client", "Client")
                        .WithMany("Projects")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OutsourcingSystem.Models.Developer", "Developer")
                        .WithMany("Project")
                        .HasForeignKey("DeveloperID");

                    b.HasOne("OutsourcingSystem.Models.Teams", "Teams")
                        .WithMany("Projects")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Developer");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.TeamMember", b =>
                {
                    b.HasOne("OutsourcingSystem.Models.Teams", "Team")
                        .WithMany("TeamMembers")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.Client", b =>
                {
                    b.Navigation("ClientRequestDeveloper");

                    b.Navigation("ClientRequestTeam");

                    b.Navigation("ClientReviewDeveloper");

                    b.Navigation("ClientReviewTeam");

                    b.Navigation("FeedbackOnClient");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.Developer", b =>
                {
                    b.Navigation("ClientReviewDeveloper");

                    b.Navigation("DeveloperSkills");

                    b.Navigation("FeedbackOnClient");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.Skills", b =>
                {
                    b.Navigation("DeveloperSkills");
                });

            modelBuilder.Entity("OutsourcingSystem.Models.Teams", b =>
                {
                    b.Navigation("ClientReviewTeam");

                    b.Navigation("FeedbackOnClient");

                    b.Navigation("Projects");

                    b.Navigation("TeamMembers");
                });
#pragma warning restore 612, 618
        }
    }
}

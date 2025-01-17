﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_API_Assigmnet.Connection;

#nullable disable

namespace Web_API_Assigmnet.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DirectorMoive", b =>
                {
                    b.Property<int>("DirectorsDirectorId")
                        .HasColumnType("int");

                    b.Property<int>("MoivesMoiveId")
                        .HasColumnType("int");

                    b.HasKey("DirectorsDirectorId", "MoivesMoiveId");

                    b.HasIndex("MoivesMoiveId");

                    b.ToTable("DirectorMoive");
                });

            modelBuilder.Entity("Web_API_Assigmnet.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Web_API_Assigmnet.Models.Director", b =>
                {
                    b.Property<int>("DirectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DirectorId"));

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NationalityId")
                        .HasColumnType("int");

                    b.HasKey("DirectorId");

                    b.HasIndex("NationalityId")
                        .IsUnique();

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("Web_API_Assigmnet.Models.Moive", b =>
                {
                    b.Property<int>("MoiveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MoiveId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseYear")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MoiveId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Moives");
                });

            modelBuilder.Entity("Web_API_Assigmnet.Models.Nationality", b =>
                {
                    b.Property<int>("NationalityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NationalityId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NationalityId");

                    b.ToTable("Nationalities");
                });

            modelBuilder.Entity("DirectorMoive", b =>
                {
                    b.HasOne("Web_API_Assigmnet.Models.Director", null)
                        .WithMany()
                        .HasForeignKey("DirectorsDirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_API_Assigmnet.Models.Moive", null)
                        .WithMany()
                        .HasForeignKey("MoivesMoiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Web_API_Assigmnet.Models.Director", b =>
                {
                    b.HasOne("Web_API_Assigmnet.Models.Nationality", "Nationality")
                        .WithOne("Director")
                        .HasForeignKey("Web_API_Assigmnet.Models.Director", "NationalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Nationality");
                });

            modelBuilder.Entity("Web_API_Assigmnet.Models.Moive", b =>
                {
                    b.HasOne("Web_API_Assigmnet.Models.Category", "Category")
                        .WithMany("Moives")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Web_API_Assigmnet.Models.Category", b =>
                {
                    b.Navigation("Moives");
                });

            modelBuilder.Entity("Web_API_Assigmnet.Models.Nationality", b =>
                {
                    b.Navigation("Director")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

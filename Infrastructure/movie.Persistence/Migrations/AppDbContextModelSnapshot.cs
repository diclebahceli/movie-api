﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using movie.Persistence;

#nullable disable

namespace movie.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("MovieUser", b =>
                {
                    b.Property<int>("FavoritedUsersId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoviesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FavoritedUsersId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("MovieUser");
                });

            modelBuilder.Entity("movie.Domain.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 3, 3, 11, 53, 55, 952, DateTimeKind.Local).AddTicks(3262),
                            Description = "Drama is a category of narrative fiction intended to be more serious than humorous in tone.",
                            IsDeleted = false,
                            Name = "Drama"
                        });
                });

            modelBuilder.Entity("movie.Domain.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 3, 3, 11, 53, 55, 952, DateTimeKind.Local).AddTicks(4761),
                            Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                            GenreId = 1,
                            IsDeleted = false,
                            Title = "The Godfather",
                            Year = 1972
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 3, 3, 11, 53, 55, 952, DateTimeKind.Local).AddTicks(4768),
                            Description = "Two imprisoned,",
                            GenreId = 1,
                            IsDeleted = false,
                            Title = "The Shawshank Redemption",
                            Year = 1994
                        });
                });

            modelBuilder.Entity("movie.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 3, 3, 11, 53, 55, 952, DateTimeKind.Local).AddTicks(7081),
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 3, 3, 11, 53, 55, 952, DateTimeKind.Local).AddTicks(7180),
                            IsDeleted = false
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 3, 3, 11, 53, 55, 952, DateTimeKind.Local).AddTicks(7181),
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("MovieUser", b =>
                {
                    b.HasOne("movie.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("FavoritedUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("movie.Domain.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("movie.Domain.Movie", b =>
                {
                    b.HasOne("movie.Domain.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("movie.Domain.Genre", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}

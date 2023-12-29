﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TrainingAndDietApp.DAL.Context;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230831161846_AddExerciseTableAndTraineeExerciseTable")]
    partial class AddExerciseTableAndTraineeExerciseTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Training_and_diet_backend.Models.Exercise", b =>
                {
                    b.Property<int>("Id_Exercise")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnOrder(0);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Exercise"));

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Exercise_steps")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<byte[]>("Image")
                        .HasColumnType("bytea");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id_Exercise");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Training_and_diet_backend.Models.Trainee_exercise", b =>
                {
                    b.Property<int>("Id_Trainee_exercise")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnOrder(0);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Trainee_exercise"));

                    b.Property<string>("Comments")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("Date");

                    b.Property<TimeSpan>("Exercise_duration")
                        .HasColumnType("interval");

                    b.Property<int>("Id_Exercise")
                        .HasColumnType("integer");

                    b.Property<int>("Repetitions_number")
                        .HasColumnType("integer");

                    b.Property<int>("Series_number")
                        .HasColumnType("integer");

                    b.HasKey("Id_Trainee_exercise");

                    b.HasIndex("Id_Exercise");

                    b.ToTable("Trainee_exercises");
                });

            modelBuilder.Entity("Training_and_diet_backend.Models.Trainee_exercise", b =>
                {
                    b.HasOne("Training_and_diet_backend.Models.Exercise", "Exercise")
                        .WithMany("Trainee_Exercises")
                        .HasForeignKey("Id_Exercise")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("Training_and_diet_backend.Models.Exercise", b =>
                {
                    b.Navigation("Trainee_Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}

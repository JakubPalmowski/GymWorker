﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Training_and_diet_backend.Context;

#nullable disable

namespace Training_and_diet_backend.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230901184722_AddRelationBetweenUserAndTrainingPlan")]
    partial class AddRelationBetweenUserAndTrainingPlan
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

                    b.Property<int>("Id_Training_plan")
                        .HasColumnType("integer");

                    b.Property<int>("Repetitions_number")
                        .HasColumnType("integer");

                    b.Property<int>("Series_number")
                        .HasColumnType("integer");

                    b.HasKey("Id_Trainee_exercise");

                    b.HasIndex("Id_Exercise");

                    b.HasIndex("Id_Training_plan");

                    b.ToTable("Trainee_exercises");
                });

            modelBuilder.Entity("Training_and_diet_backend.Models.Training_plan", b =>
                {
                    b.Property<int>("Id_Training_plan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnOrder(0);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Training_plan"));

                    b.Property<DateTime>("End_date")
                        .HasColumnType("Date");

                    b.Property<int>("Id_Pupil")
                        .HasColumnType("integer");

                    b.Property<int>("Id_Trainer")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<TimeSpan>("Plan_duration")
                        .HasColumnType("interval");

                    b.Property<DateTime>("Start_date")
                        .HasColumnType("Date");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id_Training_plan");

                    b.HasIndex("Id_Pupil");

                    b.HasIndex("Id_Trainer");

                    b.ToTable("Training_plans");
                });

            modelBuilder.Entity("Training_and_diet_backend.Models.User", b =>
                {
                    b.Property<int>("Id_User")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnOrder(0);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_User"));

                    b.Property<int?>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Email_validated")
                        .HasColumnType("boolean");

                    b.Property<decimal?>("Height")
                        .HasColumnType("decimal(3,2)");

                    b.Property<string>("Last_name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone_number")
                        .IsRequired()
                        .HasColumnType("char(11)");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(3,2)");

                    b.HasKey("Id_User");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Training_and_diet_backend.Models.Trainee_exercise", b =>
                {
                    b.HasOne("Training_and_diet_backend.Models.Exercise", "Exercise")
                        .WithMany("Trainee_Exercises")
                        .HasForeignKey("Id_Exercise")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Training_and_diet_backend.Models.Training_plan", "Training_plan")
                        .WithMany("Trainee_Exercises")
                        .HasForeignKey("Id_Training_plan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("Training_plan");
                });

            modelBuilder.Entity("Training_and_diet_backend.Models.Training_plan", b =>
                {
                    b.HasOne("Training_and_diet_backend.Models.User", "Pupil")
                        .WithMany("Pupil_Training_plans")
                        .HasForeignKey("Id_Pupil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Training_and_diet_backend.Models.User", "Trainer")
                        .WithMany("Trainer_Training_plans")
                        .HasForeignKey("Id_Trainer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pupil");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("Training_and_diet_backend.Models.Exercise", b =>
                {
                    b.Navigation("Trainee_Exercises");
                });

            modelBuilder.Entity("Training_and_diet_backend.Models.Training_plan", b =>
                {
                    b.Navigation("Trainee_Exercises");
                });

            modelBuilder.Entity("Training_and_diet_backend.Models.User", b =>
                {
                    b.Navigation("Pupil_Training_plans");

                    b.Navigation("Trainer_Training_plans");
                });
#pragma warning restore 612, 618
        }
    }
}

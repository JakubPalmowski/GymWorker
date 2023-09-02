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
    [Migration("20230902172127_AlterTrainingPlanTable")]
    partial class AlterTrainingPlanTable
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

                    b.Property<int>("Id_Trainer")
                        .HasColumnType("integer");

                    b.Property<byte[]>("Image")
                        .HasColumnType("bytea");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id_Exercise");

                    b.HasIndex("Id_Trainer");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Id_Exercise = 1,
                            Details = "Podstawowe ćwiczenie siłowe, angażuje mięśnie klatki piersiowej, ramion i tricepsa.",
                            Exercise_steps = "[{\"Step\": 1, \"Description\": \"Połóż się na podłodze na brzuchu, ręce ustawione nieco szerzej niż szerokość ramion.\"}, {\"Step\": 2, \"Description\": \"Wypnij się na rękach i naciskaj ciało do góry, wyprostowując ręce.\"}, {\"Step\": 3, \"Description\": \"Powoli wróć do pozycji wyjściowej, zginając ręce w łokciach.\"}]",
                            Id_Trainer = 1,
                            Name = "Pompki"
                        },
                        new
                        {
                            Id_Exercise = 2,
                            Details = "Ćwiczenie wzmacniające mięśnie nóg, pośladków i dolnej części pleców.",
                            Exercise_steps = "[{\"Step\": 1, \"Description\": \"Stań prosto, nogi ustawione na szerokość bioder.\"}, {\"Step\": 2, \"Description\": \"Opuszczaj biodra w dół, jakbyś siadał na niewidzialne krzesło.\"}, {\"Step\": 3, \"Description\": \"Powoli wracaj do pozycji wyjściowej, naciskając pięty w podłogę.\"}]",
                            Id_Trainer = 1,
                            Name = "Przysiady"
                        },
                        new
                        {
                            Id_Exercise = 3,
                            Details = "Ćwiczenie wzmacniające mięśnie brzucha, pleców i ramion.",
                            Exercise_steps = "[{\"Step\": 1, \"Description\": \"Połóż się na brzuchu, opierając się na przedramionach i palcach u stóp.\"}, {\"Step\": 2, \"Description\": \"Utrzymuj prostą linię od głowy do pięt, napinając mięśnie brzucha.\"}, {\"Step\": 3, \"Description\": \"Utrzymuj tę pozycję przez określony czas.\"}]",
                            Id_Trainer = 1,
                            Name = "Plank"
                        });
                });

            modelBuilder.Entity("Training_and_diet_backend.Models.Pupil_mentor", b =>
                {
                    b.Property<int>("Id_Mentor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnOrder(0);

                    b.Property<int>("Id_Pupil")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnOrder(1);

                    b.HasKey("Id_Mentor", "Id_Pupil");

                    b.HasIndex("Id_Pupil");

                    b.ToTable("Pupil_mentors");

                    b.HasData(
                        new
                        {
                            Id_Mentor = 1,
                            Id_Pupil = 2
                        },
                        new
                        {
                            Id_Mentor = 1,
                            Id_Pupil = 3
                        });
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

                    b.HasData(
                        new
                        {
                            Id_Trainee_exercise = 1,
                            Date = new DateTime(2023, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id_Exercise = 1,
                            Id_Training_plan = 1,
                            Repetitions_number = 12,
                            Series_number = 3
                        },
                        new
                        {
                            Id_Trainee_exercise = 2,
                            Date = new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id_Exercise = 2,
                            Id_Training_plan = 1,
                            Repetitions_number = 10,
                            Series_number = 4
                        },
                        new
                        {
                            Id_Trainee_exercise = 3,
                            Date = new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id_Exercise = 3,
                            Id_Training_plan = 2,
                            Repetitions_number = 15,
                            Series_number = 2
                        });
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

                    b.Property<int?>("Id_Pupil")
                        .HasColumnType("integer");

                    b.Property<int>("Id_Trainer")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("Start_date")
                        .HasColumnType("Date");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id_Training_plan");

                    b.HasIndex("Id_Pupil");

                    b.HasIndex("Id_Trainer");

                    b.ToTable("Training_plans");

                    b.HasData(
                        new
                        {
                            Id_Training_plan = 1,
                            End_date = new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id_Pupil = 2,
                            Id_Trainer = 1,
                            Name = "Plan treningowy dla początkujących",
                            Start_date = new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Siłowy"
                        },
                        new
                        {
                            Id_Training_plan = 2,
                            End_date = new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id_Pupil = 2,
                            Id_Trainer = 1,
                            Name = "Plan treningowy na odchudzanie",
                            Start_date = new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Cardio"
                        });
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

                    b.HasData(
                        new
                        {
                            Id_User = 1,
                            Email = "michal@gmail.com",
                            Email_validated = true,
                            Last_name = "Emczyk",
                            Name = "Michał",
                            Phone_number = "48777888777",
                            Role = 3,
                            Sex = "Male"
                        },
                        new
                        {
                            Id_User = 2,
                            Email = "anna@gmail.com",
                            Email_validated = true,
                            Last_name = "Kowalska",
                            Name = "Anna",
                            Phone_number = "48666778888",
                            Role = 2,
                            Sex = "Female"
                        },
                        new
                        {
                            Id_User = 3,
                            Email = "john@gmail.com",
                            Email_validated = true,
                            Last_name = "Doe",
                            Name = "John",
                            Phone_number = "48555667777",
                            Role = 2,
                            Sex = "Male"
                        });
                });

            modelBuilder.Entity("Training_and_diet_backend.Models.Exercise", b =>
                {
                    b.HasOne("Training_and_diet_backend.Models.User", "Trainer")
                        .WithMany("Exercises")
                        .HasForeignKey("Id_Trainer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("Training_and_diet_backend.Models.Pupil_mentor", b =>
                {
                    b.HasOne("Training_and_diet_backend.Models.User", "Mentor")
                        .WithMany("Mentor_Pupils")
                        .HasForeignKey("Id_Mentor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Training_and_diet_backend.Models.User", "Pupil")
                        .WithMany("Pupil_Mentors")
                        .HasForeignKey("Id_Pupil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mentor");

                    b.Navigation("Pupil");
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
                        .HasForeignKey("Id_Pupil");

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
                    b.Navigation("Exercises");

                    b.Navigation("Mentor_Pupils");

                    b.Navigation("Pupil_Mentors");

                    b.Navigation("Pupil_Training_plans");

                    b.Navigation("Trainer_Training_plans");
                });
#pragma warning restore 612, 618
        }
    }
}

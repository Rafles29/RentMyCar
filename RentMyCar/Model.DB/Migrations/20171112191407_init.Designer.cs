﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Model;
using Model.DB;
using System;

namespace Model.DB.Migrations
{
    [DbContext(typeof(RentMyAppContext))]
    [Migration("20171112191407_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Adress", b =>
                {
                    b.Property<long>("AdressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("PostalCode");

                    b.Property<long>("RentId");

                    b.Property<string>("StreetName");

                    b.Property<int>("StreetNumber");

                    b.HasKey("AdressId");

                    b.HasIndex("RentId")
                        .IsUnique();

                    b.ToTable("Adress");
                });

            modelBuilder.Entity("Model.Car", b =>
                {
                    b.Property<long>("CarId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("AvatarImage");

                    b.Property<string>("Manufactor");

                    b.Property<string>("Model");

                    b.Property<long>("UserId");

                    b.Property<int>("Year");

                    b.HasKey("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Model.Equipment", b =>
                {
                    b.Property<long>("EquipmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AC");

                    b.Property<int>("BodyType");

                    b.Property<long>("CarId");

                    b.Property<int>("Colour");

                    b.Property<int>("Gearbox");

                    b.Property<bool>("Lift");

                    b.Property<int>("Seats");

                    b.HasKey("EquipmentId");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("Model.Performance", b =>
                {
                    b.Property<long>("PerformanceId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CarId");

                    b.Property<int>("HorsePower");

                    b.Property<double>("MaxSpeed");

                    b.Property<int>("Millage");

                    b.Property<double>("ZeroTo100");

                    b.HasKey("PerformanceId");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("Performance");
                });

            modelBuilder.Entity("Model.Price", b =>
                {
                    b.Property<long>("PriceId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CarId");

                    b.Property<decimal>("LongTermPrice");

                    b.Property<decimal>("MidTermPrice");

                    b.Property<decimal>("ShortTermPrice");

                    b.HasKey("PriceId");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("Price");
                });

            modelBuilder.Entity("Model.Rent", b =>
                {
                    b.Property<long>("RentId")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("CarId");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<long?>("UserId");

                    b.HasKey("RentId");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("Model.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Login");

                    b.Property<string>("Mail");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Model.Adress", b =>
                {
                    b.HasOne("Model.Rent", "Rent")
                        .WithOne("Adress")
                        .HasForeignKey("Model.Adress", "RentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Car", b =>
                {
                    b.HasOne("Model.User", "User")
                        .WithMany("Cars")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Equipment", b =>
                {
                    b.HasOne("Model.Car", "Car")
                        .WithOne("Equipment")
                        .HasForeignKey("Model.Equipment", "CarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Performance", b =>
                {
                    b.HasOne("Model.Car", "Car")
                        .WithOne("Performance")
                        .HasForeignKey("Model.Performance", "CarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Price", b =>
                {
                    b.HasOne("Model.Car", "Car")
                        .WithOne("Price")
                        .HasForeignKey("Model.Price", "CarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Rent", b =>
                {
                    b.HasOne("Model.Car", "Car")
                        .WithMany("Rents")
                        .HasForeignKey("CarId");

                    b.HasOne("Model.User", "User")
                        .WithMany("Rents")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}

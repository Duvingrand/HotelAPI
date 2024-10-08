﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaNET_BrayanFelipeRodriguezMosquera.Data;

#nullable disable

namespace PruebaNET_BrayanFelipeRodriguezMosquera.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20241007185103_last2")]
    partial class last2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("PruebaNET_BrayanFelipeRodriguezMosquera.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("employee_id");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("end_date");

                    b.Property<int>("GuestId")
                        .HasColumnType("int")
                        .HasColumnName("guest_id");

                    b.Property<int>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("room_id");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("start_date");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("GuestId");

                    b.HasIndex("RoomId");

                    b.ToTable("bookings");
                });

            modelBuilder.Entity("PruebaNET_BrayanFelipeRodriguezMosquera.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("first_name");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("identification_number");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("PruebaNET_BrayanFelipeRodriguezMosquera.Models.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birth_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("first_name");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("identification_number");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("last_name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("phone_number");

                    b.HasKey("Id");

                    b.ToTable("guests");
                });

            modelBuilder.Entity("PruebaNET_BrayanFelipeRodriguezMosquera.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Availability")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("availability");

                    b.Property<int>("MaxOccupancyPeople")
                        .HasColumnType("int")
                        .HasColumnName("max_occupancy_people");

                    b.Property<double>("PricePerNight")
                        .HasColumnType("double")
                        .HasColumnName("price_per_night");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("room_number");

                    b.Property<int>("RoomTypeID")
                        .HasColumnType("int")
                        .HasColumnName("room_type_id");

                    b.HasKey("Id");

                    b.HasIndex("RoomTypeID");

                    b.ToTable("rooms");
                });

            modelBuilder.Entity("PruebaNET_BrayanFelipeRodriguezMosquera.Models.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("room_types");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Una acogedora habitación básica con una cama individual, ideal para viajeros solos.",
                            Name = "Habitación Simple"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Ofrece flexibilidad con dos camas individuales o una cama doble, perfecta para parejas o amigos.",
                            Name = "Habitación Doble"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Espaciosa y lujosa, con una cama king size y una sala de estar separada, ideal para quienes buscan confort y exclusividad.",
                            Name = "Suite"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Diseñada para familias, con espacio adicional y varias camas para una estancia cómoda.",
                            Name = "Habitación Familiar"
                        });
                });

            modelBuilder.Entity("PruebaNET_BrayanFelipeRodriguezMosquera.Models.Booking", b =>
                {
                    b.HasOne("PruebaNET_BrayanFelipeRodriguezMosquera.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PruebaNET_BrayanFelipeRodriguezMosquera.Models.Guest", "Guest")
                        .WithMany()
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PruebaNET_BrayanFelipeRodriguezMosquera.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Guest");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("PruebaNET_BrayanFelipeRodriguezMosquera.Models.Room", b =>
                {
                    b.HasOne("PruebaNET_BrayanFelipeRodriguezMosquera.Models.RoomType", "RoomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomType");
                });
#pragma warning restore 612, 618
        }
    }
}

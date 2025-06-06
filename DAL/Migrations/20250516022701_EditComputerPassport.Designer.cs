﻿// <auto-generated />
using System;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20250516022701_EditComputerPassport")]
    partial class EditComputerPassport
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("WarehouseId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("DAL.Models.ArrivalFromTheWarehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ComputerPassportId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DateOfArrivalFromTheWarehouse")
                        .HasColumnType("date");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OfficeId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComputerPassportId");

                    b.HasIndex("OfficeId");

                    b.HasIndex("UserId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("ArrivalFromTheWarehouses");
                });

            modelBuilder.Entity("DAL.Models.Coming", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateOnly?>("DateOfComing")
                        .HasColumnType("date");

                    b.Property<string>("DocumentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Comings");
                });

            modelBuilder.Entity("DAL.Models.Computer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ComingId")
                        .HasColumnType("int");

                    b.Property<int>("ComputerStatus")
                        .HasColumnType("int");

                    b.Property<int?>("KeyboardId")
                        .HasColumnType("int");

                    b.Property<int?>("MemoryDiskId")
                        .HasColumnType("int");

                    b.Property<int?>("MotherboardId")
                        .HasColumnType("int");

                    b.Property<int?>("MouseId")
                        .HasColumnType("int");

                    b.Property<int?>("OcId")
                        .HasColumnType("int");

                    b.Property<int?>("PowerUnitId")
                        .HasColumnType("int");

                    b.Property<int?>("ProcessorId")
                        .HasColumnType("int");

                    b.Property<int?>("RamId")
                        .HasColumnType("int");

                    b.Property<int?>("ScreenId")
                        .HasColumnType("int");

                    b.Property<int?>("VideoCardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComingId");

                    b.HasIndex("KeyboardId");

                    b.HasIndex("MemoryDiskId");

                    b.HasIndex("MotherboardId");

                    b.HasIndex("MouseId");

                    b.HasIndex("OcId");

                    b.HasIndex("PowerUnitId");

                    b.HasIndex("ProcessorId");

                    b.HasIndex("RamId");

                    b.HasIndex("ScreenId");

                    b.HasIndex("VideoCardId");

                    b.ToTable("Computers");
                });

            modelBuilder.Entity("DAL.Models.ComputerPassport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ComputerId")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("DateOfDebit")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DateOfReceipt")
                        .HasColumnType("date");

                    b.Property<string>("InventoryNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OfficeId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("WarehouseId")
                        .HasColumnType("int");

                    b.Property<int>("computerPassportStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.HasIndex("OfficeId");

                    b.HasIndex("UserId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("ComputerPassports");
                });

            modelBuilder.Entity("DAL.Models.DeanOffice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DeanOffices");
                });

            modelBuilder.Entity("DAL.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DeanOfficeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeanOfficeId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("DAL.Models.Keyboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Keyboards");
                });

            modelBuilder.Entity("DAL.Models.MemoryDisk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MemoryDisks");
                });

            modelBuilder.Entity("DAL.Models.Motherboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Motherboards");
                });

            modelBuilder.Entity("DAL.Models.Mouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mouses");
                });

            modelBuilder.Entity("DAL.Models.MovingThroughDivisions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ComputerPassportId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DateOfMovingThroughDivisions")
                        .HasColumnType("date");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OfficeNewId")
                        .HasColumnType("int");

                    b.Property<int?>("OfficeOldId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ComputerPassportId");

                    b.HasIndex("OfficeNewId");

                    b.HasIndex("OfficeOldId");

                    b.HasIndex("UserId");

                    b.ToTable("MovingThroughDivisions");
                });

            modelBuilder.Entity("DAL.Models.OC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ocs");
                });

            modelBuilder.Entity("DAL.Models.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Body")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfAvailableSeats")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("DAL.Models.PowerUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PowerUnits");
                });

            modelBuilder.Entity("DAL.Models.Processor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Processor");
                });

            modelBuilder.Entity("DAL.Models.RAM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rams");
                });

            modelBuilder.Entity("DAL.Models.RepairComputer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ComputerPassportId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceCenter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ComputerPassportId");

                    b.HasIndex("UserId");

                    b.ToTable("RepairComputers");
                });

            modelBuilder.Entity("DAL.Models.Screen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Screens");
                });

            modelBuilder.Entity("DAL.Models.VideoСard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VideoCards");
                });

            modelBuilder.Entity("DAL.Models.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("DAL.Models.WriteDowns", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ComputerPassportId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ComputerPassportId");

                    b.HasIndex("UserId");

                    b.ToTable("WriteDowns");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "de4b5914-7735-41de-bd39-632559514a23",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "749d7462-ff8e-4419-8322-19a2cf31f19b",
                            Name = "Ответственный за склад",
                            NormalizedName = "ОТВЕТСТВЕННЫЙ ЗА СКЛАД"
                        },
                        new
                        {
                            Id = "9690c570-b7ca-442e-8f66-dce6aa2bfe41",
                            Name = "Методист",
                            NormalizedName = "МЕТОДИСТ"
                        },
                        new
                        {
                            Id = "bece27f8-c04b-4409-ae50-9753a154dd81",
                            Name = "Инженер коммуниционного  центра",
                            NormalizedName = "ИНЖЕНЕР КОММУНИЦИОННОГО ЦЕНТРА"
                        },
                        new
                        {
                            Id = "fd797b31-9e85-40ea-b65d-d767476eebf6",
                            Name = "Проректор",
                            NormalizedName = "ПРОРЕКТОР"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DAL.Models.ApplicationUser", b =>
                {
                    b.HasOne("DAL.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("DAL.Models.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId");

                    b.Navigation("Department");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("DAL.Models.ArrivalFromTheWarehouse", b =>
                {
                    b.HasOne("DAL.Models.ComputerPassport", "ComputerPassport")
                        .WithMany()
                        .HasForeignKey("ComputerPassportId");

                    b.HasOne("DAL.Models.Office", "Office")
                        .WithMany()
                        .HasForeignKey("OfficeId");

                    b.HasOne("DAL.Models.ApplicationUser", "User")
                        .WithMany("ArrivalFromTheWarehouse")
                        .HasForeignKey("UserId");

                    b.HasOne("DAL.Models.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId");

                    b.Navigation("ComputerPassport");

                    b.Navigation("Office");

                    b.Navigation("User");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("DAL.Models.Coming", b =>
                {
                    b.HasOne("DAL.Models.ApplicationUser", "User")
                        .WithMany("Comings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.Computer", b =>
                {
                    b.HasOne("DAL.Models.Coming", "Coming")
                        .WithMany("Computer")
                        .HasForeignKey("ComingId");

                    b.HasOne("DAL.Models.Keyboard", "Keyboard")
                        .WithMany("Computers")
                        .HasForeignKey("KeyboardId");

                    b.HasOne("DAL.Models.MemoryDisk", "MemoryDisk")
                        .WithMany("Computers")
                        .HasForeignKey("MemoryDiskId");

                    b.HasOne("DAL.Models.Motherboard", "Motherboard")
                        .WithMany("Computers")
                        .HasForeignKey("MotherboardId");

                    b.HasOne("DAL.Models.Mouse", "Mouse")
                        .WithMany("Computers")
                        .HasForeignKey("MouseId");

                    b.HasOne("DAL.Models.OC", "Oc")
                        .WithMany("Computers")
                        .HasForeignKey("OcId");

                    b.HasOne("DAL.Models.PowerUnit", "PowerUnit")
                        .WithMany("Computers")
                        .HasForeignKey("PowerUnitId");

                    b.HasOne("DAL.Models.Processor", "Processor")
                        .WithMany("Computers")
                        .HasForeignKey("ProcessorId");

                    b.HasOne("DAL.Models.RAM", "Ram")
                        .WithMany("Computers")
                        .HasForeignKey("RamId");

                    b.HasOne("DAL.Models.Screen", "Screen")
                        .WithMany("Computers")
                        .HasForeignKey("ScreenId");

                    b.HasOne("DAL.Models.VideoСard", "VideoCard")
                        .WithMany("Computers")
                        .HasForeignKey("VideoCardId");

                    b.Navigation("Coming");

                    b.Navigation("Keyboard");

                    b.Navigation("MemoryDisk");

                    b.Navigation("Motherboard");

                    b.Navigation("Mouse");

                    b.Navigation("Oc");

                    b.Navigation("PowerUnit");

                    b.Navigation("Processor");

                    b.Navigation("Ram");

                    b.Navigation("Screen");

                    b.Navigation("VideoCard");
                });

            modelBuilder.Entity("DAL.Models.ComputerPassport", b =>
                {
                    b.HasOne("DAL.Models.Computer", "Computer")
                        .WithMany()
                        .HasForeignKey("ComputerId");

                    b.HasOne("DAL.Models.Office", "Office")
                        .WithMany()
                        .HasForeignKey("OfficeId");

                    b.HasOne("DAL.Models.ApplicationUser", "User")
                        .WithMany("ComputerPassport")
                        .HasForeignKey("UserId");

                    b.HasOne("DAL.Models.Warehouse", "Warehouse")
                        .WithMany("Computers")
                        .HasForeignKey("WarehouseId");

                    b.Navigation("Computer");

                    b.Navigation("Office");

                    b.Navigation("User");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("DAL.Models.Department", b =>
                {
                    b.HasOne("DAL.Models.DeanOffice", "DeanOffice")
                        .WithMany("Departments")
                        .HasForeignKey("DeanOfficeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("DeanOffice");
                });

            modelBuilder.Entity("DAL.Models.MovingThroughDivisions", b =>
                {
                    b.HasOne("DAL.Models.ComputerPassport", "ComputerPassport")
                        .WithMany()
                        .HasForeignKey("ComputerPassportId");

                    b.HasOne("DAL.Models.Office", "OfficeNew")
                        .WithMany()
                        .HasForeignKey("OfficeNewId");

                    b.HasOne("DAL.Models.Office", "OfficeOld")
                        .WithMany()
                        .HasForeignKey("OfficeOldId");

                    b.HasOne("DAL.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("ComputerPassport");

                    b.Navigation("OfficeNew");

                    b.Navigation("OfficeOld");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.Office", b =>
                {
                    b.HasOne("DAL.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("DAL.Models.RepairComputer", b =>
                {
                    b.HasOne("DAL.Models.ComputerPassport", "ComputerPassport")
                        .WithMany()
                        .HasForeignKey("ComputerPassportId");

                    b.HasOne("DAL.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("ComputerPassport");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Models.WriteDowns", b =>
                {
                    b.HasOne("DAL.Models.ComputerPassport", "ComputerPassport")
                        .WithMany()
                        .HasForeignKey("ComputerPassportId");

                    b.HasOne("DAL.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("ComputerPassport");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DAL.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.ApplicationUser", b =>
                {
                    b.Navigation("ArrivalFromTheWarehouse");

                    b.Navigation("Comings");

                    b.Navigation("ComputerPassport");
                });

            modelBuilder.Entity("DAL.Models.Coming", b =>
                {
                    b.Navigation("Computer");
                });

            modelBuilder.Entity("DAL.Models.DeanOffice", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("DAL.Models.Keyboard", b =>
                {
                    b.Navigation("Computers");
                });

            modelBuilder.Entity("DAL.Models.MemoryDisk", b =>
                {
                    b.Navigation("Computers");
                });

            modelBuilder.Entity("DAL.Models.Motherboard", b =>
                {
                    b.Navigation("Computers");
                });

            modelBuilder.Entity("DAL.Models.Mouse", b =>
                {
                    b.Navigation("Computers");
                });

            modelBuilder.Entity("DAL.Models.OC", b =>
                {
                    b.Navigation("Computers");
                });

            modelBuilder.Entity("DAL.Models.PowerUnit", b =>
                {
                    b.Navigation("Computers");
                });

            modelBuilder.Entity("DAL.Models.Processor", b =>
                {
                    b.Navigation("Computers");
                });

            modelBuilder.Entity("DAL.Models.RAM", b =>
                {
                    b.Navigation("Computers");
                });

            modelBuilder.Entity("DAL.Models.Screen", b =>
                {
                    b.Navigation("Computers");
                });

            modelBuilder.Entity("DAL.Models.VideoСard", b =>
                {
                    b.Navigation("Computers");
                });

            modelBuilder.Entity("DAL.Models.Warehouse", b =>
                {
                    b.Navigation("Computers");
                });
#pragma warning restore 612, 618
        }
    }
}

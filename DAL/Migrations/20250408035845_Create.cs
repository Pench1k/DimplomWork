using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeanOffices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeanOffices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keyboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keyboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemoryDisks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoryDisks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PowerUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Processor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Screens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeanOfficeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_DeanOffices_DeanOfficeId",
                        column: x => x.DeanOfficeId,
                        principalTable: "DeanOffices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Provider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfComing = table.Column<DateOnly>(type: "date", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comings_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessorId = table.Column<int>(type: "int", nullable: true),
                    MotherboardId = table.Column<int>(type: "int", nullable: true),
                    RamId = table.Column<int>(type: "int", nullable: true),
                    OcId = table.Column<int>(type: "int", nullable: true),
                    MemoryDiskId = table.Column<int>(type: "int", nullable: true),
                    PowerUnitId = table.Column<int>(type: "int", nullable: true),
                    VideoCardId = table.Column<int>(type: "int", nullable: true),
                    VideoСardId = table.Column<int>(type: "int", nullable: false),
                    MouseId = table.Column<int>(type: "int", nullable: true),
                    KeyboardId = table.Column<int>(type: "int", nullable: true),
                    ScreenId = table.Column<int>(type: "int", nullable: true),
                    WarehouseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Computers_Keyboards_KeyboardId",
                        column: x => x.KeyboardId,
                        principalTable: "Keyboards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Computers_MemoryDisks_MemoryDiskId",
                        column: x => x.MemoryDiskId,
                        principalTable: "MemoryDisks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Computers_Motherboards_MotherboardId",
                        column: x => x.MotherboardId,
                        principalTable: "Motherboards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Computers_Mouses_MouseId",
                        column: x => x.MouseId,
                        principalTable: "Mouses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Computers_Ocs_OcId",
                        column: x => x.OcId,
                        principalTable: "Ocs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Computers_PowerUnits_PowerUnitId",
                        column: x => x.PowerUnitId,
                        principalTable: "PowerUnits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Computers_Processor_ProcessorId",
                        column: x => x.ProcessorId,
                        principalTable: "Processor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Computers_Rams_RamId",
                        column: x => x.RamId,
                        principalTable: "Rams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Computers_Screens_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "Screens",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Computers_VideoCards_VideoСardId",
                        column: x => x.VideoСardId,
                        principalTable: "VideoCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computers_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Body = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    NumberOfAvailableSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offices_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    WarehouseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Workers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Workers_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComputerPassports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryNumber = table.Column<int>(type: "int", nullable: false),
                    ComputerId = table.Column<int>(type: "int", nullable: true),
                    DateOfReceipt = table.Column<DateOnly>(type: "date", nullable: false),
                    DateOfDebit = table.Column<DateOnly>(type: "date", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: true),
                    WorkersId = table.Column<int>(type: "int", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: true),
                    WarehouseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerPassports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputerPassports_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComputerPassports_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComputerPassports_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComputerPassports_Workers_WorkersId",
                        column: x => x.WorkersId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArrivalFromTheWarehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComputerPassportId = table.Column<int>(type: "int", nullable: true),
                    WarehouseId = table.Column<int>(type: "int", nullable: true),
                    OfficeId = table.Column<int>(type: "int", nullable: true),
                    WorkerId = table.Column<int>(type: "int", nullable: true),
                    DateOfArrivalFromTheWarehouse = table.Column<DateOnly>(type: "date", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArrivalFromTheWarehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArrivalFromTheWarehouses_ComputerPassports_ComputerPassportId",
                        column: x => x.ComputerPassportId,
                        principalTable: "ComputerPassports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ArrivalFromTheWarehouses_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ArrivalFromTheWarehouses_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ArrivalFromTheWarehouses_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MovingThroughDivisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComputerPassportId = table.Column<int>(type: "int", nullable: true),
                    OfficeOldId = table.Column<int>(type: "int", nullable: true),
                    OfficeNewId = table.Column<int>(type: "int", nullable: true),
                    WorkerId = table.Column<int>(type: "int", nullable: true),
                    WorkersId = table.Column<int>(type: "int", nullable: true),
                    DateOfMovingThroughDivisions = table.Column<DateOnly>(type: "date", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovingThroughDivisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovingThroughDivisions_ComputerPassports_ComputerPassportId",
                        column: x => x.ComputerPassportId,
                        principalTable: "ComputerPassports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovingThroughDivisions_Offices_OfficeNewId",
                        column: x => x.OfficeNewId,
                        principalTable: "Offices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovingThroughDivisions_Offices_OfficeOldId",
                        column: x => x.OfficeOldId,
                        principalTable: "Offices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovingThroughDivisions_Workers_WorkersId",
                        column: x => x.WorkersId,
                        principalTable: "Workers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RepairComputers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComputerPassportId = table.Column<int>(type: "int", nullable: true),
                    WorkerId = table.Column<int>(type: "int", nullable: true),
                    WorkersId = table.Column<int>(type: "int", nullable: true),
                    ServiceCenter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairComputers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepairComputers_ComputerPassports_ComputerPassportId",
                        column: x => x.ComputerPassportId,
                        principalTable: "ComputerPassports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RepairComputers_Workers_WorkersId",
                        column: x => x.WorkersId,
                        principalTable: "Workers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WriteDowns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComputerPassportId = table.Column<int>(type: "int", nullable: true),
                    WorkerId = table.Column<int>(type: "int", nullable: true),
                    WorkersId = table.Column<int>(type: "int", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriteDowns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WriteDowns_ComputerPassports_ComputerPassportId",
                        column: x => x.ComputerPassportId,
                        principalTable: "ComputerPassports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WriteDowns_Workers_WorkersId",
                        column: x => x.WorkersId,
                        principalTable: "Workers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArrivalFromTheWarehouses_ComputerPassportId",
                table: "ArrivalFromTheWarehouses",
                column: "ComputerPassportId");

            migrationBuilder.CreateIndex(
                name: "IX_ArrivalFromTheWarehouses_OfficeId",
                table: "ArrivalFromTheWarehouses",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_ArrivalFromTheWarehouses_WarehouseId",
                table: "ArrivalFromTheWarehouses",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ArrivalFromTheWarehouses_WorkerId",
                table: "ArrivalFromTheWarehouses",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comings_WarehouseId",
                table: "Comings",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerPassports_ComputerId",
                table: "ComputerPassports",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerPassports_OfficeId",
                table: "ComputerPassports",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerPassports_WarehouseId",
                table: "ComputerPassports",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerPassports_WorkersId",
                table: "ComputerPassports",
                column: "WorkersId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_KeyboardId",
                table: "Computers",
                column: "KeyboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_MemoryDiskId",
                table: "Computers",
                column: "MemoryDiskId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_MotherboardId",
                table: "Computers",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_MouseId",
                table: "Computers",
                column: "MouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_OcId",
                table: "Computers",
                column: "OcId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_PowerUnitId",
                table: "Computers",
                column: "PowerUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_ProcessorId",
                table: "Computers",
                column: "ProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_RamId",
                table: "Computers",
                column: "RamId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_ScreenId",
                table: "Computers",
                column: "ScreenId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_VideoСardId",
                table: "Computers",
                column: "VideoСardId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_WarehouseId",
                table: "Computers",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DeanOfficeId",
                table: "Departments",
                column: "DeanOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_MovingThroughDivisions_ComputerPassportId",
                table: "MovingThroughDivisions",
                column: "ComputerPassportId");

            migrationBuilder.CreateIndex(
                name: "IX_MovingThroughDivisions_OfficeNewId",
                table: "MovingThroughDivisions",
                column: "OfficeNewId");

            migrationBuilder.CreateIndex(
                name: "IX_MovingThroughDivisions_OfficeOldId",
                table: "MovingThroughDivisions",
                column: "OfficeOldId");

            migrationBuilder.CreateIndex(
                name: "IX_MovingThroughDivisions_WorkersId",
                table: "MovingThroughDivisions",
                column: "WorkersId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_DepartmentId",
                table: "Offices",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairComputers_ComputerPassportId",
                table: "RepairComputers",
                column: "ComputerPassportId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairComputers_WorkersId",
                table: "RepairComputers",
                column: "WorkersId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_ApplicationUserId",
                table: "Workers",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_DepartmentId",
                table: "Workers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_WarehouseId",
                table: "Workers",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_WriteDowns_ComputerPassportId",
                table: "WriteDowns",
                column: "ComputerPassportId");

            migrationBuilder.CreateIndex(
                name: "IX_WriteDowns_WorkersId",
                table: "WriteDowns",
                column: "WorkersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArrivalFromTheWarehouses");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comings");

            migrationBuilder.DropTable(
                name: "MovingThroughDivisions");

            migrationBuilder.DropTable(
                name: "RepairComputers");

            migrationBuilder.DropTable(
                name: "WriteDowns");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ComputerPassports");

            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Keyboards");

            migrationBuilder.DropTable(
                name: "MemoryDisks");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "Mouses");

            migrationBuilder.DropTable(
                name: "Ocs");

            migrationBuilder.DropTable(
                name: "PowerUnits");

            migrationBuilder.DropTable(
                name: "Processor");

            migrationBuilder.DropTable(
                name: "Rams");

            migrationBuilder.DropTable(
                name: "Screens");

            migrationBuilder.DropTable(
                name: "VideoCards");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "DeanOffices");
        }
    }
}

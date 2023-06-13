using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebQuanLyBanHang.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassifyProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassifyProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Age = table.Column<double>(type: "float", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    City = table.Column<int>(type: "int", nullable: true),
                    District = table.Column<int>(type: "int", nullable: true),
                    ward = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerStatuss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerStatuss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    City = table.Column<int>(type: "int", nullable: false),
                    District = table.Column<int>(type: "int", nullable: false),
                    Wards = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MethodDeliverys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodDeliverys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderInfoContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInfoContents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderSources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsCheck = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SingleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupCode = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    City = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.RoleId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Skype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avartar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentSchedules_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagementCancellations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementCancellations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagementCancellations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerManages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StaffMKTId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StaffSaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SplitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerStatusId = table.Column<int>(type: "int", nullable: false),
                    GroupCustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SplitUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerManages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerManages_CustomerStatuss_CustomerStatusId",
                        column: x => x.CustomerStatusId,
                        principalTable: "CustomerStatuss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerManages_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerManages_GroupCustomers_GroupCustomerId",
                        column: x => x.GroupCustomerId,
                        principalTable: "GroupCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Quanlity = table.Column<double>(type: "float", nullable: false),
                    InventoryNumber = table.Column<double>(type: "float", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    InitialPrice = table.Column<double>(type: "float", nullable: true),
                    Mass = table.Column<double>(type: "float", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Expired = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    StatusProductId = table.Column<int>(type: "int", nullable: false),
                    ClassifyProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ClassifyProducts_ClassifyProductId",
                        column: x => x.ClassifyProductId,
                        principalTable: "ClassifyProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_StatusProducts_StatusProductId",
                        column: x => x.StatusProductId,
                        principalTable: "StatusProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IntoMoney = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    TransportFee = table.Column<double>(type: "float", nullable: false),
                    Surcharge = table.Column<double>(type: "float", nullable: false),
                    DeclarePrice = table.Column<double>(type: "float", nullable: false),
                    Prepay = table.Column<double>(type: "float", nullable: false),
                    Payments = table.Column<double>(type: "float", nullable: false),
                    StillOwed = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagementOrderDates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DayShipping = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinishDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConfirmationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementOrderDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagementOrderDates_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagementOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderInfoContentId = table.Column<int>(type: "int", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    MethodDeliveryId = table.Column<int>(type: "int", nullable: false),
                    OrderSourceId = table.Column<int>(type: "int", nullable: false),
                    SingleTypeId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagementOrders_MethodDeliverys_MethodDeliveryId",
                        column: x => x.MethodDeliveryId,
                        principalTable: "MethodDeliverys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagementOrders_OrderInfoContents_OrderInfoContentId",
                        column: x => x.OrderInfoContentId,
                        principalTable: "OrderInfoContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagementOrders_OrderSources_OrderSourceId",
                        column: x => x.OrderSourceId,
                        principalTable: "OrderSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagementOrders_OrderStatuss_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagementOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManagementOrders_SingleTypes_SingleTypeId",
                        column: x => x.SingleTypeId,
                        principalTable: "SingleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManageOrderss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsOrderActive = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManageOrderss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManageOrderss_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManageOrderss_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("8681b0e2-e6fd-4c8b-8977-de04987f80ba"), "5083e979-a914-4334-a83b-e9f6e0574a34", "Quản lý MKT", "MgMKT", null },
                    { new Guid("bc861e4d-6504-4f65-a4cf-e2d3f60d6a1f"), "cb8d8b4e-b4a5-4b4a-81ef-c8d6c885dede", "Nhân viên MKT", "MKT", null },
                    { new Guid("eaa7d4c6-f51e-4e0e-88b4-556f3550afa8"), "a04dd813-cca5-4f67-b61d-a57296603154", "Quản trị viên", "Admin", null },
                    { new Guid("fd106bef-1b44-44c5-91d5-ca250da233dc"), "05716dbb-73fa-413a-95c1-78068c9d9890", "Nhân viên Sale", "Sale", null }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("8681b0e2-e6fd-4c8b-8977-de04987f80ba"), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("bc861e4d-6504-4f65-a4cf-e2d3f60d6a1f"), new Guid("40a76602-1634-4d58-8e74-522d40e7f524") },
                    { new Guid("eaa7d4c6-f51e-4e0e-88b4-556f3550afa8"), new Guid("37dc78be-5899-4092-9f31-7c336837a531") },
                    { new Guid("fd106bef-1b44-44c5-91d5-ca250da233dc"), new Guid("e48e4bfc-c4e7-4346-a306-8c455d1241e3") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avartar", "CityId", "ConcurrencyStamp", "DateCreated", "DateOfBirth", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sex", "Skype", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("37dc78be-5899-4092-9f31-7c336837a531"), 0, "Admin", "", 1, "2ec08d6a-d16f-4f88-bc1b-10793e88e7c1", new DateTime(2023, 6, 10, 23, 40, 12, 737, DateTimeKind.Local).AddTicks(8002), new DateTime(2023, 6, 10, 23, 40, 12, 737, DateTimeKind.Local).AddTicks(8003), "Admin123@gmail.com", true, "Admin", false, null, "Admin123@gmail.com", "Admin", "AQAAAAEAACcQAAAAEGAzRpiYavvez5YOK2v/JmTY5N/niygqfRNuedoAuYNWM6jttDVdDTpVpvbAqdwu0w==", "0369852147", false, "", false, "", false, "Admin" },
                    { new Guid("40a76602-1634-4d58-8e74-522d40e7f524"), 0, "MKT123", "", 1, "8c3816f4-0b7e-4d47-b6dd-5d03883a4dd1", new DateTime(2023, 6, 10, 23, 40, 12, 768, DateTimeKind.Local).AddTicks(3468), new DateTime(2023, 6, 10, 23, 40, 12, 768, DateTimeKind.Local).AddTicks(3469), "NhanvienMKT@gmail.com", true, "Đặng Xuân MKT", false, null, "MKT123@gmail.com", "MKT123", "AQAAAAEAACcQAAAAEE3BcpX6fR+fY3NLYBlCeJJ8h60IUYLnjfpaOuHk9IE4q9e7KoQO5xt84IzKCUN14g==", "0369852145", false, "", false, "", false, "MKT123" },
                    { new Guid("8e2027cb-cec4-40d9-9d53-f7e28483d3cb"), 0, "MGMKT123", "", 1, "f3530df3-8e3f-4112-a514-1667044a2010", new DateTime(2023, 6, 10, 23, 40, 12, 782, DateTimeKind.Local).AddTicks(1716), new DateTime(2023, 6, 10, 23, 40, 12, 782, DateTimeKind.Local).AddTicks(1718), "QuanlynhanvienMKT@gmail.com", true, "Trần Văn Phường", false, null, "MKT123@gmail.com", "MGMKT123", "AQAAAAEAACcQAAAAEH0PdHFzveDJZL7j2NigtfB8mXOWGQowTpdyGcY9WeCU6PIMrhXL/di5BqgVz4beVA==", "0369852150", false, "", false, "", false, "MGMKT123" },
                    { new Guid("e48e4bfc-c4e7-4346-a306-8c455d1241e3"), 0, "Sale123", "", 1, "2ce83d2c-c524-47b6-8bbf-6e72f990957a", new DateTime(2023, 6, 10, 23, 40, 12, 754, DateTimeKind.Local).AddTicks(5922), new DateTime(2023, 6, 10, 23, 40, 12, 754, DateTimeKind.Local).AddTicks(5923), "NhanvienSale@gmail.com", true, "Bùi Xuân Sale", false, null, "Sale123@gmail.com", "Sale123", "AQAAAAEAACcQAAAAEO+qx8KIKCHWioGgOpyXBj987CUxIkvqkvdNwOQf1tRfcHtO+wPj4mzP2HmRFQb1gA==", "0369852114", false, "", false, "", false, "Sale123" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentSchedules_CustomerId",
                table: "AppointmentSchedules",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerManages_CustomerId",
                table: "CustomerManages",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerManages_CustomerStatusId",
                table: "CustomerManages",
                column: "CustomerStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerManages_GroupCustomerId",
                table: "CustomerManages",
                column: "GroupCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseOrders_OrderId",
                table: "ExpenseOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementCancellations_CustomerId",
                table: "ManagementCancellations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementOrderDates_OrderId",
                table: "ManagementOrderDates",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementOrders_MethodDeliveryId",
                table: "ManagementOrders",
                column: "MethodDeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementOrders_OrderId",
                table: "ManagementOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementOrders_OrderInfoContentId",
                table: "ManagementOrders",
                column: "OrderInfoContentId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementOrders_OrderSourceId",
                table: "ManagementOrders",
                column: "OrderSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementOrders_OrderStatusId",
                table: "ManagementOrders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementOrders_SingleTypeId",
                table: "ManagementOrders",
                column: "SingleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ManageOrderss_CustomerId",
                table: "ManageOrderss",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ManageOrderss_OrderId",
                table: "ManageOrderss",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_OrderId",
                table: "ProductOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_ProductId",
                table: "ProductOrders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ClassifyProductId",
                table: "Products",
                column: "ClassifyProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StatusProductId",
                table: "Products",
                column: "StatusProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitId",
                table: "Products",
                column: "UnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentSchedules");

            migrationBuilder.DropTable(
                name: "CustomerManages");

            migrationBuilder.DropTable(
                name: "DeliveryAddress");

            migrationBuilder.DropTable(
                name: "ExpenseOrders");

            migrationBuilder.DropTable(
                name: "ManagementCancellations");

            migrationBuilder.DropTable(
                name: "ManagementOrderDates");

            migrationBuilder.DropTable(
                name: "ManagementOrders");

            migrationBuilder.DropTable(
                name: "ManageOrderss");

            migrationBuilder.DropTable(
                name: "ProductOrders");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "CustomerStatuss");

            migrationBuilder.DropTable(
                name: "GroupCustomers");

            migrationBuilder.DropTable(
                name: "MethodDeliverys");

            migrationBuilder.DropTable(
                name: "OrderInfoContents");

            migrationBuilder.DropTable(
                name: "OrderSources");

            migrationBuilder.DropTable(
                name: "OrderStatuss");

            migrationBuilder.DropTable(
                name: "SingleTypes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ClassifyProducts");

            migrationBuilder.DropTable(
                name: "StatusProducts");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}

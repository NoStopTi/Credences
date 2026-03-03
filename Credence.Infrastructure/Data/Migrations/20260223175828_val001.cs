using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Credence.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class val001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AU_Roles",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    DisplayRoleName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AU_Roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AU_User",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(180)", maxLength: 180, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(180)", maxLength: 180, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastLogin = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PasswordChangedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    SendCodeByEmailDisabledAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Image = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Age = table.Column<int>(type: "INT", maxLength: 3, nullable: true),
                    Gender = table.Column<sbyte>(type: "TINYINT", maxLength: 2, nullable: true),
                    UserName = table.Column<string>(type: "varchar(180)", maxLength: 180, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(180)", maxLength: 180, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(180)", maxLength: 180, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(180)", maxLength: 180, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AU_User", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PF_Businesses",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    IsDeletedAt = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<byte[]>(type: "BINARY(16)", nullable: true),
                    CompanyId = table.Column<byte[]>(type: "BINARY(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PF_Businesses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SA_Categories",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    IsDeletedAt = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    CompanyId = table.Column<byte[]>(type: "BINARY(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SA_Categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AU_RoleClaims",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    RoleId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    ClaimType = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AU_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AU_RoleClaims_AU_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AU_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AU_UserClaims",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    UserId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    ClaimType = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AU_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AU_UserClaims_AU_User_UserId",
                        column: x => x.UserId,
                        principalTable: "AU_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AU_UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<byte[]>(type: "BINARY(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AU_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AU_UserLogins_AU_User_UserId",
                        column: x => x.UserId,
                        principalTable: "AU_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AU_UserRoles",
                columns: table => new
                {
                    UserId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    RoleId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AU_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AU_UserRoles_AU_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AU_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AU_UserRoles_AU_User_UserId",
                        column: x => x.UserId,
                        principalTable: "AU_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AU_UserTokens",
                columns: table => new
                {
                    UserId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AU_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AU_UserTokens_AU_User_UserId",
                        column: x => x.UserId,
                        principalTable: "AU_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PF_Companies",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    LegalName = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TradeName = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastStatusChanged = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    IsActive = table.Column<sbyte>(type: "TINYINT", nullable: false),
                    BusinessId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    CNPJ = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    IsDeletedAt = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<byte[]>(type: "BINARY(16)", nullable: true),
                    CompanyId = table.Column<byte[]>(type: "BINARY(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PF_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PF_Companies_PF_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "PF_Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SA_Transactions",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    Title = table.Column<string>(type: "NVARCHAR(80)", maxLength: 80, nullable: false),
                    PaidOrReceivedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Type = table.Column<short>(type: "SMALLINT", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    IsDeletedAt = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    CompanyId = table.Column<byte[]>(type: "BINARY(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SA_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SA_Transactions_SA_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "SA_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AU_UserCompanies",
                columns: table => new
                {
                    UserId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    CompanyId = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    IsDeletedAt = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AU_UserCompanies", x => new { x.UserId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_AU_UserCompanies_AU_User_UserId",
                        column: x => x.UserId,
                        principalTable: "AU_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AU_UserCompanies_PF_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "PF_Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PF_Addresses",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    Country = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false, defaultValue: "Brasil")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Street = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Number = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Neighborhood = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ZipCode = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Complement = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    IsDeletedAt = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<byte[]>(type: "BINARY(16)", nullable: true),
                    CompanyId = table.Column<byte[]>(type: "BINARY(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PF_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PF_Addresses_PF_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "PF_Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PF_Contacts",
                columns: table => new
                {
                    Id = table.Column<byte[]>(type: "BINARY(16)", nullable: false),
                    Landline = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mobile = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Work = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Home = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WhatsApp = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telegram = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Skype = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Other = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WebSite = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    IsDeletedAt = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME(6)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<byte[]>(type: "BINARY(16)", nullable: true),
                    CompanyId = table.Column<byte[]>(type: "BINARY(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PF_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PF_Contacts_PF_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "PF_Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PF_SocialNetworks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactId = table.Column<byte[]>(type: "BINARY(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PF_SocialNetworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PF_SocialNetworks_PF_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "PF_Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AU_Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "DisplayRoleName", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new byte[] { 224, 4, 37, 63, 137, 79, 211, 65, 154, 12, 3, 5, 232, 44, 51, 1 }, "9a7b6c5d-1234-4abc-8def-1a2b3c4d5e6f", "Administrador", "admin", "ADMIN" },
                    { new byte[] { 46, 107, 31, 140, 74, 61, 124, 79, 155, 18, 110, 90, 157, 60, 79, 129 }, "b7a3c9f4-2e61-4d8b-a5c2-9f3e7a1d6b80", "Two-Factor Pending", "two_factor_pending", "TWO_FACTOR_PENDING" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AU_RoleClaims_RoleId",
                table: "AU_RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AU_Roles_Id",
                table: "AU_Roles",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AU_Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AU_User",
                column: "NormalizedEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AU_User",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AU_UserClaims_UserId",
                table: "AU_UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AU_UserCompanies_CompanyId",
                table: "AU_UserCompanies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_AU_UserLogins_UserId",
                table: "AU_UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AU_UserRoles_RoleId",
                table: "AU_UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PF_Addresses_CompanyId",
                table: "PF_Addresses",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PF_Companies_BusinessId",
                table: "PF_Companies",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_PF_Contacts_CompanyId",
                table: "PF_Contacts",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PF_SocialNetworks_ContactId",
                table: "PF_SocialNetworks",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_SA_Transactions_CategoryId",
                table: "SA_Transactions",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AU_RoleClaims");

            migrationBuilder.DropTable(
                name: "AU_UserClaims");

            migrationBuilder.DropTable(
                name: "AU_UserCompanies");

            migrationBuilder.DropTable(
                name: "AU_UserLogins");

            migrationBuilder.DropTable(
                name: "AU_UserRoles");

            migrationBuilder.DropTable(
                name: "AU_UserTokens");

            migrationBuilder.DropTable(
                name: "PF_Addresses");

            migrationBuilder.DropTable(
                name: "PF_SocialNetworks");

            migrationBuilder.DropTable(
                name: "SA_Transactions");

            migrationBuilder.DropTable(
                name: "AU_Roles");

            migrationBuilder.DropTable(
                name: "AU_User");

            migrationBuilder.DropTable(
                name: "PF_Contacts");

            migrationBuilder.DropTable(
                name: "SA_Categories");

            migrationBuilder.DropTable(
                name: "PF_Companies");

            migrationBuilder.DropTable(
                name: "PF_Businesses");
        }
    }
}

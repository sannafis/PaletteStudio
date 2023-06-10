using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaletteStudioApi.Data.PaletteStudioMigrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Nickname = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colours",
                columns: table => new
                {
                    HexCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colours", x => x.HexCode);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "Palettes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Privacy = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palettes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Palettes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ColourGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BackgroundColourHexCode = table.Column<string>(type: "TEXT", nullable: true),
                    PaletteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColourGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColourGroups_Colours_BackgroundColourHexCode",
                        column: x => x.BackgroundColourHexCode,
                        principalTable: "Colours",
                        principalColumn: "HexCode");
                    table.ForeignKey(
                        name: "FK_ColourGroups_Palettes_PaletteId",
                        column: x => x.PaletteId,
                        principalTable: "Palettes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ForegroundColours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ColourGroupId = table.Column<int>(type: "INTEGER", nullable: true),
                    ColourHexCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForegroundColours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForegroundColours_ColourGroups_ColourGroupId",
                        column: x => x.ColourGroupId,
                        principalTable: "ColourGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ForegroundColours_Colours_ColourHexCode",
                        column: x => x.ColourHexCode,
                        principalTable: "Colours",
                        principalColumn: "HexCode");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e97e6f5-e05f-43fd-b33f-bdb6ff465658", "53e5000e-46ad-4611-8e84-a9a761eb8951", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "608616ab-2cb2-4823-9021-b11452f80986", "217d5e55-8523-45af-a6c9-acd4b3610a01", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Nickname", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "354492fe-30eb-4261-b5b1-4a291cb4001d", 0, "532199d4-7eb6-499f-bf6c-4c8c39d142dd", "user@palettestudio.ca", true, "Palette Studio", "User", false, null, "Test User", "USER@PALETTESTUDIO.CA", "USER@PALETTESTUDIO.CA", "AQAAAAEAACcQAAAAEOr31kbBVdX6+SkueWWTi7xxhpmb7P22s6E597OXe3hEKyTgkAH5kcUxSnGTPLgL2Q==", null, false, "1d193676-5548-47fd-99d2-6a5921538d0b", false, "user@palettestudio.ca" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "Nickname", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dc3fbe21-8f2a-4ac3-9516-91957919b028", 0, "b8c2e016-9c08-4c6f-b358-03e10447c170", "admin@palettestudio.ca", true, "Palette Studio", "Admin", false, null, "Admin", "ADMIN@PALETTESTUDIO.CA", "ADMIN@PALETTESTUDIO.CA", "AQAAAAEAACcQAAAAEOx3yYtnYGGcCmF2vYLiAjQRr2wO1NsZFM6bMaEI+GknQkr1sRnjqCTpDbaYShYpEA==", null, false, "b1bd3ca1-4fb2-42d4-ab87-be77a04832b2", false, "admin@palettestudio.ca" });

            migrationBuilder.InsertData(
                table: "Colours",
                column: "HexCode",
                value: "#000000");

            migrationBuilder.InsertData(
                table: "Colours",
                column: "HexCode",
                value: "#3E5F8A");

            migrationBuilder.InsertData(
                table: "Colours",
                column: "HexCode",
                value: "#4C9141");

            migrationBuilder.InsertData(
                table: "Colours",
                column: "HexCode",
                value: "#5D9B9B");

            migrationBuilder.InsertData(
                table: "Colours",
                column: "HexCode",
                value: "#89AC76");

            migrationBuilder.InsertData(
                table: "Colours",
                column: "HexCode",
                value: "#8B8C7A");

            migrationBuilder.InsertData(
                table: "Colours",
                column: "HexCode",
                value: "#9B111E");

            migrationBuilder.InsertData(
                table: "Colours",
                column: "HexCode",
                value: "#B44C43");

            migrationBuilder.InsertData(
                table: "Colours",
                column: "HexCode",
                value: "#F3A505");

            migrationBuilder.InsertData(
                table: "Colours",
                column: "HexCode",
                value: "#F80000");

            migrationBuilder.InsertData(
                table: "Colours",
                column: "HexCode",
                value: "#FFFFFF");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "608616ab-2cb2-4823-9021-b11452f80986", "354492fe-30eb-4261-b5b1-4a291cb4001d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0e97e6f5-e05f-43fd-b33f-bdb6ff465658", "dc3fbe21-8f2a-4ac3-9516-91957919b028" });

            migrationBuilder.InsertData(
                table: "Palettes",
                columns: new[] { "Id", "Name", "Privacy", "UserId" },
                values: new object[] { 1, "Palette 1", "public", "354492fe-30eb-4261-b5b1-4a291cb4001d" });

            migrationBuilder.InsertData(
                table: "Palettes",
                columns: new[] { "Id", "Name", "Privacy", "UserId" },
                values: new object[] { 2, "Palette 2", "private", "354492fe-30eb-4261-b5b1-4a291cb4001d" });

            migrationBuilder.InsertData(
                table: "Palettes",
                columns: new[] { "Id", "Name", "Privacy", "UserId" },
                values: new object[] { 3, "Palette 3", "private", "354492fe-30eb-4261-b5b1-4a291cb4001d" });

            migrationBuilder.InsertData(
                table: "ColourGroups",
                columns: new[] { "Id", "BackgroundColourHexCode", "PaletteId" },
                values: new object[] { 1, "#FFFFFF", 1 });

            migrationBuilder.InsertData(
                table: "ColourGroups",
                columns: new[] { "Id", "BackgroundColourHexCode", "PaletteId" },
                values: new object[] { 2, "#F3A505", 1 });

            migrationBuilder.InsertData(
                table: "ColourGroups",
                columns: new[] { "Id", "BackgroundColourHexCode", "PaletteId" },
                values: new object[] { 3, "#F80000", 2 });

            migrationBuilder.InsertData(
                table: "ColourGroups",
                columns: new[] { "Id", "BackgroundColourHexCode", "PaletteId" },
                values: new object[] { 4, "#000000", 3 });

            migrationBuilder.InsertData(
                table: "ColourGroups",
                columns: new[] { "Id", "BackgroundColourHexCode", "PaletteId" },
                values: new object[] { 5, "#8B8C7A", 3 });

            migrationBuilder.InsertData(
                table: "ForegroundColours",
                columns: new[] { "Id", "ColourGroupId", "ColourHexCode" },
                values: new object[] { 1, 1, "#9B111E" });

            migrationBuilder.InsertData(
                table: "ForegroundColours",
                columns: new[] { "Id", "ColourGroupId", "ColourHexCode" },
                values: new object[] { 2, 1, "#F80000" });

            migrationBuilder.InsertData(
                table: "ForegroundColours",
                columns: new[] { "Id", "ColourGroupId", "ColourHexCode" },
                values: new object[] { 3, 1, "#8B8C7A" });

            migrationBuilder.InsertData(
                table: "ForegroundColours",
                columns: new[] { "Id", "ColourGroupId", "ColourHexCode" },
                values: new object[] { 4, 1, "#4C9141" });

            migrationBuilder.InsertData(
                table: "ForegroundColours",
                columns: new[] { "Id", "ColourGroupId", "ColourHexCode" },
                values: new object[] { 5, 3, "#B44C43" });

            migrationBuilder.InsertData(
                table: "ForegroundColours",
                columns: new[] { "Id", "ColourGroupId", "ColourHexCode" },
                values: new object[] { 6, 3, "#000000" });

            migrationBuilder.InsertData(
                table: "ForegroundColours",
                columns: new[] { "Id", "ColourGroupId", "ColourHexCode" },
                values: new object[] { 7, 3, "#F3A505" });

            migrationBuilder.InsertData(
                table: "ForegroundColours",
                columns: new[] { "Id", "ColourGroupId", "ColourHexCode" },
                values: new object[] { 8, 4, "#3E5F8A" });

            migrationBuilder.InsertData(
                table: "ForegroundColours",
                columns: new[] { "Id", "ColourGroupId", "ColourHexCode" },
                values: new object[] { 9, 4, "#F3A505" });

            migrationBuilder.InsertData(
                table: "ForegroundColours",
                columns: new[] { "Id", "ColourGroupId", "ColourHexCode" },
                values: new object[] { 10, 5, "#9B111E" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ColourGroups_BackgroundColourHexCode",
                table: "ColourGroups",
                column: "BackgroundColourHexCode");

            migrationBuilder.CreateIndex(
                name: "IX_ColourGroups_PaletteId",
                table: "ColourGroups",
                column: "PaletteId");

            migrationBuilder.CreateIndex(
                name: "IX_ForegroundColours_ColourGroupId",
                table: "ForegroundColours",
                column: "ColourGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ForegroundColours_ColourHexCode",
                table: "ForegroundColours",
                column: "ColourHexCode");

            migrationBuilder.CreateIndex(
                name: "IX_Palettes_UserId",
                table: "Palettes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "ForegroundColours");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ColourGroups");

            migrationBuilder.DropTable(
                name: "Colours");

            migrationBuilder.DropTable(
                name: "Palettes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaletteStudioApi.Data.PaletteStudioMigrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Palettes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palettes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColourGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BackgroundColourHexCode = table.Column<string>(type: "TEXT", nullable: false),
                    PaletteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColourGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColourGroups_Colours_BackgroundColourHexCode",
                        column: x => x.BackgroundColourHexCode,
                        principalTable: "Colours",
                        principalColumn: "HexCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ColourGroups_Palettes_PaletteId",
                        column: x => x.PaletteId,
                        principalTable: "Palettes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForegroundColours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ColourGroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    ColourHexCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForegroundColours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForegroundColours_ColourGroups_ColourGroupId",
                        column: x => x.ColourGroupId,
                        principalTable: "ColourGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForegroundColours_Colours_ColourHexCode",
                        column: x => x.ColourHexCode,
                        principalTable: "Colours",
                        principalColumn: "HexCode",
                        onDelete: ReferentialAction.Cascade);
                });

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
                table: "Palettes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Palette 1" });

            migrationBuilder.InsertData(
                table: "Palettes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Palette 2" });

            migrationBuilder.InsertData(
                table: "Palettes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Palette 3" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForegroundColours");

            migrationBuilder.DropTable(
                name: "ColourGroups");

            migrationBuilder.DropTable(
                name: "Colours");

            migrationBuilder.DropTable(
                name: "Palettes");
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientWarningApp.Data.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PractitionerAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsAdmin = table.Column<sbyte>(type: "tinyint", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PatientAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PractitionerId = table.Column<int>(type: "int", nullable: false),
                    IsAdmin = table.Column<sbyte>(type: "tinyint", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientAccounts_PractitionerAccounts_PractitionerId",
                        column: x => x.PractitionerId,
                        principalTable: "PractitionerAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "PatientAccounts",
                columns: new[] { "Id", "Email", "IsAdmin", "Password", "PatientId", "PractitionerId", "Username" },
                values: new object[] { 1, "Patient1@example.com", (sbyte)0, "changeMe", 0, 0, "Username" });

            migrationBuilder.InsertData(
                table: "PatientAccounts",
                columns: new[] { "Id", "Email", "IsAdmin", "Password", "PatientId", "PractitionerId", "Username" },
                values: new object[] { 2, "Patient1@example.com", (sbyte)0, "changeMe", 0, 0, "Username" });

            migrationBuilder.InsertData(
                table: "PractitionerAccounts",
                columns: new[] { "Id", "Email", "IsAdmin", "Password", "Username" },
                values: new object[] { 1, "richardsi@example.com", (sbyte)1, "richardsi", "richardsi" });

            migrationBuilder.CreateIndex(
                name: "Idx_Username",
                table: "PatientAccounts",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientAccounts_PractitionerId",
                table: "PatientAccounts",
                column: "PractitionerId");

            migrationBuilder.CreateIndex(
                name: "Idx_Username",
                table: "PractitionerAccounts",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientAccounts");

            migrationBuilder.DropTable(
                name: "PractitionerAccounts");
        }
    }
}

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
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HouseNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StreetName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PractitionerAccounts",
                columns: table => new
                {
                    PractitionerAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsAdmin = table.Column<sbyte>(type: "tinyint", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PractitionerAccounts", x => x.PractitionerAccountId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Practitioners",
                columns: table => new
                {
                    PractitionerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    DOB = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practitioners", x => x.PractitionerId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PatientAccounts",
                columns: table => new
                {
                    PatientAccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PractitionerAccountId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsAdmin = table.Column<sbyte>(type: "tinyint", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAccounts", x => x.PatientAccountId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "PatientAccounts",
                columns: new[] { "PatientAccountId", "Email", "Id", "IsAdmin", "Password", "PatientId", "PractitionerAccountId", "Username" },
                values: new object[] { 2, "Patient1@example.com", 2, (sbyte)0, "changeMe", 0, 0, "Username" });

            migrationBuilder.InsertData(
                table: "PractitionerAccounts",
                columns: new[] { "PractitionerAccountId", "Email", "Id", "IsAdmin", "Password", "Username" },
                values: new object[] { 1, "richardsi@example.com", 1, (sbyte)1, "password", "abigail" });

            migrationBuilder.InsertData(
                table: "Practitioners",
                columns: new[] { "PractitionerId", "AddressId", "DOB", "FirstName", "Gender", "Id", "LastName", "MobileNumber", "Title" },
                values: new object[] { 1, null, "08/08/2000", "Abigail", "Female", 1, "Knowles", "1234567890", "Miss" });

            migrationBuilder.InsertData(
                table: "PatientAccounts",
                columns: new[] { "PatientAccountId", "Email", "Id", "IsAdmin", "Password", "PatientId", "PractitionerAccountId", "Username" },
                values: new object[] { 1, "Patient1@example.com", 1, (sbyte)0, "changeMe", 0, 1, "Username" });

            migrationBuilder.CreateIndex(
                name: "IX_PatientAccounts_PractitionerAccountId",
                table: "PatientAccounts",
                column: "PractitionerAccountId");

            migrationBuilder.CreateIndex(
                name: "Idx_FirstName",
                table: "Practitioners",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "Idx_LastName",
                table: "Practitioners",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_Practitioners_AddressId",
                table: "Practitioners",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientAccounts");

            migrationBuilder.DropTable(
                name: "Practitioners");

            migrationBuilder.DropTable(
                name: "PractitionerAccounts");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}

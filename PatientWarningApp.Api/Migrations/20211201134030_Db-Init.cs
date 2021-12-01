using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientWarningApp.Api.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MediaEntity",
                columns: table => new
                {
                    MediaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ReleaseDate = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.MediaId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartDate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SeizureTypes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SeizureFrequencies = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SeizureTimes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SeizureTriggers = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SideEffects = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Notes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    DOB = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
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
                    Age = table.Column<int>(type: "int", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practitioners", x => x.PractitionerId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReviewedMediaEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    EpilepsyRating = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    SeizureTriggerTimes = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewedMedia", x => x.Id);
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
                    PractitionerAccountEntityPractitionerAccountId = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsAdmin = table.Column<sbyte>(type: "tinyint", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAccounts", x => x.PatientAccountId);
                    table.ForeignKey(
                        name: "FK_PatientAccounts_PractitionerAccounts_PractitionerAccountEnti~",
                        column: x => x.PractitionerAccountEntityPractitionerAccountId,
                        principalTable: "PractitionerAccounts",
                        principalColumn: "PractitionerAccountId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAccounts_PractitionerAccountEntityPractitionerAccount~",
                table: "PatientAccounts",
                column: "PractitionerAccountEntityPractitionerAccountId");

            migrationBuilder.CreateIndex(
                name: "Idx_FirstName",
                table: "Practitioners",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "Idx_LastName",
                table: "Practitioners",
                column: "LastName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaEntity");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "PatientAccounts");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Practitioners");

            migrationBuilder.DropTable(
                name: "ReviewedMediaEntity");

            migrationBuilder.DropTable(
                name: "PractitionerAccounts");
        }
    }
}

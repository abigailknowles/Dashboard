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
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ReleaseDate = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
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
                name: "ReviewedMedia",
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
                    MobileNumber = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_Practitioners_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_PatientAccounts_PractitionerAccounts_PractitionerAccountId",
                        column: x => x.PractitionerAccountId,
                        principalTable: "PractitionerAccounts",
                        principalColumn: "PractitionerAccountId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAccounts_PractitionerAccountId",
                table: "PatientAccounts",
                column: "PractitionerAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AddressId",
                table: "Patients",
                column: "AddressId");

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
                name: "Media");

            migrationBuilder.DropTable(
                name: "PatientAccounts");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Practitioners");

            migrationBuilder.DropTable(
                name: "ReviewedMedia");

            migrationBuilder.DropTable(
                name: "PractitionerAccounts");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientWarningApp.Api.Migrations
{
    public partial class entityIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PractitionerId",
                table: "PractitionerAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "PatientAccounts",
                columns: new[] { "PatientAccountId", "Email", "Id", "IsAdmin", "Password", "PatientId", "PractitionerAccountEntityPractitionerAccountId", "PractitionerAccountId", "Username" },
                values: new object[] { 1, "abigailknowles@patientportal.com", 0, (sbyte)0, "password", 0, null, 0, "abigailknowles01" });

            migrationBuilder.InsertData(
                table: "PatientAccounts",
                columns: new[] { "PatientAccountId", "Email", "Id", "IsAdmin", "Password", "PatientId", "PractitionerAccountEntityPractitionerAccountId", "PractitionerAccountId", "Username" },
                values: new object[] { 2, "bethanyknowles@patientportal.com", 0, (sbyte)0, "password", 0, null, 0, "bethanyknowles" });

            migrationBuilder.InsertData(
                table: "PractitionerAccounts",
                columns: new[] { "PractitionerAccountId", "Email", "Id", "IsAdmin", "Password", "PractitionerId", "Username" },
                values: new object[] { 1, "nathanknowles@patientportal.com", 0, (sbyte)1, "password", 0, "nathanknowles" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PatientAccounts",
                keyColumn: "PatientAccountId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PatientAccounts",
                keyColumn: "PatientAccountId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PractitionerAccounts",
                keyColumn: "PractitionerAccountId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "PractitionerId",
                table: "PractitionerAccounts");
        }
    }
}

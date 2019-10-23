using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class EFCoreCodeFirstSampleModelsPersonsContextSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "EmployeeId", "FirstName", "LastName" },
                values: new object[] { 1L, "Uncle", "Bob" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "EmployeeId", "FirstName", "LastName" },
                values: new object[] { 2L, "Jan", "Kirsten" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "EmployeeId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "EmployeeId",
                keyValue: 2L);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kolokwium.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Musicians",
                columns: new[] { "IdMusician", "FirstName", "LastName", "NickName" },
                values: new object[] { 3, "Jacek", "Macek", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musicians",
                keyColumn: "IdMusician",
                keyValue: 3);
        }
    }
}

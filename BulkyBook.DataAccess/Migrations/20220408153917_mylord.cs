using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyBook.DataAccess.Migrations
{
    public partial class mylord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToDate",
                table: "CreateLeaves",
                newName: "Todate");

            migrationBuilder.RenameColumn(
                name: "FromDate",
                table: "CreateLeaves",
                newName: "Fromdate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Todate",
                table: "CreateLeaves",
                newName: "ToDate");

            migrationBuilder.RenameColumn(
                name: "Fromdate",
                table: "CreateLeaves",
                newName: "FromDate");
        }
    }
}

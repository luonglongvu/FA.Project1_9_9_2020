using Microsoft.EntityFrameworkCore.Migrations;

namespace FA.Core.Migrations
{
    public partial class EnumT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestType",
                table: "Requests",
                newName: "Requesttype");

            migrationBuilder.AlterColumn<int>(
                name: "Requesttype",
                table: "Requests",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Requesttype",
                table: "Requests",
                newName: "RequestType");

            migrationBuilder.AlterColumn<string>(
                name: "RequestType",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}

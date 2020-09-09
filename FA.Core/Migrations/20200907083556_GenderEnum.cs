using Microsoft.EntityFrameworkCore.Migrations;

namespace FA.Core.Migrations
{
    public partial class GenderEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Trainees",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Gender",
                table: "Trainees",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}

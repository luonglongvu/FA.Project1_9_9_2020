using Microsoft.EntityFrameworkCore.Migrations;

namespace FA.Core.Migrations
{
    public partial class MeoGiang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassAdminId",
                table: "ClassBatches");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "ClassBatches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassAdminId",
                table: "ClassBatches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "ClassBatches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

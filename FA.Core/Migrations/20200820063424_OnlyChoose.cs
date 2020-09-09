using Microsoft.EntityFrameworkCore.Migrations;

namespace FA.Core.Migrations
{
    public partial class OnlyChoose : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mafortype",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "statustype",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "statustype",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "statustype1",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "statustype",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "statustype2",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "statustype",
                table: "ClassBatches");

            migrationBuilder.DropColumn(
                name: "statustype",
                table: "ClassAdmins");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "mafortype",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "statustype",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "statustype",
                table: "Trainees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "statustype1",
                table: "Trainees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "statustype",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "statustype2",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "statustype",
                table: "ClassBatches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "statustype",
                table: "ClassAdmins",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

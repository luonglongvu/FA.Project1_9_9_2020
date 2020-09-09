using Microsoft.EntityFrameworkCore.Migrations;

namespace FA.Core.Migrations
{
    public partial class NewFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassAdminBatches_Trainers_TrainerId",
                table: "ClassAdminBatches");

            migrationBuilder.DropIndex(
                name: "IX_ClassAdminBatches_TrainerId",
                table: "ClassAdminBatches");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "ClassAdminBatches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "ClassAdminBatches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassAdminBatches_TrainerId",
                table: "ClassAdminBatches",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassAdminBatches_Trainers_TrainerId",
                table: "ClassAdminBatches",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "TrainerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

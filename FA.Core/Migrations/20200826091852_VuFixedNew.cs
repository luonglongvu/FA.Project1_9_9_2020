using Microsoft.EntityFrameworkCore.Migrations;

namespace FA.Core.Migrations
{
    public partial class VuFixedNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassAdminBatches_ClassBatches_ClassBatchClassId",
                table: "ClassAdminBatches");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerClassBatches_ClassBatches_ClassBatchClassId",
                table: "TrainerClassBatches");

            migrationBuilder.DropIndex(
                name: "IX_TrainerClassBatches_ClassBatchClassId",
                table: "TrainerClassBatches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassAdminBatches",
                table: "ClassAdminBatches");

            migrationBuilder.DropIndex(
                name: "IX_ClassAdminBatches_ClassAdminId",
                table: "ClassAdminBatches");

            migrationBuilder.DropIndex(
                name: "IX_ClassAdminBatches_ClassBatchClassId",
                table: "ClassAdminBatches");

            migrationBuilder.DropColumn(
                name: "ClassBatchClassId",
                table: "TrainerClassBatches");

            migrationBuilder.DropColumn(
                name: "ClassBatchClassId",
                table: "ClassAdminBatches");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassAdminBatches",
                table: "ClassAdminBatches",
                columns: new[] { "ClassAdminId", "ClassId" });

            migrationBuilder.CreateIndex(
                name: "IX_TrainerClassBatches_ClassId",
                table: "TrainerClassBatches",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAdminBatches_ClassId",
                table: "ClassAdminBatches",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassAdminBatches_ClassBatches_ClassId",
                table: "ClassAdminBatches",
                column: "ClassId",
                principalTable: "ClassBatches",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerClassBatches_ClassBatches_ClassId",
                table: "TrainerClassBatches",
                column: "ClassId",
                principalTable: "ClassBatches",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassAdminBatches_ClassBatches_ClassId",
                table: "ClassAdminBatches");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainerClassBatches_ClassBatches_ClassId",
                table: "TrainerClassBatches");

            migrationBuilder.DropIndex(
                name: "IX_TrainerClassBatches_ClassId",
                table: "TrainerClassBatches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassAdminBatches",
                table: "ClassAdminBatches");

            migrationBuilder.DropIndex(
                name: "IX_ClassAdminBatches_ClassId",
                table: "ClassAdminBatches");

            migrationBuilder.AddColumn<int>(
                name: "ClassBatchClassId",
                table: "TrainerClassBatches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassBatchClassId",
                table: "ClassAdminBatches",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassAdminBatches",
                table: "ClassAdminBatches",
                columns: new[] { "ClassId", "ClassAdminId" });

            migrationBuilder.CreateIndex(
                name: "IX_TrainerClassBatches_ClassBatchClassId",
                table: "TrainerClassBatches",
                column: "ClassBatchClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAdminBatches_ClassAdminId",
                table: "ClassAdminBatches",
                column: "ClassAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAdminBatches_ClassBatchClassId",
                table: "ClassAdminBatches",
                column: "ClassBatchClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassAdminBatches_ClassBatches_ClassBatchClassId",
                table: "ClassAdminBatches",
                column: "ClassBatchClassId",
                principalTable: "ClassBatches",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerClassBatches_ClassBatches_ClassBatchClassId",
                table: "TrainerClassBatches",
                column: "ClassBatchClassId",
                principalTable: "ClassBatches",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

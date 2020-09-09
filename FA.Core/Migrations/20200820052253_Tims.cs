using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FA.Core.Migrations
{
    public partial class Tims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassAdmins",
                columns: table => new
                {
                    ClassAdminId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(maxLength: 255, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Account = table.Column<string>(maxLength: 255, nullable: false),
                    Status = table.Column<string>(nullable: true),
                    statustype = table.Column<int>(nullable: false),
                    AuditTrail = table.Column<string>(maxLength: 255, nullable: false),
                    isDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassAdmins", x => x.ClassAdminId);
                });

            migrationBuilder.CreateTable(
                name: "ClassBatches",
                columns: table => new
                {
                    ClassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(maxLength: 255, nullable: false),
                    ClassCode = table.Column<string>(maxLength: 255, nullable: false),
                    GroupMail = table.Column<string>(maxLength: 255, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(maxLength: 255, nullable: false),
                    DetailLocation = table.Column<string>(maxLength: 255, nullable: false),
                    ClassAdminId = table.Column<int>(nullable: false),
                    TrainerId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    statustype = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 255, nullable: false),
                    AuditTrail = table.Column<string>(maxLength: 255, nullable: false),
                    isDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassBatches", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    TrainerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(maxLength: 255, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Account = table.Column<string>(maxLength: 255, nullable: false),
                    Status = table.Column<string>(nullable: true),
                    statustype = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 255, nullable: false),
                    Unit = table.Column<string>(maxLength: 255, nullable: false),
                    Major = table.Column<string>(nullable: true),
                    mafortype = table.Column<int>(nullable: false),
                    Experience = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 255, nullable: false),
                    AuditTrail = table.Column<string>(maxLength: 255, nullable: false),
                    isDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.TrainerId);
                });

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    TraineeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 255, nullable: false),
                    FamilyPhoneNumber = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    ExternalEmail = table.Column<string>(maxLength: 255, nullable: false),
                    Account = table.Column<string>(maxLength: 255, nullable: false),
                    OnboardDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    statustype1 = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 255, nullable: false),
                    University = table.Column<string>(maxLength: 255, nullable: false),
                    Faculty = table.Column<string>(maxLength: 255, nullable: false),
                    Skill = table.Column<string>(nullable: true),
                    statustype = table.Column<int>(nullable: false),
                    ForeignLanguage = table.Column<string>(maxLength: 255, nullable: false),
                    Level = table.Column<int>(nullable: false),
                    CV = table.Column<string>(maxLength: 255, nullable: false),
                    AllocationStatus = table.Column<string>(maxLength: 255, nullable: false),
                    AuditTrail = table.Column<string>(maxLength: 255, nullable: false),
                    isDelete = table.Column<bool>(nullable: false),
                    ClassBatchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.TraineeId);
                    table.ForeignKey(
                        name: "FK_Trainees_ClassBatches_ClassBatchId",
                        column: x => x.ClassBatchId,
                        principalTable: "ClassBatches",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassAdminBatches",
                columns: table => new
                {
                    ClassId = table.Column<int>(nullable: false),
                    ClassAdminId = table.Column<int>(nullable: false),
                    ClassBatchClassId = table.Column<int>(nullable: true),
                    TrainerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassAdminBatches", x => new { x.ClassId, x.ClassAdminId });
                    table.ForeignKey(
                        name: "FK_ClassAdminBatches_ClassAdmins_ClassAdminId",
                        column: x => x.ClassAdminId,
                        principalTable: "ClassAdmins",
                        principalColumn: "ClassAdminId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassAdminBatches_ClassBatches_ClassBatchClassId",
                        column: x => x.ClassBatchClassId,
                        principalTable: "ClassBatches",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassAdminBatches_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainerClassBatches",
                columns: table => new
                {
                    TrainerId = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false),
                    ClassBatchClassId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerClassBatches", x => new { x.TrainerId, x.ClassId });
                    table.ForeignKey(
                        name: "FK_TrainerClassBatches_ClassBatches_ClassBatchClassId",
                        column: x => x.ClassBatchClassId,
                        principalTable: "ClassBatches",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainerClassBatches_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestType = table.Column<string>(nullable: true),
                    statustype2 = table.Column<int>(nullable: false),
                    Reason = table.Column<string>(maxLength: 255, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ComimmingTime = table.Column<TimeSpan>(nullable: false),
                    LeavingTime = table.Column<TimeSpan>(nullable: false),
                    ExpectedApproval = table.Column<DateTime>(nullable: false),
                    ApprovedTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    statustype = table.Column<int>(nullable: false),
                    AuditTrail = table.Column<string>(maxLength: 255, nullable: false),
                    isDelete = table.Column<bool>(nullable: false),
                    TraineeId = table.Column<int>(nullable: false),
                    ApproverId = table.Column<int>(nullable: false),
                    ClassAdminId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Requests_ClassAdmins_ClassAdminId",
                        column: x => x.ClassAdminId,
                        principalTable: "ClassAdmins",
                        principalColumn: "ClassAdminId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "TraineeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassAdminBatches_ClassAdminId",
                table: "ClassAdminBatches",
                column: "ClassAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAdminBatches_ClassBatchClassId",
                table: "ClassAdminBatches",
                column: "ClassBatchClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAdminBatches_TrainerId",
                table: "ClassAdminBatches",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ClassAdminId",
                table: "Requests",
                column: "ClassAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_TraineeId",
                table: "Requests",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_ClassBatchId",
                table: "Trainees",
                column: "ClassBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerClassBatches_ClassBatchClassId",
                table: "TrainerClassBatches",
                column: "ClassBatchClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassAdminBatches");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "TrainerClassBatches");

            migrationBuilder.DropTable(
                name: "ClassAdmins");

            migrationBuilder.DropTable(
                name: "Trainees");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "ClassBatches");
        }
    }
}

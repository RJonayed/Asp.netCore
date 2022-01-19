using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCore_5.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "groupInfos",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupInfos", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "schools",
                columns: table => new
                {
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    EstDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schools", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    joinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SubjectCode = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    ExamMark = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    GroupInfoGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_subjects_groupInfos_GroupInfoGroupId",
                        column: x => x.GroupInfoGroupId,
                        principalTable: "groupInfos",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BranchLocation = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                    table.ForeignKey(
                        name: "FK_Branches_schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classes", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_classes_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "applicationFroms",
                columns: table => new
                {
                    SlNO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    ApplicantName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthRegistrationNo = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MothrsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContNo = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSelect = table.Column<bool>(type: "bit", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationFroms", x => x.SlNO);
                    table.ForeignKey(
                        name: "FK_applicationFroms_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_applicationFroms_classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "classes",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "FK_applicationFroms_schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "schools",
                        principalColumn: "SchoolId"
                        );
                });

            migrationBuilder.CreateTable(
                name: "selections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SlNos = table.Column<int>(type: "int", nullable: false),
                    ApplicationFromSlNO = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_selections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_selections_applicationFroms_ApplicationFromSlNO",
                        column: x => x.ApplicationFromSlNO,
                        principalTable: "applicationFroms",
                        principalColumn: "SlNO",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_applicationFroms_BranchId",
                table: "applicationFroms",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationFroms_ClassId",
                table: "applicationFroms",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationFroms_SchoolId",
                table: "applicationFroms",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_SchoolId",
                table: "Branches",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_classes_BranchId",
                table: "classes",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_selections_ApplicationFromSlNO",
                table: "selections",
                column: "ApplicationFromSlNO");

            migrationBuilder.CreateIndex(
                name: "IX_subjects_GroupInfoGroupId",
                table: "subjects",
                column: "GroupInfoGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "selections");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "teachers");

            migrationBuilder.DropTable(
                name: "applicationFroms");

            migrationBuilder.DropTable(
                name: "groupInfos");

            migrationBuilder.DropTable(
                name: "classes");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "schools");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCore_5.Data.Migrations
{
    public partial class result : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "applicationFroms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupInfoGroupId",
                table: "applicationFroms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SlDetails",
                columns: table => new
                {
                    SlDetailsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlNO = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    ApplicationFromSlNO = table.Column<int>(type: "int", nullable: true),
                    SelectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlDetails", x => x.SlDetailsID);
                    table.ForeignKey(
                        name: "FK_SlDetails_applicationFroms_ApplicationFromSlNO",
                        column: x => x.ApplicationFromSlNO,
                        principalTable: "applicationFroms",
                        principalColumn: "SlNO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SlDetails_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SlDetails_classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SlDetails_schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "schools",
                        principalColumn: "SchoolId");
                    table.ForeignKey(
                        name: "FK_SlDetails_selections_SelectionId",
                        column: x => x.SelectionId,
                        principalTable: "selections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_applicationFroms_GroupInfoGroupId",
                table: "applicationFroms",
                column: "GroupInfoGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SlDetails_ApplicationFromSlNO",
                table: "SlDetails",
                column: "ApplicationFromSlNO");

            migrationBuilder.CreateIndex(
                name: "IX_SlDetails_BranchId",
                table: "SlDetails",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_SlDetails_ClassId",
                table: "SlDetails",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SlDetails_SchoolId",
                table: "SlDetails",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_SlDetails_SelectionId",
                table: "SlDetails",
                column: "SelectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_applicationFroms_groupInfos_GroupInfoGroupId",
                table: "applicationFroms",
                column: "GroupInfoGroupId",
                principalTable: "groupInfos",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_applicationFroms_groupInfos_GroupInfoGroupId",
                table: "applicationFroms");

            migrationBuilder.DropTable(
                name: "SlDetails");

            migrationBuilder.DropIndex(
                name: "IX_applicationFroms_GroupInfoGroupId",
                table: "applicationFroms");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "applicationFroms");

            migrationBuilder.DropColumn(
                name: "GroupInfoGroupId",
                table: "applicationFroms");
        }
    }
}

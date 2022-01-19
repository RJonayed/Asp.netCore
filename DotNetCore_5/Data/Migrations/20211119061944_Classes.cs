using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCore_5.Data.Migrations
{
    public partial class Classes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_classes_Branches_BranchId",
                table: "classes");

            migrationBuilder.DropIndex(
                name: "IX_classes_BranchId",
                table: "classes");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "classes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "classes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_classes_BranchId",
                table: "classes",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_classes_Branches_BranchId",
                table: "classes",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

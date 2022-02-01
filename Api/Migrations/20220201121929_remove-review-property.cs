using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class removereviewproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Course_CourseId1",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_CourseId1",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "CourseId1",
                table: "Review");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId1",
                table: "Review",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_CourseId1",
                table: "Review",
                column: "CourseId1",
                unique: true,
                filter: "[CourseId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Course_CourseId1",
                table: "Review",
                column: "CourseId1",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

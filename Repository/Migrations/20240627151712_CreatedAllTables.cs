using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CreatedAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupStudent_Groups_GroupId",
                table: "GroupStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupStudent_Students_StudentId",
                table: "GroupStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupStudent",
                table: "GroupStudent");

            migrationBuilder.RenameTable(
                name: "GroupStudent",
                newName: "GroupStudents");

            migrationBuilder.RenameIndex(
                name: "IX_GroupStudent_StudentId",
                table: "GroupStudents",
                newName: "IX_GroupStudents_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupStudent_GroupId",
                table: "GroupStudents",
                newName: "IX_GroupStudents_GroupId");

            migrationBuilder.AddColumn<int>(
                name: "EducationId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupStudents",
                table: "GroupStudents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupStudents_Groups_GroupId",
                table: "GroupStudents",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupStudents_Students_StudentId",
                table: "GroupStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupStudents_Groups_GroupId",
                table: "GroupStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupStudents_Students_StudentId",
                table: "GroupStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupStudents",
                table: "GroupStudents");

            migrationBuilder.DropColumn(
                name: "EducationId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "GroupStudents",
                newName: "GroupStudent");

            migrationBuilder.RenameIndex(
                name: "IX_GroupStudents_StudentId",
                table: "GroupStudent",
                newName: "IX_GroupStudent_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupStudents_GroupId",
                table: "GroupStudent",
                newName: "IX_GroupStudent_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupStudent",
                table: "GroupStudent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupStudent_Groups_GroupId",
                table: "GroupStudent",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupStudent_Students_StudentId",
                table: "GroupStudent",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

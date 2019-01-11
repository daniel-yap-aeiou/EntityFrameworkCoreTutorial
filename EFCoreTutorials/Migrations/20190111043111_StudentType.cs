using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreTutorials.Migrations
{
    public partial class StudentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentType",
                table: "Students",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentType",
                table: "Students");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreTutorials.Migrations
{
    public partial class StudentType1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "StudentType",
                table: "Students",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StudentType",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);
        }
    }
}

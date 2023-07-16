using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RateForProfessor.Migrations
{
    public partial class AddNewAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePhoto",
                table: "Students",
                newName: "ProfilePhotoPath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePhotoPath",
                table: "Students",
                newName: "ProfilePhoto");
        }
    }
}

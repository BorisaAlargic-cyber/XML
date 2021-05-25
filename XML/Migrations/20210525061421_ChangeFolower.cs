using Microsoft.EntityFrameworkCore.Migrations;

namespace XML.Migrations
{
    public partial class ChangeFolower : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isedFollowing",
                table: "Followers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isedFollowing",
                table: "Followers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace BloggerAPI.Migrations
{
    public partial class ModifiedBlogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Blogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

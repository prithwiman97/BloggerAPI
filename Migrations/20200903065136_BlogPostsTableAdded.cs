using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BloggerAPI.Migrations
{
    public partial class BlogPostsTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true),
                    DateOfPublish = table.Column<DateTime>(nullable: false),
                    BlogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

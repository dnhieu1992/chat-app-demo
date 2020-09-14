using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatApp.WebApi.Migrations
{
    public partial class UpdateApplicationAndConversationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Conversation");

            migrationBuilder.AddColumn<string>(
                name: "GroupAvatar",
                table: "Conversation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Conversation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupAvatar",
                table: "Conversation");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Conversation");

            migrationBuilder.DropColumn(
                name: "AvatarUrl",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Conversation",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

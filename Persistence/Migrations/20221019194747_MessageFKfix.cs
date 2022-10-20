using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class MessageFKfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_ReceiverIdId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Receiver",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ReceiverIdId",
                table: "Messages",
                newName: "ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ReceiverIdId",
                table: "Messages",
                newName: "IX_Messages_ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_ReceiverId",
                table: "Messages",
                column: "ReceiverId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_ReceiverId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "Messages",
                newName: "ReceiverIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                newName: "IX_Messages_ReceiverIdId");

            migrationBuilder.AddColumn<string>(
                name: "Receiver",
                table: "Messages",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_ReceiverIdId",
                table: "Messages",
                column: "ReceiverIdId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

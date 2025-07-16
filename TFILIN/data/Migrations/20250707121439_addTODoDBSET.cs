using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class addTODoDBSET : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreOwnerConversations_StatusCalls_statusCallId",
                table: "StoreOwnerConversations");

            migrationBuilder.RenameColumn(
                name: "statusCallId",
                table: "StoreOwnerConversations",
                newName: "StatusCallId");

            migrationBuilder.RenameColumn(
                name: "notes",
                table: "StoreOwnerConversations",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "StoreOwnerConversations",
                newName: "Image");

            migrationBuilder.RenameIndex(
                name: "IX_StoreOwnerConversations_statusCallId",
                table: "StoreOwnerConversations",
                newName: "IX_StoreOwnerConversations_StatusCallId");

            migrationBuilder.CreateTable(
                name: "Todo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToDoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todo", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_StoreOwnerConversations_StatusCalls_StatusCallId",
                table: "StoreOwnerConversations",
                column: "StatusCallId",
                principalTable: "StatusCalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreOwnerConversations_StatusCalls_StatusCallId",
                table: "StoreOwnerConversations");

            migrationBuilder.DropTable(
                name: "Todo");

            migrationBuilder.RenameColumn(
                name: "StatusCallId",
                table: "StoreOwnerConversations",
                newName: "statusCallId");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "StoreOwnerConversations",
                newName: "notes");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "StoreOwnerConversations",
                newName: "image");

            migrationBuilder.RenameIndex(
                name: "IX_StoreOwnerConversations_StatusCallId",
                table: "StoreOwnerConversations",
                newName: "IX_StoreOwnerConversations_statusCallId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreOwnerConversations_StatusCalls_statusCallId",
                table: "StoreOwnerConversations",
                column: "statusCallId",
                principalTable: "StatusCalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

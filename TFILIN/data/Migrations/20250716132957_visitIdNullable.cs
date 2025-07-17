using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class visitIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoStand_StoreOwnerConversations_StoreOwnerConversationId",
                table: "ToDoStand");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoStand_Visits_VisitId",
                table: "ToDoStand");

            migrationBuilder.AlterColumn<int>(
                name: "VisitId",
                table: "ToDoStand",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StoreOwnerConversationId",
                table: "ToDoStand",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoStand_StoreOwnerConversations_StoreOwnerConversationId",
                table: "ToDoStand",
                column: "StoreOwnerConversationId",
                principalTable: "StoreOwnerConversations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoStand_Visits_VisitId",
                table: "ToDoStand",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoStand_StoreOwnerConversations_StoreOwnerConversationId",
                table: "ToDoStand");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoStand_Visits_VisitId",
                table: "ToDoStand");

            migrationBuilder.AlterColumn<int>(
                name: "VisitId",
                table: "ToDoStand",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StoreOwnerConversationId",
                table: "ToDoStand",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoStand_StoreOwnerConversations_StoreOwnerConversationId",
                table: "ToDoStand",
                column: "StoreOwnerConversationId",
                principalTable: "StoreOwnerConversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoStand_Visits_VisitId",
                table: "ToDoStand",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

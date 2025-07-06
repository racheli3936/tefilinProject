using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class ToDoVisit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_visits_ToDoStand_ToDoId",
                table: "visits");

            migrationBuilder.DropIndex(
                name: "IX_visits_ToDoId",
                table: "visits");

            migrationBuilder.DropColumn(
                name: "ToDoId",
                table: "visits");

            migrationBuilder.RenameColumn(
                name: "satisfaction",
                table: "visits",
                newName: "Satisfaction");

            migrationBuilder.RenameColumn(
                name: "img",
                table: "visits",
                newName: "Img");

            migrationBuilder.RenameColumn(
                name: "ToDoName",
                table: "ToDoStand",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "ToDoId",
                table: "ToDoStand",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VisitId",
                table: "ToDoStand",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoStand_VisitId",
                table: "ToDoStand",
                column: "VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoStand_visits_VisitId",
                table: "ToDoStand",
                column: "VisitId",
                principalTable: "visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoStand_visits_VisitId",
                table: "ToDoStand");

            migrationBuilder.DropIndex(
                name: "IX_ToDoStand_VisitId",
                table: "ToDoStand");

            migrationBuilder.DropColumn(
                name: "ToDoId",
                table: "ToDoStand");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "ToDoStand");

            migrationBuilder.RenameColumn(
                name: "Satisfaction",
                table: "visits",
                newName: "satisfaction");

            migrationBuilder.RenameColumn(
                name: "Img",
                table: "visits",
                newName: "img");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ToDoStand",
                newName: "ToDoName");

            migrationBuilder.AddColumn<int>(
                name: "ToDoId",
                table: "visits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_visits_ToDoId",
                table: "visits",
                column: "ToDoId");

            migrationBuilder.AddForeignKey(
                name: "FK_visits_ToDoStand_ToDoId",
                table: "visits",
                column: "ToDoId",
                principalTable: "ToDoStand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

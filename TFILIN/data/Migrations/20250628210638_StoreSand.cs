using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class StoreSand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StoreStands_StandId",
                table: "StoreStands",
                column: "StandId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreStands_StoreId",
                table: "StoreStands",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StandsItem_ItemId",
                table: "StandsItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StandsItem_StandId",
                table: "StandsItem",
                column: "StandId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_StandId",
                table: "Donations",
                column: "StandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Stands_StandId",
                table: "Donations",
                column: "StandId",
                principalTable: "Stands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StandsItem_Items_ItemId",
                table: "StandsItem",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StandsItem_Stands_StandId",
                table: "StandsItem",
                column: "StandId",
                principalTable: "Stands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreStands_Stands_StandId",
                table: "StoreStands",
                column: "StandId",
                principalTable: "Stands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreStands_Stores_StoreId",
                table: "StoreStands",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Stands_StandId",
                table: "Donations");

            migrationBuilder.DropForeignKey(
                name: "FK_StandsItem_Items_ItemId",
                table: "StandsItem");

            migrationBuilder.DropForeignKey(
                name: "FK_StandsItem_Stands_StandId",
                table: "StandsItem");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreStands_Stands_StandId",
                table: "StoreStands");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreStands_Stores_StoreId",
                table: "StoreStands");

            migrationBuilder.DropIndex(
                name: "IX_StoreStands_StandId",
                table: "StoreStands");

            migrationBuilder.DropIndex(
                name: "IX_StoreStands_StoreId",
                table: "StoreStands");

            migrationBuilder.DropIndex(
                name: "IX_StandsItem_ItemId",
                table: "StandsItem");

            migrationBuilder.DropIndex(
                name: "IX_StandsItem_StandId",
                table: "StandsItem");

            migrationBuilder.DropIndex(
                name: "IX_Donations_StandId",
                table: "Donations");
        }
    }
}

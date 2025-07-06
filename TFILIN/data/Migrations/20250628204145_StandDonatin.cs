using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class StandDonatin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhonesWithDonors_Donations_DonationId",
                table: "PhonesWithDonors");

            migrationBuilder.DropForeignKey(
                name: "FK_PhonesWithDonors_StatusCalls_statusCallId",
                table: "PhonesWithDonors");

            migrationBuilder.DropForeignKey(
                name: "FK_Stands_tefilinStatuses_TefilinStatusId",
                table: "Stands");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_StoreWoners_StoreOwnerId",
                table: "Stores");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoStand_visits_VisitId",
                table: "ToDoStand");

            migrationBuilder.DropForeignKey(
                name: "FK_visits_Stands_StandId",
                table: "visits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_visits",
                table: "visits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tefilinStatuses",
                table: "tefilinStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreWoners",
                table: "StoreWoners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhonesWithDonors",
                table: "PhonesWithDonors");

            migrationBuilder.RenameTable(
                name: "visits",
                newName: "Visits");

            migrationBuilder.RenameTable(
                name: "tefilinStatuses",
                newName: "TefilinStatuses");

            migrationBuilder.RenameTable(
                name: "StoreWoners",
                newName: "StoreOwners");

            migrationBuilder.RenameTable(
                name: "PhonesWithDonors",
                newName: "DonorsConversations");

            migrationBuilder.RenameIndex(
                name: "IX_visits_StandId",
                table: "Visits",
                newName: "IX_Visits_StandId");

            migrationBuilder.RenameIndex(
                name: "IX_PhonesWithDonors_statusCallId",
                table: "DonorsConversations",
                newName: "IX_DonorsConversations_statusCallId");

            migrationBuilder.RenameIndex(
                name: "IX_PhonesWithDonors_DonationId",
                table: "DonorsConversations",
                newName: "IX_DonorsConversations_DonationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Visits",
                table: "Visits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TefilinStatuses",
                table: "TefilinStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreOwners",
                table: "StoreOwners",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DonorsConversations",
                table: "DonorsConversations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DonorsConversations_Donations_DonationId",
                table: "DonorsConversations",
                column: "DonationId",
                principalTable: "Donations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DonorsConversations_StatusCalls_statusCallId",
                table: "DonorsConversations",
                column: "statusCallId",
                principalTable: "StatusCalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stands_TefilinStatuses_TefilinStatusId",
                table: "Stands",
                column: "TefilinStatusId",
                principalTable: "TefilinStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_StoreOwners_StoreOwnerId",
                table: "Stores",
                column: "StoreOwnerId",
                principalTable: "StoreOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoStand_Visits_VisitId",
                table: "ToDoStand",
                column: "VisitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Stands_StandId",
                table: "Visits",
                column: "StandId",
                principalTable: "Stands",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonorsConversations_Donations_DonationId",
                table: "DonorsConversations");

            migrationBuilder.DropForeignKey(
                name: "FK_DonorsConversations_StatusCalls_statusCallId",
                table: "DonorsConversations");

            migrationBuilder.DropForeignKey(
                name: "FK_Stands_TefilinStatuses_TefilinStatusId",
                table: "Stands");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_StoreOwners_StoreOwnerId",
                table: "Stores");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoStand_Visits_VisitId",
                table: "ToDoStand");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Stands_StandId",
                table: "Visits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Visits",
                table: "Visits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TefilinStatuses",
                table: "TefilinStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreOwners",
                table: "StoreOwners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DonorsConversations",
                table: "DonorsConversations");

            migrationBuilder.RenameTable(
                name: "Visits",
                newName: "visits");

            migrationBuilder.RenameTable(
                name: "TefilinStatuses",
                newName: "tefilinStatuses");

            migrationBuilder.RenameTable(
                name: "StoreOwners",
                newName: "StoreWoners");

            migrationBuilder.RenameTable(
                name: "DonorsConversations",
                newName: "PhonesWithDonors");

            migrationBuilder.RenameIndex(
                name: "IX_Visits_StandId",
                table: "visits",
                newName: "IX_visits_StandId");

            migrationBuilder.RenameIndex(
                name: "IX_DonorsConversations_statusCallId",
                table: "PhonesWithDonors",
                newName: "IX_PhonesWithDonors_statusCallId");

            migrationBuilder.RenameIndex(
                name: "IX_DonorsConversations_DonationId",
                table: "PhonesWithDonors",
                newName: "IX_PhonesWithDonors_DonationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_visits",
                table: "visits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tefilinStatuses",
                table: "tefilinStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreWoners",
                table: "StoreWoners",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhonesWithDonors",
                table: "PhonesWithDonors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhonesWithDonors_Donations_DonationId",
                table: "PhonesWithDonors",
                column: "DonationId",
                principalTable: "Donations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhonesWithDonors_StatusCalls_statusCallId",
                table: "PhonesWithDonors",
                column: "statusCallId",
                principalTable: "StatusCalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stands_tefilinStatuses_TefilinStatusId",
                table: "Stands",
                column: "TefilinStatusId",
                principalTable: "tefilinStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_StoreWoners_StoreOwnerId",
                table: "Stores",
                column: "StoreOwnerId",
                principalTable: "StoreWoners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoStand_visits_VisitId",
                table: "ToDoStand",
                column: "VisitId",
                principalTable: "visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_visits_Stands_StandId",
                table: "visits",
                column: "StandId",
                principalTable: "Stands",
                principalColumn: "Id");
        }
    }
}

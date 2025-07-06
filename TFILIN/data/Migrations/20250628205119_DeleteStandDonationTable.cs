using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteStandDonationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonationStands");

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ToDoStand",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ToDoStand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "ToDoStand",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ToDoStand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "TefilinStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TefilinStatuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "TefilinStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TefilinStatuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "StatusCalls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "StatusCalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "StatusCalls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "StatusCalls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "DonorsConversations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "DonorsConversations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "DonorsConversations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "DonorsConversations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StandId",
                table: "Donations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "CreditStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CreditStatuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "CreditStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "CreditStatuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ToDoStand");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ToDoStand");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ToDoStand");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ToDoStand");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TefilinStatuses");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TefilinStatuses");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "TefilinStatuses");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TefilinStatuses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "StatusCalls");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "StatusCalls");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "StatusCalls");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "StatusCalls");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DonorsConversations");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "DonorsConversations");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "DonorsConversations");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "DonorsConversations");

            migrationBuilder.DropColumn(
                name: "StandId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CreditStatuses");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CreditStatuses");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "CreditStatuses");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "CreditStatuses");

            migrationBuilder.CreateTable(
                name: "DonationStands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateStart = table.Column<DateOnly>(type: "date", nullable: false),
                    DonationId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StandId = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationStands", x => x.Id);
                });
        }
    }
}

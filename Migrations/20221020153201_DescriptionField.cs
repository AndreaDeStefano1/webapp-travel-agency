using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp_travel_agency.Migrations
{
    public partial class DescriptionField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DestinationPacchettoViaggio_Destinations_DestinationId",
                table: "DestinationPacchettoViaggio");

            migrationBuilder.RenameColumn(
                name: "DestinationId",
                table: "DestinationPacchettoViaggio",
                newName: "DestinationsId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PacchettiViaggio",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationPacchettoViaggio_Destinations_DestinationsId",
                table: "DestinationPacchettoViaggio",
                column: "DestinationsId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DestinationPacchettoViaggio_Destinations_DestinationsId",
                table: "DestinationPacchettoViaggio");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PacchettiViaggio");

            migrationBuilder.RenameColumn(
                name: "DestinationsId",
                table: "DestinationPacchettoViaggio",
                newName: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationPacchettoViaggio_Destinations_DestinationId",
                table: "DestinationPacchettoViaggio",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
